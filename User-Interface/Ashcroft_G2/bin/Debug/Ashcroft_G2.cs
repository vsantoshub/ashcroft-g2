using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AshcroftApplication
{
    public partial class AquisForm: Form
    {
        /* recursos */
        SerialPort PortaCOM = new SerialPort();

        ulong valor_lido_ad = 0;
        string s_pressao;
        long uart_timestamp = 0;
        long tempo_exame = 0;
        Thread thr_grafico;
        Thread thr_uart;
        Thread thr_log;
        bool fim_gravacao = false;
        bool fim_processos = false;
        bool iniciou_processos = false;
        String str_nome;
        String str_idade;
        String str_sexo;
        String str_estatura;
        String str_massa;
        String str_imc;
        int valor_dp = 0; //excursiona entre 0 e 7
        int valor_membro = 1; //excursiona entre 1 e 2
        const int intervalo_amostras_arduino = 50;
        public Queue<ulong> q_samples = new Queue<ulong>();

        /* variaveis utilizadas em gravacao */
        public string separador = ";"; // separados entre parametros para ser usado no arquivo salvo (; por causa da compatibilidade com o Excel )
        public string header_gravacao = "Indice da amostra (ms); Pressao (bits ADC);";
        //public string caminho_e_nome, nome_arquivo; //relativos ao nome do arquivo gravado
        StreamWriter log_arquivo; // cria uma classe com esse nome

        public AquisForm()
        {
            InitializeComponent();

            this.Text = "Transdutor de Pressão Ashcroft G2 - UFSC";

            this.SetStyle(ControlStyles.StandardDoubleClick, true);
            this.CHART_pressao.DoubleClick += new System.EventHandler(CHART_pressao_DoubleClick);
            CHART_pressao.Series.Add("Pressao (psig)").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

            CHART_pressao.Series[0].BorderWidth = 3;
            CHART_pressao.Series[0].Color = System.Drawing.Color.Red;
            foreach (var series in CHART_pressao.Series) {
                series.Enabled = false;
                series.BorderWidth = 3;
            }
            // Inicialização da lista na página 2
            ListView_Dados.View = View.Details;
            ListView_Dados.GridLines = true;
            ListView_Dados.FullRowSelect = true;
            ListView_Dados.AllowColumnReorder = true;
            ListView_Dados.Columns.Add("Tempo (ms)", -2, HorizontalAlignment.Left);
            ListView_Dados.Columns.Add("Pressao (psig)", -2, HorizontalAlignment.Left);
            /// manter todas as colunas com mesmo tamanho
            int x = ListView_Dados.Width / 2 == 0 ? 1 : ListView_Dados.Width / 2;
            foreach (ColumnHeader coluna in ListView_Dados.Columns) {
                coluna.Width = Convert.ToInt32(Math.Floor(x * 0.98));
            }

            //cfg tempo de aquisicao
            CB_Taquis.Items.Add("10s");
            CB_Taquis.Items.Add("30s");
            CB_Taquis.Items.Add("60s");
            CB_Taquis.SelectedIndex = 0;
            CB_Taquis.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Taquis.BackColor = System.Drawing.Color.White;
            CB_Taquis.SelectedIndexChanged += new System.EventHandler(cb_taquis_SelectedIndexChanged);

            //eventos das trackbar
            this.TRACK_DP.Scroll += new System.EventHandler(this.TRACK_DP_Scroll);
            this.TRACK_Membro.Scroll += new System.EventHandler(this.TRACK_Membro_Scroll);
            //padrao de configuracao americano para data, hora, e afins
            CultureInfo culture;
            culture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            BTN_Iniciar.Enabled = true;
            BTN_Cancelar.Enabled = false;
            CB_ComPorts.Enabled = true;
            LB_LeituraAtual.Visible = false;
            TB_LeituraAtual.Visible = false;
            tempo_exame = 50000; //10s padrao
            serPortasDisponiveis();//atualiza as portas COM disponiveis
        }

        private void cb_taquis_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (CB_Taquis.SelectedIndex != -1) {
                switch (CB_Taquis.SelectedIndex) {
                    case 0:
                        tempo_exame = 50000; //10s 
                        Debug.WriteLine("ComboBox Taquis");
                        Debug.WriteLine(tempo_exame.ToString());
                        break;

                    case 1:
                        tempo_exame = 150000; //30s 
                        Debug.WriteLine("ComboBox Taquis");
                        Debug.WriteLine(tempo_exame.ToString());
                        break;

                    case 2:
                        tempo_exame = 300000; //60s 
                        Debug.WriteLine("ComboBox Taquis");
                        Debug.WriteLine(tempo_exame.ToString());
                        break;

                    default:
                        tempo_exame = 50000; //4k
                        Debug.WriteLine("ComboBox Taquis");
                        Debug.WriteLine(tempo_exame.ToString());
                        break;
                }
            }
            else { //Value is null }
                tempo_exame = 50000; //4k
                Debug.WriteLine("ComboBox Taquis");
                Debug.WriteLine(tempo_exame.ToString());
            }
        }

        private void TRACK_DP_Scroll(object sender, System.EventArgs e)
        {
            valor_dp = TRACK_DP.Value;
            LB_valor_DP.Text = valor_dp.ToString();
            Debug.WriteLine("TRACK_DP");
            Debug.WriteLine(TRACK_DP.Value.ToString());
        }

        private void TRACK_Membro_Scroll(object sender, System.EventArgs e)
        {
            valor_membro = TRACK_Membro.Value;
            Debug.WriteLine("TRACK_Membro");
            Debug.WriteLine(TRACK_Membro.Value.ToString());
        }

        //verifica e atualiza as portas seriais disponiveis
        void serPortasDisponiveis()
        {
            CB_ComPorts.Items.Clear();
            String[] portas = SerialPort.GetPortNames();
            CB_ComPorts.Items.AddRange(portas);

        }

        private void CB_ComPorts_Click(object sender, EventArgs e)
        {
            CB_ComPorts.Items.Clear();
            serPortasDisponiveis();
        }

        //edição de parametros do grafico, como maximo e minimo dos eixos
        private void CHART_pressao_DoubleClick(object sender, EventArgs e)
        {
            //Habilita edição da janela de configuração do gráfico
            AxisConfig SecondaryForm = new AxisConfig();
            SecondaryForm.ShowDialog();
            string[] parametros = SecondaryForm.Parametros;
            if ((IsNumeric(parametros[0]) == true) && (parametros[0].Equals("auto") == false) && (parametros[1].Equals("") == false) && (parametros[0].Equals("") == false) && (parametros[0].Equals("null") == false) && (Convert.ToDouble(parametros[0]) > Convert.ToDouble(parametros[1]))) { CHART_pressao.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(parametros[0]); }
            if ((IsNumeric(parametros[1]) == true) && (parametros[0].Equals("auto") == false) && (parametros[1].Equals("") == false) && (parametros[0].Equals("") == false) && (parametros[1].Equals("null") == false) && (Convert.ToDouble(parametros[0]) > Convert.ToDouble(parametros[1]))) { CHART_pressao.ChartAreas[0].AxisX.Minimum = Convert.ToDouble(parametros[1]); }
            if ((IsNumeric(parametros[2]) == true) && (parametros[0].Equals("auto") == false) && (parametros[3].Equals("") == false) && (parametros[2].Equals("") == false) && (parametros[2].Equals("null") == false) && (Convert.ToDouble(parametros[2]) > Convert.ToDouble(parametros[3]))) { CHART_pressao.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(parametros[2]); }
            if ((IsNumeric(parametros[3]) == true) && (parametros[0].Equals("auto") == false) && (parametros[3].Equals("") == false) && (parametros[2].Equals("") == false) && (parametros[3].Equals("null") == false) && (Convert.ToDouble(parametros[2]) > Convert.ToDouble(parametros[3]))) { CHART_pressao.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(parametros[3]); }
            if ((parametros[0] == "auto" & parametros[1] == "auto" & parametros[2] == "auto" & parametros[3] == "auto") == true) {
                CHART_pressao.ChartAreas[0].AxisX.Maximum = double.NaN;
                CHART_pressao.ChartAreas[0].AxisY.Maximum = double.NaN;
                CHART_pressao.ChartAreas[0].AxisX.Minimum = double.NaN;
                CHART_pressao.ChartAreas[0].AxisY.Minimum = double.NaN;
            }

        }

        //funcao de teste para descobrir se o valor eh numerico
        public static bool IsNumeric(object value)
        {
            if (value == null || value is DateTime) {
                return false;
            }

            if (value is Int16 || value is Int32 || value is Int64 || value is Decimal || value is Single || value is Double || value is Boolean) {
                return true;
            }

            try {
                if (value is string)
                    Double.Parse(value as string);
                else
                    Double.Parse(value.ToString());
                return true;
            }
            catch { }
            return false;
        }


        public static string ByteArrayToString(byte[] ba)
        {
            //if (BitConverter.IsLittleEndian)
            //    Array.Reverse(ba);

            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }

        void TB_Nome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void CB_Macho_CheckedChanged(Object sender, EventArgs e)
        {
            str_sexo = "";
            str_sexo += "M";
            CB_Femea.Checked = false;
        }

        private void CB_Femea_CheckedChanged(Object sender, EventArgs e)
        {
            str_sexo = "";
            str_sexo += "F";
            CB_Macho.Checked = false;
        }

        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        private String verifica_dados()
        {
            int error_code = 0;
            String error_str = "";
            if ((string.IsNullOrWhiteSpace(TB_Nome.Text))) {
                error_code = 1;
                error_str += "Nome Vazio\n";
            }
            if ((string.IsNullOrWhiteSpace(TB_Idade.Text))) {
                error_code = 2;
                error_str += "Idade Vazio\n";
            }
            if ((string.IsNullOrWhiteSpace(TB_Estatura.Text))) {
                error_code = 3;
                error_str += "Estatura Vazio\n";
            }
            if ((string.IsNullOrWhiteSpace(TB_Massa.Text))) {
                error_code = 4;
                error_str += "Massa Vazio\n";
            }

            if ((CB_Macho.Checked == false) && (CB_Femea.Checked == false)) {
                error_code = 5;
                error_str += "Sexo não selecionado\n";
            }
            if (error_code > 0) {
                MessageBox.Show(error_str, "Campos Vazios");
            }

            return error_str;
        }

        private string calcula_imc(String estatura, String massa)
        {
            double f_massa;
            double t_estatura;
            double calculo = 0;
            Double.TryParse(massa, out f_massa);
            Double.TryParse(estatura, out t_estatura);
            //Debug.WriteLine("Massa: " + f_massa.ToString());

            double f_estatura = t_estatura / 100;
            //Debug.WriteLine("Estatura: " + f_estatura.ToString());

            calculo = f_massa / (f_estatura * f_estatura);
            //Debug.WriteLine("Calculo IMC: " + calculo.ToString("0.00"));

            return calculo.ToString("0.00");
        }

        private void grava_log(string path, string filename)
        {
            if(fim_gravacao == false) { 
            DateTime time_struct = DateTime.Now;
            int dia = time_struct.Day;
            int mes = time_struct.Month;
            int ano = time_struct.Year;
            int hora = time_struct.Hour;
            int min = time_struct.Minute;
            string caminho_e_nome;
            //nome_arquivo = "LMPT_UFSC-" + dia.ToString() + "-" + mes.ToString() + "-" + ano.ToString() + "  " + hora.ToString() + "_" + min.ToString();
            //caminho_e_nome = Path.Combine(path, filename + ".txt"); // vai escrever no diretório escolhido pelo usuário
            caminho_e_nome = Path.Combine(path, filename);
            log_arquivo = File.CreateText(caminho_e_nome); // se quer escrever por cima de arq existente
            log_arquivo.WriteLine("Nome: " + str_nome);
            log_arquivo.WriteLine("Idade: " + str_idade);
            log_arquivo.WriteLine("Sexo: " + str_sexo);
            log_arquivo.WriteLine("Estatura (cm): " + str_estatura);
            log_arquivo.WriteLine("Massa (kg): " + str_massa);
            log_arquivo.WriteLine("IMC: " + str_imc);
            log_arquivo.WriteLine("Estágio DP: " + valor_dp.ToString());
            if (valor_membro == 1) log_arquivo.WriteLine("Membro DP: E");
            else if (valor_membro == 2) log_arquivo.WriteLine("Membro DP: D");

            log_arquivo.WriteLine(header_gravacao);

            for (int i = 0; i < ListView_Dados.Items.Count; i++) {
                Debug.WriteLine(ListView_Dados.Items[i].Text + separador + ListView_Dados.Items[i].SubItems[1].Text);
                log_arquivo.WriteLine(ListView_Dados.Items[i].Text + separador + ListView_Dados.Items[i].SubItems[1].Text);
            }
            log_arquivo.Close();
            fim_gravacao = true;
            }
        }

        private void plota_grafico()
        {
            ulong temp;

            while (fim_processos != true) {
                if ((uart_timestamp * intervalo_amostras_arduino) <= tempo_exame) {
                    if (q_samples.Count > 0) {
                        temp = q_samples.Dequeue();
                        s_pressao = Convert.ToString(temp);
                        //Debug.WriteLine("");
                        //Debug.WriteLine("Valor Pressao: ");
                        //Debug.WriteLine(s_pressao);

                        var lista = new ListViewItem(new[] { Convert.ToString(uart_timestamp * 10), s_pressao });

                        this.Invoke((MethodInvoker)delegate {

                            CHART_pressao.Series["Pressao (psig)"].Points.AddXY(uart_timestamp * 10, temp);
                            ListView_Dados.Items.Add(lista);
                            TB_LeituraAtual.Text = s_pressao;

                        });
                        uart_timestamp = (uart_timestamp + 1);
                    }
                }
                else {
                    if (fim_gravacao == false) {
                        string caminho_gravacao = "";
                        string log_filename = ""; ; //filename sugerido (default)
                        this.Invoke((MethodInvoker)delegate {

                            //using (var folderDialog = new FolderBrowserDialog()) {
                            //    if (folderDialog.ShowDialog() == DialogResult.OK) {

                            //        caminho_gravacao = folderDialog.SelectedPath;
                            //    }
                            //    else {
                            //        caminho_gravacao = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Lo‌​cation);

                            //    }
                            //}
                            DateTime time_struct = DateTime.Now;
                            int dia = time_struct.Day;
                            int mes = time_struct.Month;
                            int ano = time_struct.Year;
                            int hora = time_struct.Hour;
                            int min = time_struct.Minute;
                            
                            log_filename = "LMPT_UFSC-" + dia.ToString() + "-" + mes.ToString() + "-" + ano.ToString() + "  " + hora.ToString() + "_" + min.ToString();

                            SaveFileDialog sf = new SaveFileDialog();
                            // Feed the dummy name to the save dialog
                            sf.FileName = log_filename;
                            sf.Title = "Salvar o log do exame";
                            sf.DefaultExt = "txt";
                            sf.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                            sf.FilterIndex = 1;
                            if (sf.ShowDialog() == DialogResult.OK) {
                                // Now here's our save folder
                                caminho_gravacao = Path.GetDirectoryName(sf.FileName);
                                log_filename = sf.FileName;
                                // Do whatever
                            }
                        else {
                                caminho_gravacao = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Lo‌​cation);

                            }


                        });
                        Debug.WriteLine("Caminho do log: " + caminho_gravacao);
                        Debug.WriteLine("Filename: " + log_filename);

                        thr_log = new Thread(() => grava_log(caminho_gravacao, log_filename));
                        thr_log.IsBackground = true;
                        thr_log.Start();
                        while (fim_gravacao != true) ;
                        this.BeginInvoke((MethodInvoker)delegate {
                            MessageBox.Show("Dados gravados com sucesso!.", "Log do exame");
                        });
                        thr_log.Abort();
                    }
                }

            }
        }

        private void uart_rx_loop(SerialPort uart_port)      //loop untill told to stop 
        {
            int rx_counter = 0;
            string nome_porta = uart_port.PortName; // pega o nome da porta já aberta
            uart_port = new SerialPort(nome_porta, 115200, Parity.None, 8, StopBits.One);
            StringBuilder sb_uart_rx = new StringBuilder();
            byte[] rx_samples;
            uart_port.Open();

            while ((fim_processos != true) && ((uart_timestamp * intervalo_amostras_arduino) <= tempo_exame)) {
                if (uart_port.IsOpen == true) {
                    if (uart_port.BytesToRead > 0) {
                        String indata = uart_port.ReadByte().ToString("X2"); //mostra a string em hexadecimal


                        if (rx_counter > 0) {
                            sb_uart_rx.Append(indata);
                            rx_counter = rx_counter + 1;

                            if (rx_counter == 4) //tamanho do frame de retorno do IO Data Sample RX Indicator
                            {
                                //Debug.WriteLine("ATND: HEX STRING: ");
                                //Console.Write(sb_uart_rx);
                                rx_counter = 0;
                                rx_samples = StringToByteArray(sb_uart_rx.ToString());
                                //Debug.WriteLine("");
                                //Debug.WriteLine("HEX BYTE ARRAY: ");
                                string hex = ByteArrayToString(rx_samples);
                                //string hex = BitConverter.ToString(rx_samples);

                                valor_lido_ad = (Convert.ToUInt64(hex.Substring(2, 2), 16) << 8) + Convert.ToUInt64(hex.Substring(4, 2), 16);

                                Debug.WriteLine(hex + ":" + valor_lido_ad);


                                q_samples.Enqueue(valor_lido_ad);
                                //Debug.WriteLine("");
                                //Debug.WriteLine("IO Data: Tamanho Byte array: {0}", rx_samples.Length);

                                //limpa a string de dados recebidos
                                sb_uart_rx.Clear();

                            }
                        }
                        //FF byte de inicio
                        if (String.Equals(indata, "1F")) {
                            rx_counter = 1;
                            sb_uart_rx.Clear();
                            sb_uart_rx.Append(indata);
                        }

                    }

                }
                else {

                }// end if else

            }// end while

            uart_port.Close();

        } // fim void

        /* métodos para limitar a entrada das textbox abaixo apenas para numeros */
        private void TB_Idade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void TB_Estatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void TB_Massa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(verifica_dados())) {
                TB_IMC.Text = calcula_imc(TB_Estatura.Text, TB_Massa.Text);
                str_nome = TB_Nome.Text;
                str_idade = TB_Idade.Text;
                str_estatura = TB_Estatura.Text;
                str_massa = TB_Massa.Text;
                str_imc = TB_IMC.Text;
                //Debug.WriteLine("Nome: " + str_nome);
                //Debug.WriteLine("Idade: " + str_idade);
                //Debug.WriteLine("Sexo: " + str_sexo);
                //Debug.WriteLine("Estatura: " + str_estatura);
                //Debug.WriteLine("Massa: " + str_massa);
                //Debug.WriteLine("IMC: " + str_imc);
                //Debug.WriteLine("DP: " + valor_dp.ToString());
                //Debug.WriteLine("Membro: " + valor_membro.ToString());

                if (CB_ComPorts.SelectedIndex != -1) {
                    PortaCOM.PortName = CB_ComPorts.Text;
                    try {
                        PortaCOM = new SerialPort(PortaCOM.PortName);
                        PortaCOM.BaudRate = 115200;
                        PortaCOM.DataBits = 8;
                        PortaCOM.Parity = Parity.None;
                        PortaCOM.StopBits = StopBits.One;
                        PortaCOM.Handshake = Handshake.None;
                        //PortaCOM.ReceivedBytesThreshold = 4; //tamanho do pacote de dados
                        PortaCOM.Open();
                    }
                    catch (Exception exception) {
                        MessageBox.Show("Erro ao abrir Porta COM.\n" + exception.ToString(), "COM ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PortaCOM.Dispose();
                        Application.Exit();
                    }

                    if (PortaCOM.IsOpen) {
                        PortaCOM.Close();
                        fim_gravacao = false;
                        iniciou_processos = true;
                        LB_LeituraAtual.Visible = true;
                        TB_LeituraAtual.Visible = true;
                        fim_processos = false;
                        uart_timestamp = 0;
                        thr_uart = new Thread(() => uart_rx_loop(PortaCOM));
                        thr_uart.IsBackground = true;
                        thr_uart.Start();
                        thr_grafico = new Thread(new ThreadStart(plota_grafico));
                        thr_grafico.IsBackground = true;
                        thr_grafico.Start();

                        CHART_pressao.Series["Pressao (psig)"].Enabled = true;
                        CHART_pressao.ChartAreas[0].AxisX.Title = "T [ms]";
                        CHART_pressao.ChartAreas[0].AxisY.Title = "ADC [value]";
                        CHART_pressao.ChartAreas[0].AxisY.Maximum = 1030;//double.NaN; ; //max 1024 por enquanto
                        CHART_pressao.ChartAreas[0].AxisY.Minimum = double.NaN;
                        CHART_pressao.ChartAreas[0].AxisX.Interval = 1000;

                        CHART_pressao.Series[0].Points.Clear();

                        // Clear List - pagina 2
                        ListView_Dados.Items.Clear();
                        BTN_Iniciar.Enabled = false;
                        BTN_Cancelar.Enabled = true;
                    }
                    else {
                        LB_LeituraAtual.Visible = false;
                        TB_LeituraAtual.Visible = false;

                    }
                }

                else {
                    CB_ComPorts.Items.Clear();
                    serPortasDisponiveis();

                }
            }

        }

        private void limpa_interface()
        {
            TB_Nome.Clear();
            TB_Idade.Clear();
            CB_Femea.Checked = false;
            CB_Macho.Checked = false;
            TB_Estatura.Clear();
            TB_Massa.Clear();
            TB_IMC.Text = "IMC";
            TRACK_DP.Value = TRACK_DP.Minimum;
            LB_valor_DP.Text = TRACK_DP.Value.ToString();
            TRACK_Membro.Value = TRACK_Membro.Minimum;
            TB_LeituraAtual.Clear();

        }


        private void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            if (iniciou_processos == true) {
                try {
                    LB_LeituraAtual.Visible = false;
                    fim_processos = true;
                    limpa_interface();
                    ListView_Dados.Items.Clear();
                    BTN_Iniciar.Enabled = true;
                    BTN_Cancelar.Enabled = false;
                    LB_LeituraAtual.Visible = false;
                    TB_LeituraAtual.Visible = false;

                    CB_ComPorts.ResetText();
                    CB_ComPorts.SelectedIndex = -1;
                    serPortasDisponiveis();
                    
                    if (!thr_grafico.Join(1000)) {
                        thr_grafico.Abort();
                    }
                    if (!thr_uart.Join(1000)) {
                        thr_uart.Abort();
                    }

                    CHART_pressao.Series[0].Points.Clear();

                        if (PortaCOM.IsOpen) {
                            
                            PortaCOM.Close();
                        PortaCOM.Dispose();
                        PortaCOM = null;

                        }
                    
                    iniciou_processos = false;

                }
                catch (Exception exception) {
                    MessageBox.Show("Erro ao reiniciar o programa.\n" + exception.ToString(), "APP ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

            }

        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            if (iniciou_processos == true) {
                try {
                    fim_processos = true;
                    if (!thr_grafico.Join(500)) {
                        thr_grafico.Abort();
                    }
                    if (!thr_uart.Join(500)) {
                        thr_uart.Abort();
                    }
                    
                        PortaCOM.Dispose();
                        PortaCOM.Close();
                    //mata o processo, nao teve jeito de encerrar de forma passiva...
                    try {
                        foreach (Process proc in Process.GetProcessesByName("Ashcroft_G2")) {
                            proc.Kill();
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch (Exception exception) {
                    MessageBox.Show("Erro ao encerrar o programa.\n" + exception.ToString(), "APP ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            } else {
                
                Application.Exit();
            }
            


        }


    }
}

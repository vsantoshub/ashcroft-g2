namespace AshcroftApplication
{
    partial class AquisForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.TabDataList = new System.Windows.Forms.TabPage();
            this.ListView_Dados = new System.Windows.Forms.ListView();
            this.TabChart = new System.Windows.Forms.TabPage();
            this.lb_imc = new System.Windows.Forms.Label();
            this.lb_massa = new System.Windows.Forms.Label();
            this.lb_estatura = new System.Windows.Forms.Label();
            this.lb_sexo = new System.Windows.Forms.Label();
            this.lb_idade = new System.Windows.Forms.Label();
            this.lb_nome = new System.Windows.Forms.Label();
            this.CB_Taquis = new System.Windows.Forms.ComboBox();
            this.LB_Taquis = new System.Windows.Forms.Label();
            this.BTN_Cancelar = new System.Windows.Forms.Button();
            this.LB_LeituraAtual = new System.Windows.Forms.Label();
            this.TB_IMC = new System.Windows.Forms.TextBox();
            this.BTN_Iniciar = new System.Windows.Forms.Button();
            this.TB_LeituraAtual = new System.Windows.Forms.TextBox();
            this.LB_valor_DP = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_Massa = new System.Windows.Forms.TextBox();
            this.TB_Estatura = new System.Windows.Forms.TextBox();
            this.TB_Idade = new System.Windows.Forms.TextBox();
            this.LB_DadosPaciente = new System.Windows.Forms.Label();
            this.TB_Nome = new System.Windows.Forms.TextBox();
            this.TRACK_DP = new System.Windows.Forms.TrackBar();
            this.TRACK_Membro = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.LB_EstagioDP = new System.Windows.Forms.Label();
            this.CB_Femea = new System.Windows.Forms.CheckBox();
            this.CB_Macho = new System.Windows.Forms.CheckBox();
            this.LB_PortaCOM = new System.Windows.Forms.Label();
            this.CHART_pressao = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BTN_Quit = new System.Windows.Forms.Button();
            this.CB_ComPorts = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabDataList.SuspendLayout();
            this.TabChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRACK_DP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TRACK_Membro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CHART_pressao)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabDataList
            // 
            this.TabDataList.Controls.Add(this.ListView_Dados);
            this.TabDataList.Location = new System.Drawing.Point(4, 22);
            this.TabDataList.Name = "TabDataList";
            this.TabDataList.Padding = new System.Windows.Forms.Padding(3);
            this.TabDataList.Size = new System.Drawing.Size(1147, 573);
            this.TabDataList.TabIndex = 2;
            this.TabDataList.Text = "Dados";
            this.TabDataList.UseVisualStyleBackColor = true;
            // 
            // ListView_Dados
            // 
            this.ListView_Dados.Location = new System.Drawing.Point(6, 6);
            this.ListView_Dados.Name = "ListView_Dados";
            this.ListView_Dados.Size = new System.Drawing.Size(649, 369);
            this.ListView_Dados.TabIndex = 0;
            this.ListView_Dados.UseCompatibleStateImageBehavior = false;
            // 
            // TabChart
            // 
            this.TabChart.BackColor = System.Drawing.Color.LightGray;
            this.TabChart.Controls.Add(this.lb_imc);
            this.TabChart.Controls.Add(this.lb_massa);
            this.TabChart.Controls.Add(this.lb_estatura);
            this.TabChart.Controls.Add(this.lb_sexo);
            this.TabChart.Controls.Add(this.lb_idade);
            this.TabChart.Controls.Add(this.lb_nome);
            this.TabChart.Controls.Add(this.CB_Taquis);
            this.TabChart.Controls.Add(this.LB_Taquis);
            this.TabChart.Controls.Add(this.BTN_Cancelar);
            this.TabChart.Controls.Add(this.LB_LeituraAtual);
            this.TabChart.Controls.Add(this.TB_IMC);
            this.TabChart.Controls.Add(this.BTN_Iniciar);
            this.TabChart.Controls.Add(this.TB_LeituraAtual);
            this.TabChart.Controls.Add(this.LB_valor_DP);
            this.TabChart.Controls.Add(this.label6);
            this.TabChart.Controls.Add(this.label5);
            this.TabChart.Controls.Add(this.TB_Massa);
            this.TabChart.Controls.Add(this.TB_Estatura);
            this.TabChart.Controls.Add(this.TB_Idade);
            this.TabChart.Controls.Add(this.LB_DadosPaciente);
            this.TabChart.Controls.Add(this.TB_Nome);
            this.TabChart.Controls.Add(this.TRACK_DP);
            this.TabChart.Controls.Add(this.TRACK_Membro);
            this.TabChart.Controls.Add(this.label3);
            this.TabChart.Controls.Add(this.LB_EstagioDP);
            this.TabChart.Controls.Add(this.CB_Femea);
            this.TabChart.Controls.Add(this.CB_Macho);
            this.TabChart.Controls.Add(this.LB_PortaCOM);
            this.TabChart.Controls.Add(this.CHART_pressao);
            this.TabChart.Controls.Add(this.BTN_Quit);
            this.TabChart.Controls.Add(this.CB_ComPorts);
            this.TabChart.ForeColor = System.Drawing.SystemColors.InfoText;
            this.TabChart.Location = new System.Drawing.Point(4, 22);
            this.TabChart.Margin = new System.Windows.Forms.Padding(2);
            this.TabChart.Name = "TabChart";
            this.TabChart.Padding = new System.Windows.Forms.Padding(2);
            this.TabChart.Size = new System.Drawing.Size(1147, 573);
            this.TabChart.TabIndex = 0;
            this.TabChart.Text = "Grafico";
            // 
            // lb_imc
            // 
            this.lb_imc.AutoSize = true;
            this.lb_imc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_imc.Location = new System.Drawing.Point(848, 203);
            this.lb_imc.Name = "lb_imc";
            this.lb_imc.Size = new System.Drawing.Size(98, 16);
            this.lb_imc.TabIndex = 88;
            this.lb_imc.Text = "Cálculo_IMC:";
            // 
            // lb_massa
            // 
            this.lb_massa.AutoSize = true;
            this.lb_massa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_massa.Location = new System.Drawing.Point(848, 162);
            this.lb_massa.Name = "lb_massa";
            this.lb_massa.Size = new System.Drawing.Size(94, 16);
            this.lb_massa.TabIndex = 87;
            this.lb_massa.Text = "Massa (Kg) :";
            // 
            // lb_estatura
            // 
            this.lb_estatura.AutoSize = true;
            this.lb_estatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_estatura.Location = new System.Drawing.Point(848, 119);
            this.lb_estatura.Name = "lb_estatura";
            this.lb_estatura.Size = new System.Drawing.Size(107, 16);
            this.lb_estatura.TabIndex = 86;
            this.lb_estatura.Text = "Estatura (cm) :";
            // 
            // lb_sexo
            // 
            this.lb_sexo.AutoSize = true;
            this.lb_sexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sexo.Location = new System.Drawing.Point(981, 84);
            this.lb_sexo.Name = "lb_sexo";
            this.lb_sexo.Size = new System.Drawing.Size(47, 16);
            this.lb_sexo.TabIndex = 85;
            this.lb_sexo.Text = "Sexo:";
            // 
            // lb_idade
            // 
            this.lb_idade.AutoSize = true;
            this.lb_idade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_idade.Location = new System.Drawing.Point(848, 84);
            this.lb_idade.Name = "lb_idade";
            this.lb_idade.Size = new System.Drawing.Size(52, 16);
            this.lb_idade.TabIndex = 84;
            this.lb_idade.Text = "Idade:";
            // 
            // lb_nome
            // 
            this.lb_nome.AutoSize = true;
            this.lb_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nome.Location = new System.Drawing.Point(848, 52);
            this.lb_nome.Name = "lb_nome";
            this.lb_nome.Size = new System.Drawing.Size(53, 16);
            this.lb_nome.TabIndex = 83;
            this.lb_nome.Text = "Nome:";
            // 
            // CB_Taquis
            // 
            this.CB_Taquis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Taquis.FormattingEnabled = true;
            this.CB_Taquis.Location = new System.Drawing.Point(413, 535);
            this.CB_Taquis.Name = "CB_Taquis";
            this.CB_Taquis.Size = new System.Drawing.Size(149, 28);
            this.CB_Taquis.TabIndex = 82;
            // 
            // LB_Taquis
            // 
            this.LB_Taquis.AutoSize = true;
            this.LB_Taquis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Taquis.Location = new System.Drawing.Point(409, 512);
            this.LB_Taquis.Name = "LB_Taquis";
            this.LB_Taquis.Size = new System.Drawing.Size(153, 20);
            this.LB_Taquis.TabIndex = 81;
            this.LB_Taquis.Text = "Tempo de Aquisição";
            // 
            // BTN_Cancelar
            // 
            this.BTN_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Cancelar.Location = new System.Drawing.Point(730, 510);
            this.BTN_Cancelar.Name = "BTN_Cancelar";
            this.BTN_Cancelar.Size = new System.Drawing.Size(96, 58);
            this.BTN_Cancelar.TabIndex = 80;
            this.BTN_Cancelar.Text = "Cancelar";
            this.BTN_Cancelar.UseVisualStyleBackColor = true;
            this.BTN_Cancelar.Click += new System.EventHandler(this.BTN_Cancelar_Click);
            // 
            // LB_LeituraAtual
            // 
            this.LB_LeituraAtual.AutoSize = true;
            this.LB_LeituraAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_LeituraAtual.Location = new System.Drawing.Point(870, 438);
            this.LB_LeituraAtual.Name = "LB_LeituraAtual";
            this.LB_LeituraAtual.Size = new System.Drawing.Size(118, 24);
            this.LB_LeituraAtual.TabIndex = 78;
            this.LB_LeituraAtual.Text = "Leitura Atual:";
            // 
            // TB_IMC
            // 
            this.TB_IMC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_IMC.Location = new System.Drawing.Point(962, 197);
            this.TB_IMC.Name = "TB_IMC";
            this.TB_IMC.ReadOnly = true;
            this.TB_IMC.Size = new System.Drawing.Size(168, 26);
            this.TB_IMC.TabIndex = 76;
            this.TB_IMC.Text = "IMC";
            this.TB_IMC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BTN_Iniciar
            // 
            this.BTN_Iniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Iniciar.Location = new System.Drawing.Point(605, 512);
            this.BTN_Iniciar.Name = "BTN_Iniciar";
            this.BTN_Iniciar.Size = new System.Drawing.Size(96, 58);
            this.BTN_Iniciar.TabIndex = 75;
            this.BTN_Iniciar.Text = "Iniciar";
            this.BTN_Iniciar.UseVisualStyleBackColor = true;
            this.BTN_Iniciar.Click += new System.EventHandler(this.btn_iniciar_Click);
            // 
            // TB_LeituraAtual
            // 
            this.TB_LeituraAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_LeituraAtual.Location = new System.Drawing.Point(994, 423);
            this.TB_LeituraAtual.Name = "TB_LeituraAtual";
            this.TB_LeituraAtual.ReadOnly = true;
            this.TB_LeituraAtual.Size = new System.Drawing.Size(113, 56);
            this.TB_LeituraAtual.TabIndex = 74;
            // 
            // LB_valor_DP
            // 
            this.LB_valor_DP.AutoSize = true;
            this.LB_valor_DP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_valor_DP.Location = new System.Drawing.Point(1088, 276);
            this.LB_valor_DP.Name = "LB_valor_DP";
            this.LB_valor_DP.Size = new System.Drawing.Size(19, 20);
            this.LB_valor_DP.TabIndex = 73;
            this.LB_valor_DP.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(859, 362);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 20);
            this.label6.TabIndex = 72;
            this.label6.Text = "E";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1091, 362);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 20);
            this.label5.TabIndex = 71;
            this.label5.Text = "D";
            // 
            // TB_Massa
            // 
            this.TB_Massa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Massa.Location = new System.Drawing.Point(962, 156);
            this.TB_Massa.Name = "TB_Massa";
            this.TB_Massa.Size = new System.Drawing.Size(168, 22);
            this.TB_Massa.TabIndex = 70;
            this.TB_Massa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_Massa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Massa_KeyPress);
            // 
            // TB_Estatura
            // 
            this.TB_Estatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Estatura.Location = new System.Drawing.Point(961, 116);
            this.TB_Estatura.Name = "TB_Estatura";
            this.TB_Estatura.Size = new System.Drawing.Size(169, 22);
            this.TB_Estatura.TabIndex = 69;
            this.TB_Estatura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_Estatura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Estatura_KeyPress);
            // 
            // TB_Idade
            // 
            this.TB_Idade.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TB_Idade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Idade.Location = new System.Drawing.Point(907, 82);
            this.TB_Idade.Name = "TB_Idade";
            this.TB_Idade.Size = new System.Drawing.Size(65, 22);
            this.TB_Idade.TabIndex = 68;
            this.TB_Idade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_Idade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Idade_KeyPress);
            // 
            // LB_DadosPaciente
            // 
            this.LB_DadosPaciente.AutoSize = true;
            this.LB_DadosPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_DadosPaciente.Location = new System.Drawing.Point(917, 14);
            this.LB_DadosPaciente.Name = "LB_DadosPaciente";
            this.LB_DadosPaciente.Size = new System.Drawing.Size(168, 24);
            this.LB_DadosPaciente.TabIndex = 67;
            this.LB_DadosPaciente.Text = "Dados do paciente";
            // 
            // TB_Nome
            // 
            this.TB_Nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Nome.Location = new System.Drawing.Point(907, 49);
            this.TB_Nome.Name = "TB_Nome";
            this.TB_Nome.Size = new System.Drawing.Size(224, 22);
            this.TB_Nome.TabIndex = 66;
            this.TB_Nome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_Nome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Nome_KeyPress);
            // 
            // TRACK_DP
            // 
            this.TRACK_DP.LargeChange = 1;
            this.TRACK_DP.Location = new System.Drawing.Point(902, 276);
            this.TRACK_DP.Maximum = 7;
            this.TRACK_DP.Name = "TRACK_DP";
            this.TRACK_DP.Size = new System.Drawing.Size(183, 45);
            this.TRACK_DP.TabIndex = 63;
            // 
            // TRACK_Membro
            // 
            this.TRACK_Membro.LargeChange = 1;
            this.TRACK_Membro.Location = new System.Drawing.Point(907, 362);
            this.TRACK_Membro.Maximum = 2;
            this.TRACK_Membro.Minimum = 1;
            this.TRACK_Membro.Name = "TRACK_Membro";
            this.TRACK_Membro.Size = new System.Drawing.Size(174, 45);
            this.TRACK_Membro.TabIndex = 62;
            this.TRACK_Membro.Value = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(961, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 61;
            this.label3.Text = "Membro";
            // 
            // LB_EstagioDP
            // 
            this.LB_EstagioDP.AutoSize = true;
            this.LB_EstagioDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_EstagioDP.Location = new System.Drawing.Point(939, 245);
            this.LB_EstagioDP.Name = "LB_EstagioDP";
            this.LB_EstagioDP.Size = new System.Drawing.Size(108, 16);
            this.LB_EstagioDP.TabIndex = 60;
            this.LB_EstagioDP.Text = "Estágio da DP";
            // 
            // CB_Femea
            // 
            this.CB_Femea.AutoSize = true;
            this.CB_Femea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Femea.Location = new System.Drawing.Point(1092, 80);
            this.CB_Femea.Name = "CB_Femea";
            this.CB_Femea.Size = new System.Drawing.Size(38, 24);
            this.CB_Femea.TabIndex = 59;
            this.CB_Femea.Text = "F";
            this.CB_Femea.UseVisualStyleBackColor = true;
            this.CB_Femea.CheckedChanged += new System.EventHandler(this.CB_Femea_CheckedChanged);
            // 
            // CB_Macho
            // 
            this.CB_Macho.AutoSize = true;
            this.CB_Macho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Macho.Location = new System.Drawing.Point(1044, 80);
            this.CB_Macho.Name = "CB_Macho";
            this.CB_Macho.Size = new System.Drawing.Size(41, 24);
            this.CB_Macho.TabIndex = 58;
            this.CB_Macho.Text = "M";
            this.CB_Macho.UseVisualStyleBackColor = true;
            this.CB_Macho.CheckedChanged += new System.EventHandler(this.CB_Macho_CheckedChanged);
            // 
            // LB_PortaCOM
            // 
            this.LB_PortaCOM.AutoSize = true;
            this.LB_PortaCOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_PortaCOM.Location = new System.Drawing.Point(35, 512);
            this.LB_PortaCOM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LB_PortaCOM.Name = "LB_PortaCOM";
            this.LB_PortaCOM.Size = new System.Drawing.Size(96, 20);
            this.LB_PortaCOM.TabIndex = 52;
            this.LB_PortaCOM.Text = "Porta COM";
            // 
            // CHART_pressao
            // 
            this.CHART_pressao.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None;
            this.CHART_pressao.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.CHART_pressao.ChartAreas.Add(chartArea1);
            this.CHART_pressao.IsSoftShadows = false;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.CHART_pressao.Legends.Add(legend1);
            this.CHART_pressao.Location = new System.Drawing.Point(7, 14);
            this.CHART_pressao.Margin = new System.Windows.Forms.Padding(2);
            this.CHART_pressao.Name = "CHART_pressao";
            this.CHART_pressao.Size = new System.Drawing.Size(836, 496);
            this.CHART_pressao.TabIndex = 47;
            this.CHART_pressao.Text = "CHART_pressao";
            this.CHART_pressao.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
            // 
            // BTN_Quit
            // 
            this.BTN_Quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Quit.Location = new System.Drawing.Point(1018, 512);
            this.BTN_Quit.Margin = new System.Windows.Forms.Padding(2);
            this.BTN_Quit.Name = "BTN_Quit";
            this.BTN_Quit.Size = new System.Drawing.Size(95, 55);
            this.BTN_Quit.TabIndex = 8;
            this.BTN_Quit.Text = "Sair";
            this.BTN_Quit.UseVisualStyleBackColor = true;
            this.BTN_Quit.Click += new System.EventHandler(this.btn_quit_Click);
            // 
            // CB_ComPorts
            // 
            this.CB_ComPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ComPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_ComPorts.FormattingEnabled = true;
            this.CB_ComPorts.Location = new System.Drawing.Point(39, 535);
            this.CB_ComPorts.Margin = new System.Windows.Forms.Padding(2);
            this.CB_ComPorts.Name = "CB_ComPorts";
            this.CB_ComPorts.Size = new System.Drawing.Size(97, 28);
            this.CB_ComPorts.TabIndex = 5;
            this.CB_ComPorts.Click += new System.EventHandler(this.CB_ComPorts_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabChart);
            this.tabControl1.Controls.Add(this.TabDataList);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1155, 599);
            this.tabControl1.TabIndex = 7;
            // 
            // AquisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1155, 599);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AquisForm";
            this.Text = "Transdutor Pressão";
            this.TabDataList.ResumeLayout(false);
            this.TabChart.ResumeLayout(false);
            this.TabChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TRACK_DP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TRACK_Membro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CHART_pressao)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage TabDataList;
        private System.Windows.Forms.ListView ListView_Dados;
        private System.Windows.Forms.TabPage TabChart;
        private System.Windows.Forms.Label LB_PortaCOM;
        private System.Windows.Forms.DataVisualization.Charting.Chart CHART_pressao;
        private System.Windows.Forms.Button BTN_Quit;
        private System.Windows.Forms.ComboBox CB_ComPorts;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label LB_DadosPaciente;
        private System.Windows.Forms.TextBox TB_Nome;
        private System.Windows.Forms.TrackBar TRACK_DP;
        private System.Windows.Forms.TrackBar TRACK_Membro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LB_EstagioDP;
        private System.Windows.Forms.CheckBox CB_Femea;
        private System.Windows.Forms.CheckBox CB_Macho;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_Massa;
        private System.Windows.Forms.TextBox TB_Estatura;
        private System.Windows.Forms.TextBox TB_Idade;
        private System.Windows.Forms.Label LB_valor_DP;
        private System.Windows.Forms.Button BTN_Iniciar;
        private System.Windows.Forms.TextBox TB_LeituraAtual;
        private System.Windows.Forms.TextBox TB_IMC;
        private System.Windows.Forms.Label LB_LeituraAtual;
        private System.Windows.Forms.ComboBox CB_Taquis;
        private System.Windows.Forms.Label LB_Taquis;
        private System.Windows.Forms.Button BTN_Cancelar;
        private System.Windows.Forms.Label lb_nome;
        private System.Windows.Forms.Label lb_sexo;
        private System.Windows.Forms.Label lb_idade;
        private System.Windows.Forms.Label lb_imc;
        private System.Windows.Forms.Label lb_massa;
        private System.Windows.Forms.Label lb_estatura;
    }
}


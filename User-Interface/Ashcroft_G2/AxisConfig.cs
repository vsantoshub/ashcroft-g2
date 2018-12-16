using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AshcroftApplication
{
    public partial class AxisConfig : Form
    {
        
        string[] parametros = new string[4];
        public AxisConfig()//(MainForm mainForm)
        {
            InitializeComponent();
            this.Text = "Configurações do gráfico";
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false) {
                if ((AquisForm.IsNumeric(textBox1.Text) == false) || ((textBox1.Text.Equals("") == false) && (Convert.ToDouble(textBox1.Text) < 0))) { parametros[0] = ""; }
                else { parametros[0] = textBox1.Text; } // Valor Máximo Axis X 
                if ((AquisForm.IsNumeric(textBox2.Text) == false) || ((this.textBox2.Text.Equals("") == false) && (Convert.ToDouble(this.textBox2.Text) < 0) )) { parametros[1] = ""; }
                else { parametros[1] = textBox2.Text; } // Valor Mínimo Axis X
                if ((AquisForm.IsNumeric(textBox3.Text) == false) || ((this.textBox3.Text.Equals("") == false) && (Convert.ToDouble(this.textBox3.Text) < 0))) { parametros[2] = ""; }
                else { parametros[2] = textBox3.Text; } // Valor Máximo Axis Y
                if ((AquisForm.IsNumeric(textBox4.Text) == false) || ((this.textBox4.Text.Equals("") == false) && (Convert.ToDouble(this.textBox4.Text) < 0))) { parametros[3] = ""; }
                else { parametros[3] = textBox4.Text; } // Valor Mínimo Axis Y
            }
            else { parametros[0] = "auto"; parametros[1] = "auto"; parametros[2] = "auto"; parametros[3] = "auto"; }        
            this.Close();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AxisConfig_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] parametros = { "", "", "", "" };
            this.Close();
        }


        public string[] Parametros { get { return parametros; } }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OglasnaTabla
{
    public partial class Fpodesavanje : Form
    {
        public int pocH;
        public int pocM;

        public int pocH1;
        public int pocM1;

        public int pocH2;
        public int pocM2;

        public bool redovan = true;

        public int trajanje;
        public int trajanje1;
        public int trajanje2;

        public Fpodesavanje()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                label6.Hide();
                label7.Hide();
                label8.Hide();
                label9.Hide();
                textBox1.Hide();
                textBox2.Hide();
                textBox3.Hide();
                textBox4.Hide();
                textBox5.Hide();
                textBox6.Hide();

            }
            else
            {
                label2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
                label6.Show();
                label7.Show();
                label8.Show();
                label9.Show();
                textBox1.Show();
                textBox2.Show();
                textBox3.Show();
                textBox4.Show();
                textBox5.Show();
                textBox6.Show();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                redovan = true;
                trajanje = 45;
            }
            else
            {
                redovan = false;
                pocH1 = int.Parse(textBox1.Text);
                pocM1 = int.Parse(textBox2.Text);
                trajanje1 = int.Parse(textBox3.Text);

                pocH2 = int.Parse(textBox6.Text);
                pocM2 = int.Parse(textBox5.Text);
                trajanje2 = int.Parse(textBox4.Text);
            }

        }
    }
}

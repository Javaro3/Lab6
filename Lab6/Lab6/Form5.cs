using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.theaters.CheckData(textBox1.Text) & Program.theaters.CheckData(textBox2.Text))
            {
                label1.Text = "Введите 1 дату";
                label2.Text = "Введите 2 дату";
                Program.theaters.ShowMaxKolByGener(textBox1.Text, textBox2.Text, label3);
                textBox1.Text = textBox2.Text = "";
            }
            else
            {
                label1.Text = "Даты не верны";
                label2.Text = "Даты не верны";
            }
        }
    }
}

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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.theaters.CheckData(textBox1.Text))
            {
                label1.Text = "Введите дату";
                Program.theaters.GetDataByDate(textBox1.Text, label2);
                textBox1.Text = "";
            }
            else
            {
                label1.Text = "Такой даты нет";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool CorrectData = CheckTextBox(Program.theaters.CheckData(textBox1.Text), "Введите дату", "Такой даты нет", label1) &
            CheckTextBox(Program.theaters.CheckKol(textBox2.Text), "Количество посещений", "Вы должны ввести число", label2) &
            CheckTextBox(Program.theaters.CheckGenre(textBox3.Text), "Укажите жанр", "Не должно содержать цифры", label3) &
            CheckTextBox(Program.theaters.CheckName(textBox4.Text), "Введите название", "Название не может быть пустым", label4);

            if (CorrectData)
            {
                Program.theaters.AddPerformance(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public bool CheckTextBox(bool check, string afterStr, string beforeStr, Label label)
        {
            if (check)
            {
                label.Text = afterStr;
            }
            else
            {
                label.Text = beforeStr;
            }
            return check;
        }
    }
}
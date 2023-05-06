using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormRecur : Form
    {
        int n, m;

        int fN0 = 0;
        int fN1 = 1;

        public FormRecur()
        {
            InitializeComponent();
        }

        
        private int Factorial(int n)
        {
            if (n == 1)
                return 1;
            return n * Factorial(n - 1);
        }

        private int Fib(int n)
        {
            if(n < 2)
                return n;
            return Fib(n - 1) + Fib(n - 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                n = int.Parse(textBox1.Text);
                if (n == 0)
                    textBox1.Text = "1";
                else if (n < 0)
                    MessageBox.Show("Введите неотрицательное число");
                else
                    textBox1.Text += "! = " + Factorial(n).ToString();
            }
            catch
            {
                MessageBox.Show("Некорректное значение");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                m = int.Parse(textBox2.Text);
                if (m == 0)
                    textBox2.Text = "1";
                else if (m < 0)
                    MessageBox.Show("Введите неотрицательное число");
                else
                    textBox2.Text += "(n) = " + Fib(m).ToString();
            }
            catch
            {
                MessageBox.Show("Некорректное значение");
            }
        }
    }
}

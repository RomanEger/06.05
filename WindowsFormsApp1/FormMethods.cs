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
    public partial class FormMethods : Form
    {
        int[] arr = new int[21];

        public FormMethods()
        {
            InitializeComponent();
        }

        private void FormMethods_Load(object sender, EventArgs e)
        {
            
            int j = -10;
            

            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = j++;
                textBox1.Text += $"{arr[i]} ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                    arr[i] = (int)Math.Pow(arr[i], 3);
                else
                    arr[i] *= arr[i];
                textBox1.Text += $"{arr[i]} ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox2.Text;
            str.Split(' ');

            bool isPal = true;

            int len;

            if (str.Length % 2 == 0)
            {
                len = str.Length;
            }
            else
                len = str.Length - 1;

            for(int i = 0; i < len/2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    isPal = false;
                    break;
                }
            }

            label3.Text += $"\n{str} - {isPal}";
        }
    }
}

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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormImage1 form= new FormImage1();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMethods form = new FormMethods();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormRecur form = new FormRecur();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormSort form = new FormSort();
            form.Show();
        }
    }
}

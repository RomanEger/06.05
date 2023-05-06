using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WindowsFormsApp1
{
    public partial class FormImage1 : Form
    {
        private Point PreviousPoint, point; 
        private Bitmap bmp;
        private Pen pen; 
        private Graphics g;
        int size = 4;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Черный")
                pen = new Pen(Color.Black, size);
            else if (comboBox1.SelectedItem.ToString() == "Красный")
                pen = new Pen(Color.Red, size);
            else if (comboBox1.SelectedItem.ToString() == "Белый")
                pen = new Pen(Color.White, size);
            else if (comboBox1.SelectedItem.ToString() == "Синий")
                pen = new Pen(Color.Blue, size);
            else if(comboBox1.SelectedItem.ToString() == "Зеленый")
                pen = new Pen(Color.Green, size);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                size = int.Parse(textBox1.Text);
                pen.Width = size; 
            }
            catch
            {
                size = 4;
            }
        }

        public FormImage1()
        {
            InitializeComponent();
        }
        private void FormImage1_Load(object sender, EventArgs e)
        {
            pen = new Pen(Color.Black, size);
        }
        
        //btnBack
        private void button1_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Close();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            PreviousPoint.X = e.X;
            PreviousPoint.Y = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                point.X = e.X; 

                point.Y = e.Y;

                g.DrawLine(pen, PreviousPoint, point);

                PreviousPoint.X = point.X;
                
                PreviousPoint.Y = point.Y;                

                pictureBox1.Invalidate();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            
            savedialog.OverwritePrompt = true; 
            savedialog.CheckPathExists = true; 
            savedialog.Filter = "Bitmap File(*.bmp)|*.bmp|GIF File(*.gif)|*.gif|JPEG File(*.jpg)|*.jpg|PNG File(*.png)|*.png";
            

            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = savedialog.FileName;

                string strFilExtn = fileName.Remove(0, fileName.Length - 3);
                
                switch (strFilExtn)
                {
                    case "bmp":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp); 
                        break;
                    case "jpg":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif); 
                        break;
                    case "tif":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }

                button3.Enabled = true;
            }

        }

        //btnRGB
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    int R = bmp.GetPixel(i, j).R;
                    
                    int G = bmp.GetPixel(i, j).G;
                    
                    int B = bmp.GetPixel(i, j).B;
                    
                    int Gray = (R + G + B) / 3;
                    

                    Color p = Color.FromArgb(255, Gray, Gray, Gray);
                    
                    bmp.SetPixel(i, j, p);
                }

            Refresh();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bmp.Width; i++)
                for(int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    bmp.SetPixel(i, j, Color.FromArgb(color.R, 0, 0));
                }

            Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    bmp.SetPixel(i, j, Color.FromArgb(0, color.G, 0));
                }

            Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = bmp.GetPixel(i, j);
                    bmp.SetPixel(i, j, Color.FromArgb(0, 0, color.B));
                }

            Refresh();
        }

        

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.PNG)|*.bmp;*.jpg;*.gif;*.png";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(dialog.FileName); 
                
                int height = image.Height; 
                
                int width = image.Width;
                                
                pictureBox1.Width = width; 
                
                pictureBox1.Height = height;

                bmp = new Bitmap(image, width, height);

                pictureBox1.Image = bmp;

                g = Graphics.FromImage(pictureBox1.Image);
            }
        }
    }
}

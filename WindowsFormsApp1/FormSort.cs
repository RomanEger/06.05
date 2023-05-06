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
    public partial class FormSort : Form
    {
        int[] arr = new int[100];
        Random r = new Random();

        public FormSort()
        {
            InitializeComponent();
            
        }

        public int BubbleSort()
        {
            int iteration = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                iteration++;
                for (int j = i+1; j < arr.Length; j++)
                {
                    iteration++;
                    if (arr[i] < arr[i+1])
                    {
                        int t = arr[i]; 
                        arr[i] = arr[j]; 
                        arr[j] = t;
                    }
                }
            }
            return iteration;
        }

        public int SelectionSort()
        {
            int iteration = 0;
            for (int i = 0; i < arr.Length-1; i++)
            {
                iteration++;
                int min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                        min = j;
                    iteration++;
                }
                if (min != i)
                {
                    int t = arr[i]; 
                    arr[i] = arr[min]; 
                    arr[min] = t;
                }
            }
            return iteration;
        }

        int iter = 0;

        void QuickSort(int[] arr, int Left, int Right, ref int iteration)
        {
            int i = Left; 
            int j = Right;

            int x = arr[(Left + Right) / 2]; 
            do
            {
                iteration++;
                while (arr[i] < x)
                {
                    ++i;
                    iteration++;
                }
                while (arr[j] > x)
                {
                    --j;
                    iteration++;
                }
                if (i <= j)
                {
                    int t = arr[i]; arr[i] = arr[j]; arr[j] = t;
                    i++;
                    j--;
                }

            } while (i <= j);
            if (Left < j)
                QuickSort(arr, Left, j, ref iter); 
            if (i < Right)
                QuickSort(arr, i, Right, ref iter);
        }

        int BinarySrc(int[] arr, int n)
        {
            int guess = 0;
            int low = 0;
            int high = arr.Length - 1;
            int mid = (low + high) / 2;
            while (low <= high)
            {
                mid = (low + high) / 2;
                guess = arr[mid];

                if (guess == n)
                    break;
                if (guess > n)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            if (guess != n)
                return -1;
            return mid;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            label1.Text = BubbleSort().ToString();
            label2.Text = SelectionSort().ToString();
            QuickSort(arr, arr[0], arr[arr.Length-1], ref iter);
            label3.Text = iter.ToString();

            textBox1.Text = string.Empty;
            for(int i = 0; i < arr.Length; i++)
            {
                textBox1.Text += arr[i].ToString() + " ";
            }
        }

        private void FormSort_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(100);
                textBox1.Text += arr[i].ToString() + " ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int guess = int.Parse(textBox2.Text);
                int res = BinarySrc(arr, guess);
                if (res < 0)
                    textBox2.Text = $"Число не найдено ({guess})";
                else
                    textBox2.Text = $"Число - {guess}, индекс - {res}";
                //textBox2.Text = $"Число - {guess}, индекс - {n}";
            }
            catch
            {
                MessageBox.Show("Введите число!");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovui_proekt
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void швидкеСортуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            info4 info4 = new info4();
            info4.Show();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox6.BackColor = Color.White;
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox6.BackColor = Color.White;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int N, rand, a, b;
            int.TryParse(textBox1.Text, out N);
            int.TryParse(textBox2.Text, out a);
            int.TryParse(textBox3.Text, out b);
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty)
            {
                textBox6.Text = "Введіть всі значення!";
                textBox6.BackColor = Color.Red;
            }
            else if (N <= 0 || N >= 21)
            {
                textBox6.Text = "Введіть розмір від 1 до 20!";
                textBox6.BackColor = Color.Red;
            }
            else if (a < -100 || a > 0)
            {
                textBox6.Text = "Введіть мінімальне число від -100 до 0!";
                textBox6.BackColor = Color.Red;
            }
            else if (b > 100 || b < 0)
            {
                textBox6.Text = "Введіть максимальне число від 0 до 100!";
                textBox6.BackColor = Color.Red;
            }
            else if (a >= 0 && b <= 1 || a >= -1 && b <= 0 || a >= 0 && b <= 0)
            {
                textBox6.Text = "Введіть більший діапазон мінімальних та максимальних чисел!";
                textBox6.BackColor = Color.Red;
            }
            else
            {
                button1.Enabled = false;
                textBox6.BackColor = Color.Green;
                textBox6.Text = "Програма виконана!";
                int[] A = new int[N];
                Random random = new Random();
                for (int i = 0; i < N; i++)
                {
                    rand = random.Next(a, b);
                    A[i] = rand;
                    textBox4.Text += A[i].ToString() + "\r ";
                }
                int[] sortedArray = Quicksort(A, 0, N - 1);
                for (int i = 0; i < N; i++)
                {
                    textBox5.Text = textBox5.Text + " " + A[i].ToString();
                }
            }
        }

        private static int[] Quicksort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex>=maxIndex)
            {
                return array;
            }
            int v = getV(array, minIndex, maxIndex);
            Quicksort(array, minIndex, v - 1);
            Quicksort(array, v + 1, maxIndex);
            return array;
        }

        private static int getV(int[] array, int minIndex, int maxIndex)
        {
            int v = minIndex -1 ;
            for (int i = minIndex; i <= maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    v++;
                    Swap(ref array[v], ref array[i]); 
                }
            }
            v++;
            Swap(ref array[v], ref array[maxIndex]);
            return v;
        }

        private static void Swap(ref int leftI, ref int rightI)
        {
            int temp = leftI;
            leftI = rightI;
            rightI = temp;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 46 || e.KeyChar >= 58) && number != 8 && number != 45)
            {
                e.Handled = true;
            }
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

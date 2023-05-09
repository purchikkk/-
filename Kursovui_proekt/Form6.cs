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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void сортуванняЗлиттямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            info5 info5 = new info5();
            info5.Show();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
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
                MergeSort(A);
                for (int i = 0; i < N; i++)
                {
                    textBox5.Text = textBox5.Text + " " + A[i].ToString();
                }
            }
        }
        static void Merge(int[] targetArray, int[] array1, int[] array2)
        {
            int array1minindex = 0;
            int array2minindex = 0;
            int targetarrayminindex = 0;
            while (array1minindex < array1.Length && array2minindex < array2.Length)
            {
                if (array1[array1minindex] <= array2[array2minindex])
                {
                    targetArray[targetarrayminindex] = array1[array1minindex];
                    array1minindex++;
                }
                else
                {
                    targetArray[targetarrayminindex] = array2[array2minindex];
                    array2minindex++;
                }
                targetarrayminindex++;
            }
            while (array1minindex < array1.Length)
            {
                targetArray[targetarrayminindex] = array1[array1minindex];
                array1minindex++;
                targetarrayminindex++;
            }
            while (array2minindex < array2.Length)
            {
                targetArray[targetarrayminindex] = array2[array2minindex];
                array2minindex++;
                targetarrayminindex++;
            }
        }
        static void MergeSort(int[] array)
        {
            if (array.Length < 2)
            {
                return;
            }
            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length-mid];
            for (int i = 0; i < mid; i++)
            {
                left[i] = array[i];
            }
            for (int i = mid; i < array.Length; i++)
            {
                right[i-mid] = array[i];
            }
            MergeSort(left);
            MergeSort(right);
            Merge(array, left, right);
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
        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox6.BackColor = Color.White;
            button1.Enabled = true;
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

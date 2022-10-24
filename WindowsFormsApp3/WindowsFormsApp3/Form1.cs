using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public int[] _Plus(int[] b_1, int[] b_2) 
        {
            int[] b_3 = new int[b_1.Length];

            for (int i = b_1.Length - 1; i >=0 ; i--) 
            {
                b_3[i] = b_3[i] + b_1[i] + b_2[i];

                if (b_3[i] == 2)
                {
                    b_3[i] = 0;
                    b_3[i - 1] += 1;
                }
                else if (b_3[i] == 3) 
                {
                    b_3[i] = 1;
                    b_3[i - 1] += 1;
                } 
            }

            return b_3;
        }
        public int[] _ConvertToInt(string s) 
        {
            return s.ToCharArray().Select(i => int.Parse(i.ToString())).ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str_1 = textBox1.Text;
            string str_2 = textBox2.Text;
            int maxel = str_1.Length + str_1.Length;
            string[] um = new string[str_2.Length];
            int k = 0;

            for (int i = str_2.Length - 1; i >= 0; i--)
            {
                if (str_2[i] == '1')
                {
                    um[i] = str_1;
                }

                if (str_2[i] == '0')
                {
                    for (int j = 0; j < str_1.Length; j++)
                    {
                        um[i] += "0";
                    }
                }

                for (int j = 0; j < k; j++)
                {
                    um[i] = um[i] + "0";
                }
                k++;

                for (int j = um[i].Length; j < maxel;j++)
                {
                    um[i] = "0" + um[i];
                }
            }

            int[] a = _ConvertToInt(um[0]);
            int[] b = new int[maxel];

            for (int i = 1; i < str_2.Length; i++) 
            {
                b = _ConvertToInt(um[i]);
                a = _Plus(a, b);
            }

            string result_1 = "";

            for (int i = a.Length - 1; i >= 0; i--) 
            {
                result_1 = Convert.ToString(a[i]) + result_1;
            }

            string result_2 = result_1;
            for (int i = 0; i < a.Length; i++) 
            {
                if (result_1[i] == '0')
                {
                    result_2 = result_2.Remove(0,1);
                }
                else 
                {
                    break;
                }
            }

            richTextBox1.Text = result_2;

               

        }
    }
}

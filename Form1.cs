using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace devoir_c_char
{
    public partial class Form1 : Form
    {
        List<nodex> list1;
        List<nodex> list2;
        int maxchar = 10;
        int[] a;
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            string[] a = textBox1.Text.Split(';');
            int n = a.Length;
            list1 = new List<nodex>();
            list2 = new List<nodex>();
            for (int i = 0; i < n; i++)
            {
                string[] b = a[i].Split(' ');
                nodex curnode = new nodex(Convert.ToChar(b[0]), Convert.ToDouble(b[1]));
                list1.Add(curnode);
                list2.Add(curnode);
            }
            list1.Sort(delegate(nodex x, nodex y)
            {
                return x.val.CompareTo(y.val);
            });
            huffmantree();
            huffmancode();
            showhuffmancode();
        }

        private void showhuffmancode()
        {
            textBox2.Text = "";
            // avg
            int sumx = 0;
            for (int i = 0; i < list2.Count; i++)
            {
                textBox2.Text = textBox2.Text + list2[i].c.ToString() + " -> " + list2[i].code + Environment.NewLine;
                sumx = sumx + (list2[i].code.Length * a[i]);
            }

        }

        private void huffmancode()
        {
            for (int i = 0; i < list2.Count; i++)
            {

                nodex curnode = list2[i];
                nodex prevnode = null;
                string str1 = "";
                while (curnode != null)
                {
                    prevnode = curnode;
                    curnode = curnode.parent;
                    if (curnode != null)
                    {
                        if (curnode.lc == prevnode)
                        {
                            str1 = str1 + "0";
                        }
                        else
                        {
                            str1 = str1 + "1";
                        }
                    }
                }
                str1 = ReverseStringDirect(str1);
                list2[i].code = str1;
            }
        }

        public static string ReverseStringDirect(string s)
        {
            char[] array = new char[s.Length];
            int forward = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                array[forward++] = s[i];
            }
            return new string(array);
        }

        private void huffmantree()
        {
            while (list1.Count > 1)
            {
                nodex cur1;
                nodex cur2;
                cur1 = list1[0];
                cur2 = list1[1];
                nodex root = new nodex(' ', cur1.val + cur2.val);
                root.lc = cur1;
                root.rc = cur2;
                cur1.parent = root;
                cur2.parent = root;
                list1.RemoveAt(0);
                list1.RemoveAt(0);
                list1.Add(root);
                list1.Sort(delegate(nodex x, nodex y)
                {
                    return x.val.CompareTo(y.val);
                });
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void countallchar(string str1)
        {
            textBox1.Text = "";
            int n = str1.Length;
            int startchar = 65;
            int m;
            a = new int[maxchar];
            for (int i = 0; i < n; i++)
            {
                m = Convert.ToInt32(str1[i]) - startchar;
                a[m]++;
            }
            for (int i = 0; i < maxchar; i++)
            {
                if (a[i] > 0)
                {
                    textBox1.Text = textBox1.Text + Convert.ToChar(i + startchar) + " " + a[i].ToString() + ";";
                }
            }
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string str1 = "";
            Random x = new Random();
            for (int i = 0; i < 100; i++)
            {
                str1 = str1 + Convert.ToChar(x.Next(67) % maxchar + 65);
            }
            textBox6.Text = str1;
            countallchar(str1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        
    }

    public class nodex
    {
        public char c;
        public double val;
        public string code = "";
        public nodex lc = null;
        public nodex rc = null;
        public nodex parent = null;
        public nodex(char a, double b)
        {
            c = a;
            val = b;
        }
    }
}

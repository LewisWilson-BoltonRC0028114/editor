using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace editor
{
    public partial class Form1 : Form
    {
        bool file_opened = false;
        string filemname;
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text Files|*.txt";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(@"H:\test.txt"))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            richTextBox1.AppendText(line + "\n");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(openFileDialog1.FileName + " failed to open.");
                }
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text Files|*.txt";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                    {
                        richTextBox1.Clear();
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            richTextBox1.AppendText(line + "\n");
                        }
                    }
                    filename = openFileDialog1.FileName;
                    file_opened = true;
                }
                catch
                {
                    MessageBox.Show(openFileDialog1.FileName + " failed to open.");
                }
            }
        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Text Files|*.txt";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(@"H:\test.txt"))
                    {
                        sw.Write(richTextBox1.Text);
                    }
                }
                catch
                {
                    MessageBox.Show(openFileDialog1.FileName + " failed to open.");
                }
            }
        }

    }

}



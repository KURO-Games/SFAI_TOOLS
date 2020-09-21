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

namespace CSV_to_Binary
{
    public partial class Form1 : Form
    {
        StreamReader sr;
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Scenario Files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.Title = "Open Scenario Files";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                FilePass.Text = openFileDialog1.FileName;
            }
        }

        private void FilePass_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangeFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "新しいファイル.sc";
            saveFileDialog1.Filter = "Scenario Files (*.sc)|*.sc|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save Scenario Files";
            if (FilePass.Text.ToString() == "") return;
            string readText = File.ReadAllText(@FilePass.Text);
            if (readText.ToString() == "") return;
            byte[] data = System.Text.Encoding.UTF8.GetBytes(readText);
            string whiteText = "";
            for (int i = 0; data.Length > i; i++)
            {
                whiteText += data[i];
                if (i != data.Length - 1)
                {
                    whiteText += ",";
                }
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
            }
            if (saveFileDialog1.FileName.ToString() == "") return;
            FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            sw.Write(whiteText);

            sw.Close();
            fs.Close();
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}

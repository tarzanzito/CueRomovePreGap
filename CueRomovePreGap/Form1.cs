using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CueRomovePreGap
{
    public partial class Form1 : Form
    {
        private readonly string outFile = "Corrected.cue";

        public Form1(string[] args)
        {
            InitializeComponent();

            textBoxMsg1.BorderStyle = BorderStyle.None;
            textBoxMsg2.BorderStyle = BorderStyle.None;

            if (args.Length == 1)
                if (IsCueExtension(args[0]))
                    textBoxCueFile.Text = args[0];
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form1_DragDrop");

            string file = ValidFile(e);
            if (file == null)
                return;

            Console.WriteLine(file);
            this.textBoxCueFile.Text = file;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string file = ValidFile(e);
                if (file != null)
                    e.Effect = DragDropEffects.Copy;

            }

            System.Diagnostics.Debug.WriteLine("Form1_DragEnter");
        }

        private void Form1_DragLeave(object sender, EventArgs e)
        {
            //quando sai e nao faz drop (quando desiste)
            //System.Diagnostics.Debug.WriteLine("Form1_DragLeave");
        }

        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            //quando and por dentro do objecto
            //System.Diagnostics.Debug.WriteLine("Form1_DragOver");
        }

        private void Form1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            // System.Diagnostics.Debug.WriteLine("Form1_GiveFeedback");
        }

        private void Form1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("Form1_QueryContinueDrag");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeFields();
        }

        private void ButtonCorrect_Click(object sender, EventArgs e)
        {
            textBoxMsg1.Text = "";
            textBoxMsg2.Text = "";

            //read
            List<string> list = new List<string>();
            String line;
            try
            {
                StreamReader streamReader = new StreamReader(textBoxCueFile.Text);
                line = streamReader.ReadLine();
                while (line != null)
                {
                    list.Add(line);
                    line = streamReader.ReadLine();
                }
                streamReader.Close();
            }
            catch (Exception ex)
            {
                textBoxMsg1.Text = "Error:" + ex.Message;
                return;
            }

            //process
            try
            {
                int count = list.Count;
                for (int inx = 0; inx < count; inx++)
                {
                    if (String.IsNullOrEmpty(list[inx]))
                        continue;

                    if (list[inx].Contains("INDEX 00"))
                    {
                        list[inx] = list[inx].Replace("INDEX 00", "INDEX 01");
                        list[inx + 1] = null;
                    }
                }
            }
            catch (Exception ex)
            {
                textBoxMsg1.Text = "Error:" + ex.Message;
                return;
            }

            //write
            string newFile;
            try
            {
                string dir = Path.GetDirectoryName(textBoxCueFile.Text);
                newFile = Path.Combine(dir, outFile);

                StreamWriter streamWriter = new StreamWriter(newFile);
                foreach (string nline in list)
                {
                    if (!String.IsNullOrEmpty(nline))
                        streamWriter.WriteLine(nline);
                }

                streamWriter.Flush();
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                textBoxMsg1.Text = "Error:" + ex.Message;
                return;
            }

            textBoxMsg1.Text = "New File 'Corrected.cue' Created At:";
            textBoxMsg2.Text = newFile;

            buttonOpenDirectory.Enabled = true;
        }

        private void ButtonSelectFile_Click(object sender, EventArgs e)
        {
            textBoxCueFile.Text = "";

            OpenFileDialog dlg = new OpenFileDialog();

            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "cue files (*.cue)|*.cue";
            dlg.RestoreDirectory = false;
            dlg.Title = "Select CUE file.";
            dlg.Multiselect = false;
            dlg.SupportMultiDottedExtensions = false;

            DialogResult result = dlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxCueFile.Text = dlg.FileName;
            }
        }

        private void TextBoxCueFile_TextChanged(object sender, EventArgs e)
        {
            buttonCorrect.Enabled = (textBoxCueFile.TextLength > 0);
            buttonOpenDirectory.Enabled = false;
            textBoxMsg1.Text = "";
            textBoxMsg2.Text = "";
        }

        private void ButtonOpenDirectory_Click(object sender, EventArgs e)
        {
            string dir = Path.GetDirectoryName(textBoxCueFile.Text);
            string newFile = Path.Combine(dir, outFile);

            if (Directory.Exists(dir))
            {
                string cmd = "explorer.exe";
                string arg = "/select, " + newFile;
                Process.Start(cmd, arg);
            }
        }

        private void InitializeFields()
        {
            textBoxCueFile.Text = "";
            buttonCorrect.Enabled = false;
            textBoxMsg1.Text = "";
            textBoxMsg2.Text = "";
            buttonOpenDirectory.Enabled = false;
        }

        private string ValidFile(DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length != 1)
                return null;

            if (!IsCueExtension(files[0]))
                return null;

            return files[0];
        }

        private bool IsCueExtension(string data)
        {
            string extension = System.IO.Path.GetExtension(data);
            return (extension.ToUpper() == ".CUE");
        }

    }
}

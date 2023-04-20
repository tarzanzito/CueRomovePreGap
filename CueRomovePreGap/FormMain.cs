using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;


namespace CueRomovePreGap
{
    public partial class FormMain : Form
    {
        private const string DefaultOutputFileName = "_Corrected.cue";

        private ProcessFile _processFile;

        public FormMain(string[] args)
        {
            InitializeComponent();

            textBoxMsg1.BorderStyle = BorderStyle.None;
            textBoxMsg2.BorderStyle = BorderStyle.None;
            textBoxMsg3.BorderStyle = BorderStyle.None;
            buttonOpenDirectory.Visible = false;

            if (args.Length == 1)
                if (IsCueExtension(args[0]))
                    textBoxCueFile.Text = args[0];

            _processFile = new ProcessFile();
         }

        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("Form1_DragDrop");

            string file = ValidFile(e);

            if (String.IsNullOrEmpty(file))
                this.textBoxCueFile.Text = String.Empty;
            else
            {
                this.textBoxCueFile.Text = file;
                if (checkBoxAutoRun.Checked)
                    ButtonProcess_Click(sender, null);
            }
            
            //System.Diagnostics.Debug.WriteLine(file);
        }

        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string file = ValidFile(e);
                if (file != null)
                    e.Effect = DragDropEffects.Copy;

            }

            //System.Diagnostics.Debug.WriteLine("Form1_DragEnter");
        }

        private void FormMain_DragLeave(object sender, EventArgs e)
        {
            //when you leave and do not drop(give up)
            //System.Diagnostics.Debug.WriteLine("Form1_DragLeave");
        }

        private void FormMain_DragOver(object sender, DragEventArgs e)
        {
            //when the mouse "walks" inside the object
            //System.Diagnostics.Debug.WriteLine("Form1_DragOver");
        }

        private void FormMain_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form1_GiveFeedback");
        }

        private void FormMain_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form1_QueryContinueDrag");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitializeFields();

            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Text = $"{Text} - Version: {version}";

#if DEBUG
            textBoxCueFile.Text = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"..\..", @"Resources\ExampleWithSubIndexs.cue");
#endif
        }

        private void ButtonProcess_Click(object sender, EventArgs e)
        {
            ClearMessages();

            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            try
            {
                var input = new ProcessFileInput()
                {
                    FullFileName = textBoxCueFile.Text,
                    NewFileName = DefaultOutputFileName,
                    RemoveSubIndexes = checkBoxRemoveSubIndexes.Checked
                };

                var output = _processFile.Execute(input);

                textBoxMsg1.Text = $"Total Tracks: [{output.TrackCount}], Total PreGap found: [{output.ChangeCount}].";
                textBoxMsg2.Text = $"New File '{DefaultOutputFileName}' Created At:";
                textBoxMsg3.Text = output.NewFullFileName;
                buttonOpenDirectory.Visible = true;
            }
            catch (Exception ex)
            {
                //textBoxMsg1.Text = "Error:" + ex.Message;
                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            buttonOpenDirectory.Enabled = true;
            Cursor = Cursors.Default;
            Application.DoEvents();
        }

        private void ButtonSelectFile_Click(object sender, EventArgs e)
        {
            textBoxCueFile.Text = String.Empty;

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
            buttonProcess.Enabled = (textBoxCueFile.TextLength > 0);
            buttonOpenDirectory.Enabled = false;
            ClearMessages();

        }

        private void ButtonOpenDirectory_Click(object sender, EventArgs e)
        {
            string dir = Path.GetDirectoryName(textBoxCueFile.Text);
            string newFile = Path.Combine(dir, DefaultOutputFileName);

            if (Directory.Exists(dir))
            {
                string cmd = "explorer.exe";
                string arg = "/select, " + newFile;
                Process.Start(cmd, arg);
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearMessages()
        {
            textBoxMsg1.Text = String.Empty;
            textBoxMsg2.Text = String.Empty;
            textBoxMsg3.Text = String.Empty;

            buttonOpenDirectory.Visible = false;
        }

        private void InitializeFields()
        {
            textBoxCueFile.Text = String.Empty;
            ClearMessages();
            buttonProcess.Enabled = false;

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

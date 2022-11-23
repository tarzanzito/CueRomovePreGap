namespace CueRomovePreGap
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCueFile = new System.Windows.Forms.TextBox();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.textBoxMsg1 = new System.Windows.Forms.TextBox();
            this.textBoxMsg3 = new System.Windows.Forms.TextBox();
            this.buttonOpenDirectory = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.textBoxMsg2 = new System.Windows.Forms.TextBox();
            this.checkBoxAutoRun = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "CUE File:";
            // 
            // textBoxCueFile
            // 
            this.textBoxCueFile.Location = new System.Drawing.Point(79, 15);
            this.textBoxCueFile.Name = "textBoxCueFile";
            this.textBoxCueFile.Size = new System.Drawing.Size(629, 20);
            this.textBoxCueFile.TabIndex = 2;
            this.textBoxCueFile.TextChanged += new System.EventHandler(this.TextBoxCueFile_TextChanged);
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(714, 13);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(30, 23);
            this.buttonSelectFile.TabIndex = 3;
            this.buttonSelectFile.Text = "...";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.ButtonSelectFile_Click);
            // 
            // buttonProcess
            // 
            this.buttonProcess.Enabled = false;
            this.buttonProcess.Location = new System.Drawing.Point(750, 13);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(61, 23);
            this.buttonProcess.TabIndex = 4;
            this.buttonProcess.Text = "&Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.ButtonProcess_Click);
            // 
            // textBoxMsg1
            // 
            this.textBoxMsg1.Location = new System.Drawing.Point(12, 51);
            this.textBoxMsg1.Name = "textBoxMsg1";
            this.textBoxMsg1.ReadOnly = true;
            this.textBoxMsg1.Size = new System.Drawing.Size(526, 20);
            this.textBoxMsg1.TabIndex = 5;
            // 
            // textBoxMsg3
            // 
            this.textBoxMsg3.Location = new System.Drawing.Point(12, 103);
            this.textBoxMsg3.Name = "textBoxMsg3";
            this.textBoxMsg3.ReadOnly = true;
            this.textBoxMsg3.Size = new System.Drawing.Size(696, 20);
            this.textBoxMsg3.TabIndex = 6;
            // 
            // buttonOpenDirectory
            // 
            this.buttonOpenDirectory.Enabled = false;
            this.buttonOpenDirectory.Location = new System.Drawing.Point(714, 102);
            this.buttonOpenDirectory.Name = "buttonOpenDirectory";
            this.buttonOpenDirectory.Size = new System.Drawing.Size(30, 23);
            this.buttonOpenDirectory.TabIndex = 7;
            this.buttonOpenDirectory.Text = "...";
            this.buttonOpenDirectory.UseVisualStyleBackColor = true;
            this.buttonOpenDirectory.Click += new System.EventHandler(this.ButtonOpenDirectory_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonExit.Location = new System.Drawing.Point(750, 49);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(61, 23);
            this.buttonExit.TabIndex = 8;
            this.buttonExit.Text = "&Close";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // textBoxMsg2
            // 
            this.textBoxMsg2.Location = new System.Drawing.Point(12, 77);
            this.textBoxMsg2.Name = "textBoxMsg2";
            this.textBoxMsg2.ReadOnly = true;
            this.textBoxMsg2.Size = new System.Drawing.Size(526, 20);
            this.textBoxMsg2.TabIndex = 9;
            // 
            // checkBoxAutoRun
            // 
            this.checkBoxAutoRun.AutoSize = true;
            this.checkBoxAutoRun.Location = new System.Drawing.Point(581, 53);
            this.checkBoxAutoRun.Name = "checkBoxAutoRun";
            this.checkBoxAutoRun.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxAutoRun.Size = new System.Drawing.Size(127, 17);
            this.checkBoxAutoRun.TabIndex = 10;
            this.checkBoxAutoRun.Text = "Run After \'Drag Drop\'";
            this.checkBoxAutoRun.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonProcess;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonExit;
            this.ClientSize = new System.Drawing.Size(826, 134);
            this.Controls.Add(this.checkBoxAutoRun);
            this.Controls.Add(this.textBoxMsg2);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonOpenDirectory);
            this.Controls.Add(this.textBoxMsg3);
            this.Controls.Add(this.textBoxMsg1);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.textBoxCueFile);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remove \'PreGap\' from Cue File";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Form1_DragOver);
            this.DragLeave += new System.EventHandler(this.Form1_DragLeave);
            this.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Form1_GiveFeedback);
            this.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.Form1_QueryContinueDrag);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCueFile;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.TextBox textBoxMsg1;
        private System.Windows.Forms.TextBox textBoxMsg3;
        private System.Windows.Forms.Button buttonOpenDirectory;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBoxMsg2;
        private System.Windows.Forms.CheckBox checkBoxAutoRun;
    }
}


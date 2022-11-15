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
            this.buttonCorrect = new System.Windows.Forms.Button();
            this.textBoxMsg1 = new System.Windows.Forms.TextBox();
            this.textBoxMsg2 = new System.Windows.Forms.TextBox();
            this.buttonOpenDirectory = new System.Windows.Forms.Button();
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
            // buttonCorrect
            // 
            this.buttonCorrect.Enabled = false;
            this.buttonCorrect.Location = new System.Drawing.Point(750, 13);
            this.buttonCorrect.Name = "buttonCorrect";
            this.buttonCorrect.Size = new System.Drawing.Size(61, 23);
            this.buttonCorrect.TabIndex = 4;
            this.buttonCorrect.Text = "Correct";
            this.buttonCorrect.UseVisualStyleBackColor = true;
            this.buttonCorrect.Click += new System.EventHandler(this.ButtonCorrect_Click);
            // 
            // textBoxMsg1
            // 
            this.textBoxMsg1.Location = new System.Drawing.Point(12, 51);
            this.textBoxMsg1.Name = "textBoxMsg1";
            this.textBoxMsg1.ReadOnly = true;
            this.textBoxMsg1.Size = new System.Drawing.Size(696, 20);
            this.textBoxMsg1.TabIndex = 5;
            // 
            // textBoxMsg2
            // 
            this.textBoxMsg2.Location = new System.Drawing.Point(12, 77);
            this.textBoxMsg2.Name = "textBoxMsg2";
            this.textBoxMsg2.ReadOnly = true;
            this.textBoxMsg2.Size = new System.Drawing.Size(696, 20);
            this.textBoxMsg2.TabIndex = 6;
            // 
            // buttonOpenDirectory
            // 
            this.buttonOpenDirectory.Enabled = false;
            this.buttonOpenDirectory.Location = new System.Drawing.Point(714, 76);
            this.buttonOpenDirectory.Name = "buttonOpenDirectory";
            this.buttonOpenDirectory.Size = new System.Drawing.Size(30, 23);
            this.buttonOpenDirectory.TabIndex = 7;
            this.buttonOpenDirectory.Text = "...";
            this.buttonOpenDirectory.UseVisualStyleBackColor = true;
            this.buttonOpenDirectory.Click += new System.EventHandler(this.ButtonOpenDirectory_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 111);
            this.Controls.Add(this.buttonOpenDirectory);
            this.Controls.Add(this.textBoxMsg2);
            this.Controls.Add(this.textBoxMsg1);
            this.Controls.Add(this.buttonCorrect);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.textBoxCueFile);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Romove \'PreGap\' from Cue File";
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
        private System.Windows.Forms.Button buttonCorrect;
        private System.Windows.Forms.TextBox textBoxMsg1;
        private System.Windows.Forms.TextBox textBoxMsg2;
        private System.Windows.Forms.Button buttonOpenDirectory;
    }
}


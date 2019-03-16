namespace Lab2
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
            this.startConnectionBtn = new System.Windows.Forms.Button();
            this.stopConnectionBtn = new System.Windows.Forms.Button();
            this.currentPortInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.chooseFolderBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.currentPortLabel = new System.Windows.Forms.Label();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startConnectionBtn
            // 
            this.startConnectionBtn.Location = new System.Drawing.Point(17, 137);
            this.startConnectionBtn.Name = "startConnectionBtn";
            this.startConnectionBtn.Size = new System.Drawing.Size(80, 27);
            this.startConnectionBtn.TabIndex = 2;
            this.startConnectionBtn.Text = "Start";
            this.startConnectionBtn.UseVisualStyleBackColor = true;
            this.startConnectionBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // stopConnectionBtn
            // 
            this.stopConnectionBtn.Location = new System.Drawing.Point(406, 137);
            this.stopConnectionBtn.Name = "stopConnectionBtn";
            this.stopConnectionBtn.Size = new System.Drawing.Size(75, 27);
            this.stopConnectionBtn.TabIndex = 3;
            this.stopConnectionBtn.Text = "Stop";
            this.stopConnectionBtn.UseVisualStyleBackColor = true;
            this.stopConnectionBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // currentPortInput
            // 
            this.currentPortInput.Location = new System.Drawing.Point(387, 57);
            this.currentPortInput.Name = "currentPortInput";
            this.currentPortInput.Size = new System.Drawing.Size(105, 22);
            this.currentPortInput.TabIndex = 4;
            this.currentPortInput.Text = "0";
            this.currentPortInput.TextChanged += new System.EventHandler(this.currentPortInput_OnChangeValue);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Default port: 8000";
            // 
            // chooseFolderBtn
            // 
            this.chooseFolderBtn.Location = new System.Drawing.Point(382, 154);
            this.chooseFolderBtn.Name = "chooseFolderBtn";
            this.chooseFolderBtn.Size = new System.Drawing.Size(110, 29);
            this.chooseFolderBtn.TabIndex = 6;
            this.chooseFolderBtn.Text = "Choose folder";
            this.chooseFolderBtn.UseVisualStyleBackColor = true;
            this.chooseFolderBtn.Click += new System.EventHandler(this.chooseFolderBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "File path:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Workstation number";
            // 
            // currentPortLabel
            // 
            this.currentPortLabel.AutoSize = true;
            this.currentPortLabel.Location = new System.Drawing.Point(49, 71);
            this.currentPortLabel.Name = "currentPortLabel";
            this.currentPortLabel.Size = new System.Drawing.Size(124, 17);
            this.currentPortLabel.TabIndex = 9;
            this.currentPortLabel.Text = "Current port: 8000";
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Location = new System.Drawing.Point(121, 149);
            this.filePathLabel.MaximumSize = new System.Drawing.Size(300, 0);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(222, 34);
            this.filePathLabel.TabIndex = 10;
            this.filePathLabel.Text = "C:\\Paulina\\Studia\\CSharp\\CSharp Lab2\\Lab2\\Lab2\\bin\\Debug";
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.Red;
            this.statusBar.ForeColor = System.Drawing.Color.Lime;
            this.statusBar.Location = new System.Drawing.Point(72, 72);
            this.statusBar.Maximum = 1000;
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(326, 23);
            this.statusBar.Step = 1;
            this.statusBar.TabIndex = 11;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel.Location = new System.Drawing.Point(69, 52);
            this.statusLabel.MinimumSize = new System.Drawing.Size(336, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(336, 17);
            this.statusLabel.TabIndex = 12;
            this.statusLabel.Text = "Server status: Not Active";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statusBar);
            this.groupBox1.Controls.Add(this.statusLabel);
            this.groupBox1.Controls.Add(this.stopConnectionBtn);
            this.groupBox1.Controls.Add(this.startConnectionBtn);
            this.groupBox1.Location = new System.Drawing.Point(52, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 179);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 425);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.currentPortLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chooseFolderBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentPortInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TextChanged += new System.EventHandler(this.currentPortInput_OnChangeValue);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startConnectionBtn;
        private System.Windows.Forms.Button stopConnectionBtn;
        private System.Windows.Forms.TextBox currentPortInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button chooseFolderBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label currentPortLabel;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.ProgressBar statusBar;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}


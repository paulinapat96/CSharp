namespace CSharp_Lab4
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
            this.paintingBoard = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolPenBtn = new System.Windows.Forms.Button();
            this.toolEreaserBtn = new System.Windows.Forms.Button();
            this.toolLineBtn = new System.Windows.Forms.Button();
            this.toolRectangleBtn = new System.Windows.Forms.Button();
            this.toolEllipseBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // paintingBoard
            // 
            this.paintingBoard.BackColor = System.Drawing.Color.White;
            this.paintingBoard.Location = new System.Drawing.Point(12, 12);
            this.paintingBoard.Name = "paintingBoard";
            this.paintingBoard.Size = new System.Drawing.Size(688, 426);
            this.paintingBoard.TabIndex = 0;
            this.paintingBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paintingBoard_MouseDown);
            this.paintingBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paintingBoard_MouseMove);
            this.paintingBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.paintingBoard_MouseUp);
            // 
            // colorBtn
            // 
            this.colorBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.colorBtn.Location = new System.Drawing.Point(714, 415);
            this.colorBtn.Name = "colorBtn";
            this.colorBtn.Size = new System.Drawing.Size(75, 23);
            this.colorBtn.TabIndex = 1;
            this.colorBtn.UseVisualStyleBackColor = false;
            this.colorBtn.Click += new System.EventHandler(this.colorBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(714, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Set color";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toolPenBtn
            // 
            this.toolPenBtn.BackColor = System.Drawing.Color.Black;
            this.toolPenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolPenBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolPenBtn.Location = new System.Drawing.Point(706, 29);
            this.toolPenBtn.Name = "toolPenBtn";
            this.toolPenBtn.Size = new System.Drawing.Size(89, 33);
            this.toolPenBtn.TabIndex = 1;
            this.toolPenBtn.Text = "Pen";
            this.toolPenBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolPenBtn.UseVisualStyleBackColor = false;
            // 
            // toolEreaserBtn
            // 
            this.toolEreaserBtn.BackColor = System.Drawing.Color.Black;
            this.toolEreaserBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolEreaserBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolEreaserBtn.Location = new System.Drawing.Point(706, 68);
            this.toolEreaserBtn.Name = "toolEreaserBtn";
            this.toolEreaserBtn.Size = new System.Drawing.Size(89, 33);
            this.toolEreaserBtn.TabIndex = 4;
            this.toolEreaserBtn.Text = "Ereaser";
            this.toolEreaserBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolEreaserBtn.UseVisualStyleBackColor = false;
            // 
            // toolLineBtn
            // 
            this.toolLineBtn.BackColor = System.Drawing.Color.Black;
            this.toolLineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolLineBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolLineBtn.Location = new System.Drawing.Point(706, 107);
            this.toolLineBtn.Name = "toolLineBtn";
            this.toolLineBtn.Size = new System.Drawing.Size(89, 33);
            this.toolLineBtn.TabIndex = 5;
            this.toolLineBtn.Text = "Line";
            this.toolLineBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolLineBtn.UseVisualStyleBackColor = false;
            // 
            // toolRectangleBtn
            // 
            this.toolRectangleBtn.BackColor = System.Drawing.Color.Black;
            this.toolRectangleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolRectangleBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolRectangleBtn.Location = new System.Drawing.Point(707, 185);
            this.toolRectangleBtn.Name = "toolRectangleBtn";
            this.toolRectangleBtn.Size = new System.Drawing.Size(89, 33);
            this.toolRectangleBtn.TabIndex = 7;
            this.toolRectangleBtn.Text = "Rectangle";
            this.toolRectangleBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolRectangleBtn.UseVisualStyleBackColor = false;
            // 
            // toolEllipseBtn
            // 
            this.toolEllipseBtn.BackColor = System.Drawing.Color.Black;
            this.toolEllipseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolEllipseBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolEllipseBtn.Location = new System.Drawing.Point(707, 146);
            this.toolEllipseBtn.Name = "toolEllipseBtn";
            this.toolEllipseBtn.Size = new System.Drawing.Size(89, 33);
            this.toolEllipseBtn.TabIndex = 6;
            this.toolEllipseBtn.Text = "Ellipse";
            this.toolEllipseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolEllipseBtn.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(716, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Set tool";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toolRectangleBtn);
            this.Controls.Add(this.toolEllipseBtn);
            this.Controls.Add(this.toolLineBtn);
            this.Controls.Add(this.toolEreaserBtn);
            this.Controls.Add(this.toolPenBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorBtn);
            this.Controls.Add(this.paintingBoard);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel paintingBoard;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button colorBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button toolPenBtn;
        private System.Windows.Forms.Button toolEreaserBtn;
        private System.Windows.Forms.Button toolLineBtn;
        private System.Windows.Forms.Button toolRectangleBtn;
        private System.Windows.Forms.Button toolEllipseBtn;
        private System.Windows.Forms.Label label2;
    }
}


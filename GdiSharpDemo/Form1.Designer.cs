namespace GdiSharpDemo
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRender = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboHorizontalAlignment = new System.Windows.Forms.ComboBox();
            this.cboVerticalAlignment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(20, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(748, 522);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnRender
            // 
            this.btnRender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRender.Location = new System.Drawing.Point(890, 116);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(118, 36);
            this.btnRender.TabIndex = 8;
            this.btnRender.Text = "Render";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(781, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Horizontal Alignment";
            // 
            // cboHorizontalAlignment
            // 
            this.cboHorizontalAlignment.FormattingEnabled = true;
            this.cboHorizontalAlignment.Location = new System.Drawing.Point(890, 21);
            this.cboHorizontalAlignment.Name = "cboHorizontalAlignment";
            this.cboHorizontalAlignment.Size = new System.Drawing.Size(174, 21);
            this.cboHorizontalAlignment.TabIndex = 10;
            // 
            // cboVerticalAlignment
            // 
            this.cboVerticalAlignment.FormattingEnabled = true;
            this.cboVerticalAlignment.Location = new System.Drawing.Point(890, 65);
            this.cboVerticalAlignment.Name = "cboVerticalAlignment";
            this.cboVerticalAlignment.Size = new System.Drawing.Size(174, 21);
            this.cboVerticalAlignment.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(781, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Vertical Alignment";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 601);
            this.Controls.Add(this.cboVerticalAlignment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboHorizontalAlignment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRender);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboHorizontalAlignment;
        private System.Windows.Forms.ComboBox cboVerticalAlignment;
        private System.Windows.Forms.Label label2;
    }
}


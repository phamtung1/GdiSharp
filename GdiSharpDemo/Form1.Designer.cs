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
            this.cboComponent = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numMarginLeft = new System.Windows.Forms.NumericUpDown();
            this.numMarginTop = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarginLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarginTop)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(27, 26);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(728, 449);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnRender
            // 
            this.btnRender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRender.Location = new System.Drawing.Point(882, 300);
            this.btnRender.Margin = new System.Windows.Forms.Padding(4);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(157, 44);
            this.btnRender.TabIndex = 8;
            this.btnRender.Text = "Render";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(789, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Horizontal Alignment";
            // 
            // cboHorizontalAlignment
            // 
            this.cboHorizontalAlignment.FormattingEnabled = true;
            this.cboHorizontalAlignment.Location = new System.Drawing.Point(934, 78);
            this.cboHorizontalAlignment.Margin = new System.Windows.Forms.Padding(4);
            this.cboHorizontalAlignment.Name = "cboHorizontalAlignment";
            this.cboHorizontalAlignment.Size = new System.Drawing.Size(231, 24);
            this.cboHorizontalAlignment.TabIndex = 10;
            // 
            // cboVerticalAlignment
            // 
            this.cboVerticalAlignment.FormattingEnabled = true;
            this.cboVerticalAlignment.Location = new System.Drawing.Point(934, 132);
            this.cboVerticalAlignment.Margin = new System.Windows.Forms.Padding(4);
            this.cboVerticalAlignment.Name = "cboVerticalAlignment";
            this.cboVerticalAlignment.Size = new System.Drawing.Size(231, 24);
            this.cboVerticalAlignment.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(789, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Vertical Alignment";
            // 
            // cboComponent
            // 
            this.cboComponent.FormattingEnabled = true;
            this.cboComponent.Location = new System.Drawing.Point(934, 26);
            this.cboComponent.Margin = new System.Windows.Forms.Padding(4);
            this.cboComponent.Name = "cboComponent";
            this.cboComponent.Size = new System.Drawing.Size(231, 24);
            this.cboComponent.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(789, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Component";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(789, 188);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Margin Left";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(789, 235);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Margin Top";
            // 
            // numMarginLeft
            // 
            this.numMarginLeft.Location = new System.Drawing.Point(935, 182);
            this.numMarginLeft.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMarginLeft.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numMarginLeft.Name = "numMarginLeft";
            this.numMarginLeft.Size = new System.Drawing.Size(229, 22);
            this.numMarginLeft.TabIndex = 17;
            this.numMarginLeft.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numMarginTop
            // 
            this.numMarginTop.Location = new System.Drawing.Point(936, 233);
            this.numMarginTop.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMarginTop.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numMarginTop.Name = "numMarginTop";
            this.numMarginTop.Size = new System.Drawing.Size(229, 22);
            this.numMarginTop.TabIndex = 18;
            this.numMarginTop.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 547);
            this.Controls.Add(this.numMarginTop);
            this.Controls.Add(this.numMarginLeft);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboComponent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboVerticalAlignment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboHorizontalAlignment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRender);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarginLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarginTop)).EndInit();
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
        private System.Windows.Forms.ComboBox cboComponent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numMarginLeft;
        private System.Windows.Forms.NumericUpDown numMarginTop;
    }
}


namespace SortComparison
{
    partial class frmMain
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
            this.cboAlg1 = new System.Windows.Forms.ComboBox();
            this.cboAlg2 = new System.Windows.Forms.ComboBox();
            this.cmdSort = new System.Windows.Forms.Button();
            this.pnlSort1 = new System.Windows.Forms.PictureBox();
            this.pnlSort2 = new System.Windows.Forms.PictureBox();
            this.tbSamples = new System.Windows.Forms.TrackBar();
            this.lblSamples = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cboAlg3 = new System.Windows.Forms.ComboBox();
            this.pnlSort3 = new System.Windows.Forms.PictureBox();
            this.bxorder = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort3)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAlg1
            // 
            this.cboAlg1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cboAlg1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cboAlg1.FormattingEnabled = true;
            this.cboAlg1.Items.AddRange(new object[] {
            "Bubble Sort",
            "Insertion Sort",
            "Quicksort"});
            this.cboAlg1.Location = new System.Drawing.Point(52, 270);
            this.cboAlg1.Margin = new System.Windows.Forms.Padding(4);
            this.cboAlg1.Name = "cboAlg1";
            this.cboAlg1.Size = new System.Drawing.Size(248, 24);
            this.cboAlg1.TabIndex = 2;
            // 
            // cboAlg2
            // 
            this.cboAlg2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cboAlg2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cboAlg2.DropDownWidth = 200;
            this.cboAlg2.FormattingEnabled = true;
            this.cboAlg2.Items.AddRange(new object[] {
            "Bubble Sort",
            "Insertion Sort",
            "Quicksort"});
            this.cboAlg2.Location = new System.Drawing.Point(331, 269);
            this.cboAlg2.Margin = new System.Windows.Forms.Padding(4);
            this.cboAlg2.Name = "cboAlg2";
            this.cboAlg2.Size = new System.Drawing.Size(233, 24);
            this.cboAlg2.TabIndex = 3;
            // 
            // cmdSort
            // 
            this.cmdSort.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdSort.BackColor = System.Drawing.Color.LawnGreen;
            this.cmdSort.Location = new System.Drawing.Point(593, 337);
            this.cmdSort.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSort.Name = "cmdSort";
            this.cmdSort.Size = new System.Drawing.Size(239, 28);
            this.cmdSort.TabIndex = 5;
            this.cmdSort.Text = "Sort";
            this.cmdSort.UseVisualStyleBackColor = false;
            this.cmdSort.Click += new System.EventHandler(this.cmdSort_Click);
            // 
            // pnlSort1
            // 
            this.pnlSort1.BackColor = System.Drawing.Color.White;
            this.pnlSort1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSort1.Location = new System.Drawing.Point(52, 15);
            this.pnlSort1.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSort1.Name = "pnlSort1";
            this.pnlSort1.Size = new System.Drawing.Size(249, 246);
            this.pnlSort1.TabIndex = 6;
            this.pnlSort1.TabStop = false;
            // 
            // pnlSort2
            // 
            this.pnlSort2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlSort2.BackColor = System.Drawing.Color.White;
            this.pnlSort2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSort2.Location = new System.Drawing.Point(330, 15);
            this.pnlSort2.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSort2.Name = "pnlSort2";
            this.pnlSort2.Size = new System.Drawing.Size(234, 246);
            this.pnlSort2.TabIndex = 7;
            this.pnlSort2.TabStop = false;
            // 
            // tbSamples
            // 
            this.tbSamples.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbSamples.LargeChange = 10;
            this.tbSamples.Location = new System.Drawing.Point(127, 301);
            this.tbSamples.Margin = new System.Windows.Forms.Padding(4);
            this.tbSamples.Maximum = 1000;
            this.tbSamples.Minimum = 10;
            this.tbSamples.Name = "tbSamples";
            this.tbSamples.Size = new System.Drawing.Size(396, 56);
            this.tbSamples.TabIndex = 8;
            this.tbSamples.TickFrequency = 100;
            this.tbSamples.Value = 100;
            this.tbSamples.Scroll += new System.EventHandler(this.tbSamples_Scroll);
            // 
            // lblSamples
            // 
            this.lblSamples.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSamples.AutoSize = true;
            this.lblSamples.Location = new System.Drawing.Point(49, 305);
            this.lblSamples.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSamples.Name = "lblSamples";
            this.lblSamples.Size = new System.Drawing.Size(70, 17);
            this.lblSamples.TabIndex = 9;
            this.lblSamples.Text = "Samples: \r\n";
            this.lblSamples.Click += new System.EventHandler(this.lblSamples_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 343);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Speed:";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbSpeed.Location = new System.Drawing.Point(127, 337);
            this.tbSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.tbSpeed.Maximum = 20;
            this.tbSpeed.Minimum = 1;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(396, 56);
            this.tbSpeed.TabIndex = 11;
            this.tbSpeed.Value = 7;
            this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 343);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Min";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(531, 343);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Max";
            // 
            // cboAlg3
            // 
            this.cboAlg3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cboAlg3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cboAlg3.FormattingEnabled = true;
            this.cboAlg3.Items.AddRange(new object[] {
            "Bubble Sort",
            "Insertion Sort",
            "Quicksort"});
            this.cboAlg3.Location = new System.Drawing.Point(593, 269);
            this.cboAlg3.Margin = new System.Windows.Forms.Padding(4);
            this.cboAlg3.Name = "cboAlg3";
            this.cboAlg3.Size = new System.Drawing.Size(239, 24);
            this.cboAlg3.TabIndex = 36;
            // 
            // pnlSort3
            // 
            this.pnlSort3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlSort3.BackColor = System.Drawing.Color.White;
            this.pnlSort3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSort3.Location = new System.Drawing.Point(593, 15);
            this.pnlSort3.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSort3.Name = "pnlSort3";
            this.pnlSort3.Size = new System.Drawing.Size(239, 246);
            this.pnlSort3.TabIndex = 35;
            this.pnlSort3.TabStop = false;
            // 
            // bxorder
            // 
            this.bxorder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bxorder.BackColor = System.Drawing.SystemColors.HighlightText;
            this.bxorder.FormattingEnabled = true;
            this.bxorder.Items.AddRange(new object[] {
            "Increase",
            "Decrease"});
            this.bxorder.Location = new System.Drawing.Point(593, 305);
            this.bxorder.Margin = new System.Windows.Forms.Padding(4);
            this.bxorder.Name = "bxorder";
            this.bxorder.Size = new System.Drawing.Size(239, 24);
            this.bxorder.TabIndex = 37;
            this.bxorder.SelectedIndexChanged += new System.EventHandler(this.bxorder_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(524, 305);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 39;
            this.label5.Text = "1000";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 433);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bxorder);
            this.Controls.Add(this.cboAlg3);
            this.Controls.Add(this.pnlSort3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSamples);
            this.Controls.Add(this.tbSamples);
            this.Controls.Add(this.pnlSort2);
            this.Controls.Add(this.cmdSort);
            this.Controls.Add(this.cboAlg2);
            this.Controls.Add(this.cboAlg1);
            this.Controls.Add(this.pnlSort1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(13327, 12297);
            this.MinimumSize = new System.Drawing.Size(594, 464);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sort Comparison";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboAlg1;
        private System.Windows.Forms.ComboBox cboAlg2;
        private System.Windows.Forms.Button cmdSort;
        private System.Windows.Forms.PictureBox pnlSort1;
        private System.Windows.Forms.PictureBox pnlSort2;
        private System.Windows.Forms.TrackBar tbSamples;
        private System.Windows.Forms.Label lblSamples;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox cboAlg3;
        private System.Windows.Forms.PictureBox pnlSort3;
        private System.Windows.Forms.ComboBox bxorder;
        private System.Windows.Forms.Label label5;
    }
}


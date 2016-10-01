namespace SpaceViewer
{
    partial class SpaceViewerForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GraphicsPanel = new System.Windows.Forms.Panel();
            this.SpaceViewPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EnerbyLabel = new System.Windows.Forms.Label();
            this.VarianceLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.AnnealTimer = new System.Windows.Forms.Timer(this.components);
            this.XRangeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.YRangeLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ShowLocationCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.GraphicsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceViewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ShowLocationCheckBox);
            this.panel1.Controls.Add(this.YRangeLabel);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.XRangeLabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.StopButton);
            this.panel1.Controls.Add(this.StartButton);
            this.panel1.Controls.Add(this.VarianceLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.EnerbyLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 56);
            this.panel1.TabIndex = 0;
            // 
            // GraphicsPanel
            // 
            this.GraphicsPanel.Controls.Add(this.SpaceViewPictureBox);
            this.GraphicsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GraphicsPanel.Location = new System.Drawing.Point(0, 56);
            this.GraphicsPanel.Name = "GraphicsPanel";
            this.GraphicsPanel.Size = new System.Drawing.Size(658, 336);
            this.GraphicsPanel.TabIndex = 1;
            // 
            // SpaceViewPictureBox
            // 
            this.SpaceViewPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpaceViewPictureBox.Location = new System.Drawing.Point(0, 0);
            this.SpaceViewPictureBox.Name = "SpaceViewPictureBox";
            this.SpaceViewPictureBox.Size = new System.Drawing.Size(658, 336);
            this.SpaceViewPictureBox.TabIndex = 0;
            this.SpaceViewPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Energy:";
            // 
            // EnerbyLabel
            // 
            this.EnerbyLabel.AutoSize = true;
            this.EnerbyLabel.Location = new System.Drawing.Point(70, 9);
            this.EnerbyLabel.Name = "EnerbyLabel";
            this.EnerbyLabel.Size = new System.Drawing.Size(31, 13);
            this.EnerbyLabel.TabIndex = 1;
            this.EnerbyLabel.Text = "<na>";
            // 
            // VarianceLabel
            // 
            this.VarianceLabel.AutoSize = true;
            this.VarianceLabel.Location = new System.Drawing.Point(70, 31);
            this.VarianceLabel.Name = "VarianceLabel";
            this.VarianceLabel.Size = new System.Drawing.Size(31, 13);
            this.VarianceLabel.TabIndex = 3;
            this.VarianceLabel.Text = "<na>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Variance:";
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.Location = new System.Drawing.Point(432, 21);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StopButton.Location = new System.Drawing.Point(513, 21);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 5;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // AnnealTimer
            // 
            this.AnnealTimer.Interval = 250;
            this.AnnealTimer.Tick += new System.EventHandler(this.AnnealTimer_Tick);
            // 
            // XRangeLabel
            // 
            this.XRangeLabel.AutoSize = true;
            this.XRangeLabel.Location = new System.Drawing.Point(220, 9);
            this.XRangeLabel.Name = "XRangeLabel";
            this.XRangeLabel.Size = new System.Drawing.Size(31, 13);
            this.XRangeLabel.TabIndex = 7;
            this.XRangeLabel.Text = "<na>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "X:";
            // 
            // YRangeLabel
            // 
            this.YRangeLabel.AutoSize = true;
            this.YRangeLabel.Location = new System.Drawing.Point(220, 26);
            this.YRangeLabel.Name = "YRangeLabel";
            this.YRangeLabel.Size = new System.Drawing.Size(31, 13);
            this.YRangeLabel.TabIndex = 9;
            this.YRangeLabel.Text = "<na>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(197, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Y:";
            // 
            // ShowLocationCheckBox
            // 
            this.ShowLocationCheckBox.AutoSize = true;
            this.ShowLocationCheckBox.Location = new System.Drawing.Point(378, 3);
            this.ShowLocationCheckBox.Name = "ShowLocationCheckBox";
            this.ShowLocationCheckBox.Size = new System.Drawing.Size(97, 17);
            this.ShowLocationCheckBox.TabIndex = 10;
            this.ShowLocationCheckBox.Text = "Show Location";
            this.ShowLocationCheckBox.UseVisualStyleBackColor = true;
            this.ShowLocationCheckBox.CheckedChanged += new System.EventHandler(this.ShowLocationCheckBox_CheckedChanged);
            // 
            // SpaceViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 392);
            this.Controls.Add(this.GraphicsPanel);
            this.Controls.Add(this.panel1);
            this.Name = "SpaceViewerForm";
            this.Text = "Space Viewer";
            this.Load += new System.EventHandler(this.SpaceViewerForm_Load);
            this.Resize += new System.EventHandler(this.SpaceViewerForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GraphicsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpaceViewPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label VarianceLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label EnerbyLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel GraphicsPanel;
        private System.Windows.Forms.PictureBox SpaceViewPictureBox;
        private System.Windows.Forms.Timer AnnealTimer;
        private System.Windows.Forms.Label YRangeLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label XRangeLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ShowLocationCheckBox;
    }
}


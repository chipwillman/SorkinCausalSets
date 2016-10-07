namespace SpaceViewer
{
    partial class SpaceViewer
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
            this.openGLControlTimerBased = new SharpGL.OpenGLControl();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.VelocityLabel = new System.Windows.Forms.Label();
            this.RotationalVelocityLabel = new System.Windows.Forms.Label();
            this.RotationLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlTimerBased)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControlTimerBased
            // 
            this.openGLControlTimerBased.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openGLControlTimerBased.DrawFPS = false;
            this.openGLControlTimerBased.Location = new System.Drawing.Point(0, 0);
            this.openGLControlTimerBased.Name = "openGLControlTimerBased";
            this.openGLControlTimerBased.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControlTimerBased.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControlTimerBased.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControlTimerBased.Size = new System.Drawing.Size(888, 421);
            this.openGLControlTimerBased.TabIndex = 0;
            this.openGLControlTimerBased.OpenGLInitialized += new System.EventHandler(this.openGLControlTimerBased_OpenGLInitialized);
            this.openGLControlTimerBased.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControlTimerBased_OpenGLDraw);
            // 
            // LocationLabel
            // 
            this.LocationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(12, 435);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(48, 13);
            this.LocationLabel.TabIndex = 1;
            this.LocationLabel.Text = "Location";
            // 
            // VelocityLabel
            // 
            this.VelocityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.VelocityLabel.AutoSize = true;
            this.VelocityLabel.Location = new System.Drawing.Point(12, 459);
            this.VelocityLabel.Name = "VelocityLabel";
            this.VelocityLabel.Size = new System.Drawing.Size(44, 13);
            this.VelocityLabel.TabIndex = 2;
            this.VelocityLabel.Text = "Velocity";
            // 
            // RotationalVelocityLabel
            // 
            this.RotationalVelocityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RotationalVelocityLabel.AutoSize = true;
            this.RotationalVelocityLabel.Location = new System.Drawing.Point(347, 459);
            this.RotationalVelocityLabel.Name = "RotationalVelocityLabel";
            this.RotationalVelocityLabel.Size = new System.Drawing.Size(44, 13);
            this.RotationalVelocityLabel.TabIndex = 4;
            this.RotationalVelocityLabel.Text = "Velocity";
            // 
            // RotationLabel
            // 
            this.RotationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RotationLabel.AutoSize = true;
            this.RotationLabel.Location = new System.Drawing.Point(347, 435);
            this.RotationLabel.Name = "RotationLabel";
            this.RotationLabel.Size = new System.Drawing.Size(47, 13);
            this.RotationLabel.TabIndex = 3;
            this.RotationLabel.Text = "Rotation";
            // 
            // SpaceViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 496);
            this.Controls.Add(this.RotationalVelocityLabel);
            this.Controls.Add(this.RotationLabel);
            this.Controls.Add(this.VelocityLabel);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.openGLControlTimerBased);
            this.KeyPreview = true;
            this.Name = "SpaceViewer";
            this.Text = "SpaceViewer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.Resize += new System.EventHandler(this.SpaceViewer_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlTimerBased)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControlTimerBased;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.Label VelocityLabel;
        private System.Windows.Forms.Label RotationalVelocityLabel;
        private System.Windows.Forms.Label RotationLabel;
    }
}
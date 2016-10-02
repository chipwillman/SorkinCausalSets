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
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlTimerBased)).BeginInit();
            this.Controls.Add(this.openGLControlTimerBased);
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();
            // 
            // openGLControlTimerBased
            // 
            this.openGLControlTimerBased.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
| System.Windows.Forms.AnchorStyles.Left)
| System.Windows.Forms.AnchorStyles.Right)));
            this.openGLControlTimerBased.DrawFPS = true;
            this.openGLControlTimerBased.Location = new System.Drawing.Point(0, 0);
            this.openGLControlTimerBased.Name = "openGLControlTimerBased";
            this.openGLControlTimerBased.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControlTimerBased.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControlTimerBased.Size = new System.Drawing.Size(292, 225);
            this.openGLControlTimerBased.TabIndex = 0;
            this.openGLControlTimerBased.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControlTimerBased_OpenGLDraw);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "SpaceViewer";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlTimerBased)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private SharpGL.OpenGLControl openGLControlTimerBased;
    }
}
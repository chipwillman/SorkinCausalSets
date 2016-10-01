using System;
using System.Windows.Forms;

namespace SpaceViewer
{
    using System.Drawing;

    using Annealing;

    public partial class SpaceViewerForm : Form
    {
        public SpaceViewerForm()
        {
            InitializeComponent();
        }

        private void Update()
        {
            this.UpdatePicture();
            this.EnerbyLabel.Text = CausalSet.Eaverage.ToString("F3");
            this.VarianceLabel.Text = CausalSet.Evariance.ToString("F3");
            this.XRangeLabel.Text = MinX.ToString("F3") + " to " + MaxX.ToString("F3");
            this.YRangeLabel.Text = MinY.ToString("F3") + " to " + MaxY.ToString("F3");
        }

        private void UpdatePicture()
        {
            try
            {
                UpdateProjectionMatrix();
                var image = new Bitmap(SpaceViewPictureBox.Width, SpaceViewPictureBox.Height);

                for (int i = 0; i < CausalSet.NumberElements; i++)
                {
                    DrawSphere(image, (float)CausalSet.Xnew[i, 0], (float)CausalSet.Xnew[i, 1], (float)CausalSet.Xnew[i, 2], (float)CausalSet.Rnew[i]);
                }

                SpaceViewPictureBox.Image = image;
            }
            catch (Exception)
            {

            }
        }

        private float MaxX = -999f;
        private float MaxY = -999f;
        private float MinX = 999f;
        private float MinY = 999f;
        private float MinDepth = 999f;
        private float MaxDepth = -999f;

        private void UpdateProjectionMatrix()
        {
            this.MinDepth = 999f;
            this.MaxDepth = -999f;
            this.MaxX = -999f;
            this.MaxY = -999f;
            this.MinX = 999f;
            this.MinY = 999f;
            var fov = (float)Math.PI / 4.0f;

            for (int i = 0; i < CausalSet.NumberElements; i++)
            {
                var x = (float)CausalSet.Xnew[i, 0];
                var y = (float)CausalSet.Xnew[i, 1];
                var z = (float)CausalSet.Xnew[i, 2];
                if (z < this.MinDepth) this.MinDepth = z;
                if (z > this.MaxDepth) this.MaxDepth = z;
                if (x < this.MinX) this.MinX = x;
                if (x > this.MaxX) this.MaxX = x;
                if (y < this.MinY) this.MinY = y;
                if (y > this.MaxY) this.MaxY = y;
            }

            ProjectionMatrix = this.BuildPerspProjMat(fov, 9 / 16.0f, -this.MinDepth, this.MaxDepth);
        }

        private float[] ProjectionMatrix { get; set; }

        private float[] BuildPerspProjMat(float fov, float aspect, float znear, float zfar)
        {
            var result = new float[16];
            float xymax = (float)(znear * Math.Tan(fov * Math.PI/360));
            float ymin = -xymax;
            float xmin = -xymax;

            float width = xymax - xmin;
            float height = xymax - ymin;

            float depth = zfar - znear;
            float q = -(zfar + znear) / depth;
            float qn = -2 * (zfar * znear) / depth;

            float w = 2 * znear / width;
            w = w / aspect;
            float h = 2 * znear / height;

            result[0] = w;
            result[1] = 0;
            result[2] = 0;
            result[3] = 0;

            result[4] = 0;
            result[5] = h;
            result[6] = 0;
            result[7] = 0;

            result[8] = 0;
            result[9] = 0;
            result[10] = q;
            result[11] = -1;

            result[12] = 0;
            result[13] = 0;
            result[14] = qn;
            result[15] = 0;
            return result;
        }

        private void DrawSphere(Bitmap image, float x, float y, float z, float radius)
        {
            float translatedX = x * (ProjectionMatrix[0] / SpaceViewPictureBox.Width) + 50;
            float translatedY = y * (ProjectionMatrix[5]/SpaceViewPictureBox.Height) + 50;
            var scaledRadius = (float)Math.Log(radius) * 5;// (float)Math.Max(100.0, Math.Min(1.0, radius * Math.Abs(z / translatedZ)));

            using (var g = Graphics.FromImage(image))
            {
                var spaceColor = ColorFromSize(radius);
                var brush = new SolidBrush(Color.FromArgb(125, spaceColor));
                g.FillEllipse(brush, translatedX, translatedY, 2*  scaledRadius, 2*  scaledRadius);
                g.DrawString("x: " + x.ToString("F3") + " y: " + y.ToString("F3"), SystemFonts.StatusFont, SystemBrushes.InfoText, translatedX, translatedY);
            }
        }

        private Color ColorFromSize(float radius)
        {
            var red = radius / 256;
            var green = radius / 64;
            var blue = radius / 16;
            var result = Color.FromArgb(64, (int)red % 256, (int)green % 256, (int)blue % 256);

            return result;
        }

        private void SpaceViewerForm_Load(object sender, EventArgs e)
        {
            this.CausalSet = new CausalSet(20, 10);
            this.CausalSet.ZetaFrom(IncidentMatrix);
            this.CausalSet.SpaceDimensions = 3;
            this.CausalSet.WarmUp();
            this.CausalSet.Statistics();
            this.Update();
        }

        protected CausalSet CausalSet { get; set; }

        #region Sample Incident Matrix
        // Number of elements in the causal and incidence matrix for causal set Pdelta(4)
        private const string IncidentMatrix = @"19
0 0 0 1 0 0 0 1 0 0 1 1 0 0 1 1 1 1
  0 0 0 1 0 0 1 1 0 0 0 1 1 0 1 1 1
    0 0 0 1 0 0 1 1 0 1 0 1 1 0 1 1
      0 0 0 1 0 0 1 1 0 1 1 1 1 0 1
        0 0 0 0 0 0 0 0 0 0 0 0 0 0
          0 0 0 0 0 0 0 0 0 0 0 0 0
            0 0 0 0 0 0 0 0 0 0 0 0
              0 0 0 0 0 0 0 0 0 0 0
                0 0 0 0 0 0 0 0 0 0
                  0 0 0 0 0 0 0 0 0
                    0 0 0 0 0 0 0 0
                      0 0 0 0 0 0 0
                        0 0 0 0 0 0
                          0 0 0 0 0
                            0 0 0 0
                              0 0 0
                                0 0
                                  0
";

        #endregion

        private void AnnealTimer_Tick(object sender, EventArgs e)
        {
            this.CausalSet.Anneal();
            this.CausalSet.Statistics();
            if (CausalSet.Rand.Ran2(CausalSet.Seed) > 0.5)
            {
                this.CausalSet.Temperature *= 0.9;
            }
            else
            {
                this.CausalSet.Temperature /= 0.9;
            }

            this.Update();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            AnnealTimer.Enabled = true;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            AnnealTimer.Enabled = false;
        }
    }
}

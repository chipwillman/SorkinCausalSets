using System.Windows.Forms;

namespace SpaceViewer
{
    using System;

    using Annealing;

    using SharpGL;
    using SharpGL.Enumerations;

    using global::SpaceViewer.Objects;

    public partial class SpaceViewer : Form
    {
        public SpaceViewer()
        {
            InitializeComponent();
        }

        private Camera Camera { get; set; }

        public World World;

        public Triangle Triangle;
        public static int LastTime = 0;

        private void OnPrepare()
        {
            openGLControlTimerBased.OpenGL.ClearColor(0f, 0f, 0f, 1f);
            openGLControlTimerBased.OpenGL.Enable(OpenGL.GL_DEPTH_TEST);
        }

        private void openGLControlTimerBased_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            HandleKeys();
            

            //HandleUpdates();

            OnPrepare();

            World.Prepare();

            Animate();

            try
            {
                DrawScene();
            }
            catch
            {
            }
        }

        public void Animate()
        {
            var now = Environment.TickCount;
            if (LastTime != 0)
            {
                var elapsed = (now - LastTime) / 1000f;
                if (elapsed > 0)
                {
                    if (elapsed > 0.25f)
                    {
                        elapsed = 0.25f;
                    }

                    //Camera.Animate(elapsed);
                    World.Animate(elapsed);
                    //Camera.Update();
                }
            }

            LastTime = now;
        }

        public static bool[] HeldKeys = new bool[255];

        public float MaxSpeed = 5f;

        private float mouseSensitivity = 10;
        public void HandleKeys()
        {
            var velocityX = Camera.Velocity.x;
            var velocityY = Camera.Velocity.y;
            var velocityZ = Camera.Velocity.z;
            if (HeldKeys[33])
            {
                // Page Up
                velocityY += 2f;
            }

            if (HeldKeys[34])
            {
                // Page Down
                velocityY -= 2f;
            }

            if (HeldKeys[37] || HeldKeys[65]) // Left cursor key or a
            {
                Camera.RotationVelocity -= 100f;
                // Camera.Velocity += new Vector(1f, 0, 0);
            }

            if (HeldKeys[39] || HeldKeys[68])
            {
                Camera.RotationVelocity += 100f;
                // Right cursor key
                // Camera.Velocity += new Vector(1f, 0, 0);
            }


            if (HeldKeys[38] || HeldKeys[87])
            {
                // Up cursor key
                velocityZ += 2f;
            }

            if (HeldKeys[40] || HeldKeys[83])
            {
                // Down cursor key
                velocityZ -= 2f;
            }

            if (HeldKeys[81])
            {
                // Up cursor key
                velocityX -= 1f;
            }

            if (HeldKeys[69])
            {
                // Down cursor key
                velocityX += 1f;
            }

            var newVelocity = new vec3(velocityX,0,velocityZ);
            Camera.Velocity = newVelocity;

            if (HeldKeys[107])
            {
                mouseSensitivity += 0.05f;
            }

            if (HeldKeys[109])
            {
                mouseSensitivity -= 0.05f;
                if (mouseSensitivity < 0.05f)
                    mouseSensitivity = 0.05f;
            }
        }


        private DateTime LastUpdate = DateTime.Now;

        public void DrawScene()
        {
            var deltaTime = ((DateTime.Now - LastUpdate).Milliseconds) / 1000f;
            LastUpdate = DateTime.Now;

            Camera.GL.MatrixMode(OpenGL.GL_PROJECTION);
            Camera.GL.LoadIdentity();
            Camera.GL.Viewport(0, 0, openGLControlTimerBased.Width, openGLControlTimerBased.Height);
            Camera.GL.Perspective(45f, Width / (double)Height, 1, 100.0);
            Camera.GL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            Camera.Animate(Math.Max(deltaTime, 0.25f));

            Camera.GL.MatrixMode(OpenGL.GL_MODELVIEW);				// Select The Modelview Matrix
            Camera.GL.LoadIdentity();					// Reset The Modelview Matrix
            World.Draw(Camera);

            LocationLabel.Text = "Location X: " + World.Camera.Location.x.ToString("g") + " Y: "
                                 + World.Camera.Location.y.ToString("g") + "Z: " + World.Camera.Location.z.ToString("g");
            RotationLabel.Text = "Rotation X: " + World.Camera.Rotation.x.ToString("g") + " Y: "
                                 + World.Camera.Rotation.y.ToString("g") + "Z: " + World.Camera.Rotation.z.ToString("g");
            VelocityLabel.Text = "Velocity X: " + World.Camera.Velocity.x.ToString("g") + " Y: "
                                 + World.Camera.Velocity.y.ToString("g") + "Z: " + World.Camera.Velocity.z.ToString("g");
            RotationalVelocityLabel.Text = "Velocity: " + World.Camera.RotationVelocity.ToString("g");
        }


        private void openGLControlTimerBased_OpenGLInitialized(object sender, System.EventArgs e)
        {
            Camera = new Camera(openGLControlTimerBased.OpenGL);
            var gl = Camera.GL;
            gl.ShadeModel(OpenGL.GL_SMOOTH);						// Enables Smooth Shading
            gl.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);					// Black Background
            gl.ClearDepth(1.0f);							// Depth Buffer Setup
            gl.Disable(OpenGL.GL_DEPTH_TEST);						// Disables Depth Testing
            gl.Enable(OpenGL.GL_BLEND);							// Enable Blending
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE);					// Type Of Blending To Perform
            gl.Hint(OpenGL.GL_PERSPECTIVE_CORRECTION_HINT, OpenGL.GL_NICEST);			// Really Nice Perspective Calculations
            gl.Hint(OpenGL.GL_POINT_SMOOTH_HINT, OpenGL.GL_NICEST);					// Really Nice Point Smoothing

            Camera.Rotation = new vec3(0, (float)Math.PI/2, 0);
            SpaceViewer_Resize(sender, e);

            this.CausalSet = new CausalSet(20, 10);
            this.CausalSet.ZetaFrom(IncidentMatrix);
            this.CausalSet.SpaceDimensions = 3;
            this.CausalSet.WarmUp();
            this.CausalSet.Statistics();

            World = new World(Camera, CausalSet);
            Triangle = new Triangle();
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

        protected void OnKeyDown(object sender, KeyEventArgs e)
        {
            HeldKeys[(int)e.KeyCode] = true;
        }

        protected void OnKeyUp(object sender, KeyEventArgs e)
        {
            HeldKeys[(int)e.KeyCode] = false;
        }

        private void SpaceViewer_Resize(object sender, EventArgs e)
        {
            Camera.GL.MatrixMode(OpenGL.GL_PROJECTION);
            Camera.GL.LoadIdentity();
            Camera.GL.Viewport(0, 0, openGLControlTimerBased.Width, openGLControlTimerBased.Height);
            Camera.GL.Perspective(30f, Width / (double)Height, 1, 100.0);

            Camera.GL.MatrixMode(OpenGL.GL_MODELVIEW);				// Select The Modelview Matrix
            Camera.GL.LoadIdentity();					// Reset The Modelview Matrix
        }
    }
}

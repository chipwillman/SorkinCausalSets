﻿using System.Windows.Forms;

namespace SpaceViewer
{
    using SharpGL;

    public partial class SpaceViewer : Form
    {
        public SpaceViewer()
        {
            InitializeComponent();
        }

        float rquad;

        private void openGLControlTimerBased_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            //  Get the OpenGL object, just to clean up the code.
            var gl = openGLControlTimerBased.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            gl.LoadIdentity();
            gl.Translate(0f, 0.0f, -7.0f);				// Move Right And Into The Screen

            gl.Rotate(rquad, 1.0f, 1.0f, 1.0f);			// Rotate The Cube On X, Y & Z

            gl.Begin(OpenGL.GL_QUADS);					// Start Drawing The Cube

            gl.Color(0.0f, 1.0f, 0.0f);			// Set The Color To Green
            gl.Vertex(1.0f, 1.0f, -1.0f);			// Top Right Of The Quad (Top)
            gl.Vertex(-1.0f, 1.0f, -1.0f);			// Top Left Of The Quad (Top)
            gl.Vertex(-1.0f, 1.0f, 1.0f);			// Bottom Left Of The Quad (Top)
            gl.Vertex(1.0f, 1.0f, 1.0f);			// Bottom Right Of The Quad (Top)


            gl.Color(1.0f, 0.5f, 0.0f);			// Set The Color To Orange
            gl.Vertex(1.0f, -1.0f, 1.0f);			// Top Right Of The Quad (Bottom)
            gl.Vertex(-1.0f, -1.0f, 1.0f);			// Top Left Of The Quad (Bottom)
            gl.Vertex(-1.0f, -1.0f, -1.0f);			// Bottom Left Of The Quad (Bottom)
            gl.Vertex(1.0f, -1.0f, -1.0f);			// Bottom Right Of The Quad (Bottom)

            gl.Color(1.0f, 0.0f, 0.0f);			// Set The Color To Red
            gl.Vertex(1.0f, 1.0f, 1.0f);			// Top Right Of The Quad (Front)
            gl.Vertex(-1.0f, 1.0f, 1.0f);			// Top Left Of The Quad (Front)
            gl.Vertex(-1.0f, -1.0f, 1.0f);			// Bottom Left Of The Quad (Front)
            gl.Vertex(1.0f, -1.0f, 1.0f);			// Bottom Right Of The Quad (Front)

            gl.Color(1.0f, 1.0f, 0.0f);			// Set The Color To Yellow
            gl.Vertex(1.0f, -1.0f, -1.0f);			// Bottom Left Of The Quad (Back)
            gl.Vertex(-1.0f, -1.0f, -1.0f);			// Bottom Right Of The Quad (Back)
            gl.Vertex(-1.0f, 1.0f, -1.0f);			// Top Right Of The Quad (Back)
            gl.Vertex(1.0f, 1.0f, -1.0f);			// Top Left Of The Quad (Back)

            gl.Color(0.0f, 0.0f, 1.0f);			// Set The Color To Blue
            gl.Vertex(-1.0f, 1.0f, 1.0f);			// Top Right Of The Quad (Left)
            gl.Vertex(-1.0f, 1.0f, -1.0f);			// Top Left Of The Quad (Left)
            gl.Vertex(-1.0f, -1.0f, -1.0f);			// Bottom Left Of The Quad (Left)
            gl.Vertex(-1.0f, -1.0f, 1.0f);			// Bottom Right Of The Quad (Left)

            gl.Color(1.0f, 0.0f, 1.0f);			// Set The Color To Violet
            gl.Vertex(1.0f, 1.0f, -1.0f);			// Top Right Of The Quad (Right)
            gl.Vertex(1.0f, 1.0f, 1.0f);			// Top Left Of The Quad (Right)
            gl.Vertex(1.0f, -1.0f, 1.0f);			// Bottom Left Of The Quad (Right)
            gl.Vertex(1.0f, -1.0f, -1.0f);			// Bottom Right Of The Quad (Right)
            gl.End();						// Done Drawing The Q

            gl.Flush();

            rquad -= 3.0f;// 0.15f;						// Decrease The Rotation Variable For The Quad 
        }
    }
}

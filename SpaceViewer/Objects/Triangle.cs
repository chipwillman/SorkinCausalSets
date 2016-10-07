namespace SpaceViewer.Objects
{
    using System;

    using SharpGL;
    using SharpGL.Enumerations;

    public class Triangle : GlObject
    {
        protected override void OnDraw(Camera camera)
        {
            camera.GL.Begin(OpenGL.GL_TRIANGLES);

            camera.GL.Color(1.0f, 0.0f, 0.0f);			// Red
            camera.GL.Vertex(0.0f, 1.0f, 0.0f);			// Top Of Triangle (Front)
            camera.GL.Color(0.0f, 1.0f, 0.0f);			// Green
            camera.GL.Vertex(-1.0f, -1.0f, 1.0f);			// Left Of Triangle (Front)
            camera.GL.Color(0.0f, 0.0f, 1.0f);			// Blue
            camera.GL.Vertex(1.0f, -1.0f, 1.0f);			// Right Of Triangle (Front)

            camera.GL.Color(1.0f, 0.0f, 0.0f);			// Red
            camera.GL.Vertex(0.0f, 1.0f, 0.0f);			// Top Of Triangle (Right)
            camera.GL.Color(0.0f, 0.0f, 1.0f);			// Blue
            camera.GL.Vertex(1.0f, -1.0f, 1.0f);			// Left Of Triangle (Right)
            camera.GL.Color(0.0f, 1.0f, 0.0f);			// Green
            camera.GL.Vertex(1.0f, -1.0f, -1.0f);			// Right Of Triangle (Right)

            camera.GL.Color(1.0f, 0.0f, 0.0f);			// Red
            camera.GL.Vertex(0.0f, 1.0f, 0.0f);			// Top Of Triangle (Back)
            camera.GL.Color(0.0f, 1.0f, 0.0f);			// Green
            camera.GL.Vertex(1.0f, -1.0f, -1.0f);			// Left Of Triangle (Back)
            camera.GL.Color(0.0f, 0.0f, 1.0f);			// Blue
            camera.GL.Vertex(-1.0f, -1.0f, -1.0f);			// Right Of Triangle (Back)

            camera.GL.Color(1.0f, 0.0f, 0.0f);			// Red
            camera.GL.Vertex(0.0f, 1.0f, 0.0f);			// Top Of Triangle (Left)
            camera.GL.Color(0.0f, 0.0f, 1.0f);			// Blue
            camera.GL.Vertex(-1.0f, -1.0f, -1.0f);			// Left Of Triangle (Left)
            camera.GL.Color(0.0f, 1.0f, 0.0f);			// Green
            camera.GL.Vertex(-1.0f, -1.0f, 1.0f);			// Right Of Triangle (Left)
            camera.GL.End();						// Done Drawing The Pyramid

            //camera.GL.drawArrays(camera.GL.TRIANGLE_STRIP, 0, this.TerrainData.Indices.Length);
        }
    }
}

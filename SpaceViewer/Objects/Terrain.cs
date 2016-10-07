namespace SpaceViewer.Objects
{
    using System.Drawing;

    using SharpGL;
    using SharpGL.SceneGraph.Assets;
    using SharpGL.SceneGraph.Core;
    using SharpGL.SceneGraph.Quadrics;

    public class Terrain : GlObject
    {
        public Terrain()
        {
            fogColor = new float[4];
            fogColor[0] = 0.75f;
            fogColor[1] = 0.9f;
            fogColor[2] = 1.0f;
            fogColor[3] = 1.0f;
        }

        public float[] fogColor;

        public double GetHeight(float p0, float p1)
        {
            return -2.0;
        }

        protected Sphere sphere { get; set; }

        protected override void OnDraw(Camera camera)
        {
            if (this.HasChild)
            {
                ((GlObject)(this.Child)).Draw(camera);
                var nextChild = this.Child.Next;
                while (nextChild != this.Child)
                {
                    ((GlObject)(nextChild)).Draw(camera);
                    nextChild = nextChild.Next;
                }
            }
        }
    }
}

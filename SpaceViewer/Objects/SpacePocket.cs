using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceViewer.Objects
{
    using System.Drawing;

    using SharpGL.SceneGraph.Assets;
    using SharpGL.SceneGraph.Core;
    using SharpGL.SceneGraph.Quadrics;

    public class SpacePocket : GlObject
    {
        public SpacePocket()
        {
            Radius = 0.5f;
        }

        protected Sphere sphere { get; set; }

        protected override void OnDraw(Camera camera)
        {
            //	Create the sphere if need be.
            if (sphere == null)
            {
                sphere = new Sphere();
                sphere.CreateInContext(camera.GL);
                sphere.Slices = 12;
                sphere.Stacks = 20;
            }


            sphere.PushObjectSpace(camera.GL);
            camera.GL.Color(0.2f, 0.5f, 0.8f, 0.5f);
            sphere.Radius = this.Radius;
            sphere.QuadricDrawStyle = DrawStyle.Fill;
            sphere.Render(camera.GL, RenderMode.Render);

            if (this.HasChild)
            {
                ((GlObject)(this.Child)).Draw(camera);
            }
            sphere.PopObjectSpace(camera.GL);
        }

        public double Radius { get; set; }
    }
}

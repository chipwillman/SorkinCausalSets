namespace SpaceViewer.Objects
{
    using Annealing;

    using SharpGL.SceneGraph.Core;
    using SharpGL.SceneGraph.Quadrics;

    public class SpacePocket : GlObject
    {
        public SpacePocket(CausalSet set)
        {
            this.Set = set;
        }

        protected CausalSet Set { get; set; }

        public double Radius 
        { 
            get
            {
                var result = Set.Rnew[Index];
                return result;
            }
        }

        public const int Slices = 12;

        public const int Stacks = 20;

        protected Sphere sphere { get; set; }

        public int Index { get; set; }

        protected override void OnDraw(Camera camera)
        {
            //	Create the sphere if need be.
            if (sphere == null)
            {
                sphere = new Sphere();
                sphere.CreateInContext(camera.GL);
                sphere.Slices = Slices;
                sphere.Stacks = Stacks;
            }
            var loc = new vec3((float)Set.Xnew[Index, 0], (float)Set.Xnew[Index, 1], (float)Set.Xnew[Index, 2]);
            camera.GL.Translate(loc.x, loc.y, loc.z);

            sphere.PushObjectSpace(camera.GL);
            camera.GL.Color(0.2f, 0.5f, 0.8f, 0.5f);
            sphere.Radius = this.Radius;
            sphere.QuadricDrawStyle = DrawStyle.Fill;
            sphere.Render(camera.GL, RenderMode.Render);
            sphere.PopObjectSpace(camera.GL);
        }
    }
}

namespace SpaceViewer.Objects
{
    public class Player : GlObject
    {
        public Player()
        {
            this.Size = 2f;
        }

        public void SetCamera(Camera camera)
        {
            this.Camera = camera;
        }

        public void DetachCamera()
        {
            this.Camera = null;
        }

        public Camera Camera;
    }
}

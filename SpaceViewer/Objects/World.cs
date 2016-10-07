namespace SpaceViewer.Objects
{
    using Annealing;

    public class World
    {
        public World(Camera camera, CausalSet set)
        {
            var width = 32;
            this.Camera = camera;
            this.Terrain = new Terrain { Position = new vec3(-width / 2f, 0, -width / 2f) };

            for (int i = 0; i < set.NumberElements; i++)
            {
                var pocket = new SpacePocket(set);
                pocket.Index = i;
                pocket.AttachTo(Terrain);
            }
            Set = set;
        }

        public Terrain Terrain { get; set; }

        public CausalSet Set { get; set; }

        public Camera Camera { get; set; }

        public int MapRequestSent;

        public void Animate(float deltaTime)
        {
            var terrainHeight = Terrain.GetHeight(Camera.Location.x, Camera.Location.z);

            //if (Camera.Location.y < terrainHeight + Player.Size)
            //{
            //    Camera.Location = new vec3(Camera.Location.x, (float)(terrainHeight + Player.Size), Camera.Location.z);
            //}

            //Terrain.EnsurePlayerMap(Player);
            Set.Animate(deltaTime);
            Terrain.Animate(deltaTime);
        }

        public void Draw(Camera camera)
        {
            Terrain.Draw(camera);
        }

        public void Prepare()
        {
            //Camera.GL.ClearColor(Terrain.fogColor[0], Terrain.fogColor[1], Terrain.fogColor[2], Terrain.fogColor[3]);

            //Terrain.MapCenterPosition = Camera.Location;
            Terrain.Prepare();

            //Crate.Prepare();
        }

        public void UnloadWorld()
        {

        }

        #region Implementation

        private bool gameDone;

        //private void RequestMapUpdate()
        //{
        //    var now = Environment.TickCount;
        //    if ((now - MapRequestSent) > 15000)
        //    {
        //        MapRequestSent = Environment.TickCount;
        //        var repository = new RiftRepository("lpmud.local", "user", "password");
        //        repository.LoadMap(Camera.Location, 128f, Page.LoadWorldCallback);
        //    }
        //}

        #endregion
    }
}

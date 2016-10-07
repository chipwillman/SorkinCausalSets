namespace SpaceViewer.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SharpGL;

    using global::SpaceViewer.Objects;

    [TestClass]
    public class TestCamera
    {
        [TestMethod]
        public void ItMovesIfThereIsVelocity()
        {
            var camera = new Camera(null);
            camera.Location = new vec3(1.0f, 1.0f, 1.0f);
            camera.Velocity = new vec3(0.0f, 0.0f, 1.0f);
            camera.Rotation = new vec3(0.0f, (float)Math.PI, 0.0f);

            camera.Animate(0.25f);

            Assert.AreEqual(camera.Location.y, 1f);
            Assert.AreEqual(camera.Location.z, 1f);
            Assert.AreEqual(camera.Location.x, 0.75f);
        }

        [TestMethod]
        public void ItSlowsDownAndStopsIfNotActedUponExternally()
        {
            var camera = new Camera(null);
            camera.Location = new vec3(1.0f, 1.0f, 1.0f);
            camera.Velocity = new vec3(0.0f, 0.0f, 1.0f);
            camera.Rotation = new vec3(0.0f, (float)Math.PI, 0.0f);

            for (int i = 0; i < 10; i++)
                camera.Animate(0.25f);

            Assert.AreEqual(camera.Velocity.y, 0f);
            Assert.AreEqual(camera.Velocity.z, 0f);
            Assert.AreEqual(camera.Velocity.x, 0f);
        }
    }
}

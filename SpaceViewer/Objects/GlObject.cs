using System;
using System.Collections.Generic;

namespace SpaceViewer.Objects
{
    public class GlObject : Inventory
    {
        protected GlObject()
        {
            Position = new vec3();
            Velocity = new vec3();
            Acceleration = new vec3();
        }

        protected GlObject(Inventory parent)
            : base(parent)
        {
            Position = new vec3();
            Velocity = new vec3();
            Acceleration = new vec3();
        }

        public vec3 Acceleration { get; set; }

        public vec3 Position { get; set; }

        public vec3 Velocity { get; set; }

        public float Size { get; set; }

        public void Draw(Camera camera)
        {
            camera.GL.PushMatrix();
            camera.GL.Translate(Position.x, Position.y, Position.z);

            this.OnDraw(camera);
            if (this.HasChild)
            {
                ((GlObject)Child).Draw(camera);
            }
            camera.GL.PopMatrix();

            //if (this.HasParent && !this.IsLastChild())
            //{
            //    ((GlObject)Next).Draw(camera);
            //}
        }

        public void Animate(float deltaTime)
        {
            this.OnAnimate(deltaTime);

            if (this.HasChild)
            {
                ((GlObject)Child).Animate(deltaTime);
            }

            if (this.HasParent && !this.IsLastChild())
            {
                ((GlObject)Next).Animate(deltaTime);
            }
        }

        public void ProcessCollisions(GlObject obj)
        {
            if ((obj.Position - this.Position).Length() <= (obj.Size + this.Size))
            {
                this.OnCollision(obj);
                if (this.HasChild)
                {
                    ((GlObject)Child).ProcessCollisions(obj);
                }

                if (this.HasParent && !this.IsLastChild())
                {
                    ((GlObject)Next).ProcessCollisions(obj);
                }
            }

            if (obj.HasChild)
            {
                this.ProcessCollisions(((GlObject)obj.Child));
            }

            if (obj.HasParent && !obj.IsLastChild())
            {
                this.ProcessCollisions(((GlObject)obj.Next));
            }
        }

        public void Prepare()
        {
            this.OnPrepare();

            if (HasChild)
            {
                ((GlObject)Child).Prepare();
            }

            if (HasParent && !this.IsLastChild())
            {
                ((GlObject)Next).Prepare();
            }
        }

        #region Implementation

        protected virtual void OnAnimate(float deltaTime)
        {
            this.Position += this.Velocity * deltaTime;
            this.Velocity += this.Acceleration * deltaTime;
        }

        protected virtual void OnDraw(Camera camera)
        {
        }

        protected mat4 MatrixYawPitchRoll(vec3 rotation)
        {
            float xcos = (float)Math.Cos(rotation.x);
            float xsin = (float)Math.Sin(rotation.x);
            float ycos = (float)Math.Cos(rotation.y);
            float ysin = (float)Math.Sin(rotation.y);
            float zcos = (float)Math.Cos(rotation.z);
            float zsin = (float)Math.Sin(rotation.z);

            mat4 xaxis = new mat4(new vec4(1, 0, 0, 0),
                new vec4(0, xcos, xsin, 0),
                new vec4(0, xsin, xcos, 0),
                new vec4(0, 0, 0, 1));
            mat4 yaxis = new mat4(new vec4(ycos, 0, -ysin, 0),
                new vec4(0, 1, 0, 0),
                new vec4(ysin, 0, ycos, 0),
                new vec4(0, 0, 0, 1));
            mat4 zaxis = new mat4(new vec4(zcos, zsin, 0, 0),
                new vec4(-zsin, zcos, 0, 0),
                new vec4(0, 0, 0, 0),
                new vec4(0, 0, 0, 1));
            return yaxis;
        }

        protected virtual void OnCollision(GlObject collisionObject)
        {

        }

        protected virtual void OnPrepare()
        {
            this.ProcessCollisions(this.FindRoot());
        }

        protected virtual void Load()
        {

        }

        protected virtual void Unload()
        {

        }

        protected GlObject FindRoot()
        {
            if (this.Parent != null)
            {
                return ((GlObject)this.Parent).FindRoot();
            }
            return this;
        }

        #endregion
    }
}

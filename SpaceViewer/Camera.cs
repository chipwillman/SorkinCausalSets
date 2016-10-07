namespace SpaceViewer
{
    using System;

    using SharpGL;

    using global::SpaceViewer.Objects;

    public class Camera
    {
        public Camera(OpenGL gl)
        {
            Location = new vec3();
            Rotation = new vec3();
            Velocity = new vec3();
            fAcceleration = new vec3();
            LookAt = new vec3(0, 0, 1);
            fLookAtAcceleration = new vec3();
            fLookAtVelocity = new vec3();
            fUp = new vec3(0, 1, 0);
            GL = gl;
        }

        public OpenGL GL { get; set; }

        public dynamic BillboardMatrix
        {
            get { return fBillboardMatrix; }
            set { fBillboardMatrix = value; }
        }

        public event EventHandler EyePartChanged;
        public vec3 EyePart
        {
            get { return Location; }
            set
            {
                if (Location != value)
                {
                    Location = value;
                    if (EyePartChanged != null)
                    {
                        EyePartChanged(this, EventArgs.Empty);
                    }
                }
                Location = value;
            }
        }

        public vec3 StartPos;
        public vec3 StartRot;

        public vec3 EndPos;
        public vec3 EndRot;

        private dynamic fMatrixWorld;
        public dynamic MatrixWorld
        {
            get
            {
                return fMatrixWorld;
            }
            set
            {
                fMatrixWorld = value;
            }
        }

        public float RotationVelocity;
        public float RotationAccelleration;

        public event EventHandler LookAtChanged;
        public vec3 LookAt
        {
            get
            {
                return fLookAt;
            }
            set
            {
                fLookAt = value;
                if (LookAtChanged != null)
                {
                    LookAtChanged(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler VelocityChanged;
        public vec3 Velocity
        {
            get { return fVelocity; }
            set
            {
                if (value.Length() > 15)
                {
                    value.Normalize();
                    value *= 15f;
                }

                if (value.Length() < -15)
                {
                    value.Normalize();
                    value *= -15f;
                }

                fVelocity = value;
                if (VelocityChanged != null)
                {
                    VelocityChanged(this, EventArgs.Empty);
                }
            }
        }

        public vec3 Location
        {
            get { return fLocation; }
            set
            {
                fLocation = value;
            }
        }

        private vec3 fRotation;
        public event EventHandler RotationChanged;
        public vec3 Rotation
        {
            get { return fRotation; }
            set
            {
                fRotation = value;
                if (RotationChanged != null)
                {
                    RotationChanged(this, EventArgs.Empty);
                }
            }
        }

        public float Yaw
        {
            get { return RAD2DEG(Rotation.y); }
            set
            {
                if (value >= 360.0f)
                {
                    while (value > 360f) value -= 360f;
                    fRotation.y = DEG2RAD(value);
                }
                else if (value <= -360.0f)
                {
                    while (value <= -360f) value += 360f;
                    fRotation.y = DEG2RAD(value);
                }
                else
                {
                    fRotation.y = DEG2RAD(value);
                }
            }
        }

        public float Pitch
        {
            get { return RAD2DEG(fRotation.x); }
            set
            {
                if (value > 60.0f)
                {
                    value = 60.0f;
                }
                if (value < -60.0f)
                {
                    value = -60.0f;
                }
                fRotation.x = DEG2RAD(value);
            }
        }

        public vec3 Front
        {
            get
            {
                vec3 cameraFront;
                cameraFront.x = (float)Math.Cos(Rotation.y) * (float)Math.Cos(Rotation.x);
                cameraFront.y = (float)Math.Sin(Rotation.x);
                cameraFront.z = (float)Math.Sin(Rotation.y) * (float)Math.Cos(Rotation.x);
                cameraFront.Normalize();
                return cameraFront;
            }
        }

        public vec3 Up
        {
            get
            {
                return new vec3(0.0f, 1.0f, 0.0f);
            }
        }

        public void Center()
        {
            fRotation.y = 0.0f;
        }

        public void IncrementCameraYaw(float Angle)
        {
            fRotation.x += DEG2RAD(Angle);
        }

        public void IncrementCameraPitch(float Angle)
        {
            fRotation.y += DEG2RAD(Angle);
        }

        public void SetBillBoardMatrix(vec3 position)
        {
            fBillboardMatrix.M41 = position.x;
            fBillboardMatrix.M42 = position.y;
            fBillboardMatrix.M43 = position.z;
            Matrices.Billboard = fBillboardMatrix;
        }

        public static readonly MatrixCollection Matrices = new MatrixCollection();

        public dynamic GetMatrix()
        {
            Update();
            return MatrixWorld;
        }

        #region Implementation


        protected dynamic fBillboardMatrix;

        protected vec3 fInitPosition;
        protected vec3 fFinalPosition;
        protected vec3 fInitLookAt;
        protected vec3 fFinalLookAt;

        protected vec3 fLookAtVelocity;
        protected vec3 fLookAtAcceleration;

        protected vec3 fUp;
        protected vec3 fForward;
        protected vec3 fRight;

        protected vec3 fLocation;
        protected vec3 fLookAt;
        protected vec3 fVelocity;
        protected vec3 fAcceleration;

        protected const float PI = 3.14159265359f;

        protected float DEG2RAD(float a)
        {
            return PI / 180 * (a);
        }

        protected float RAD2DEG(float a)
        {
            return 180 / PI * (a);
        }

        public bool Point(float XEye, float YEye, float ZEye, float XAt, float YAt, float ZAt)
        {
            float XRot, YRot, XDiff, YDiff, ZDiff;

            // Calculate angles between points
            XDiff = XAt - XEye;
            YDiff = YAt - YEye;
            ZDiff = ZAt - ZEye;
            XRot = (float)Math.Atan2(-YDiff, Math.Sqrt(XDiff * XDiff + ZDiff * ZDiff));
            YRot = (float)Math.Atan2(XDiff, ZDiff);

            Location = new vec3(XEye, YEye, ZEye);
            Rotation = new vec3(XRot, YRot, 0.0f);

            return true;
        }

        public bool SetStartTrack()
        {
            StartPos.x = Location.z;
            StartPos.y = Location.y;
            StartPos.z = Location.z;
            StartRot.x = Rotation.x;
            StartRot.y = Rotation.y;
            StartRot.z = Rotation.z;
            return true;
        }

        public bool SetEndTrack()
        {
            EndPos.x = Location.x;
            EndPos.y = Location.y;
            EndPos.z = Location.z;
            EndRot.x = Rotation.x;
            EndRot.y = Rotation.y;
            EndRot.z = Rotation.z;
            return true;
        }

        //---------------------------------------------------------------
        /// <summary>
        /// Track uses the predefined Start and End Track Positions and Rotation and Positions the Camera
        /// </summary>
        /// <param name="Time">Percentage of Ellapsed Time</param>
        /// <param name="Length">Total length of time in milliseconds</param>
        /// <returns></returns>
        //---------------------------------------------------------------
        public bool Track(float Time, float Length)
        {
            float x, y, z;
            float TimeOffset;

            TimeOffset = Length * Time;

            x = (EndPos.x - StartPos.x) / Length * TimeOffset;
            y = (EndPos.y - StartPos.y) / Length * TimeOffset;
            z = (EndPos.z - StartPos.z) / Length * TimeOffset;
            Location = new vec3(StartPos.x + x, StartPos.y + y, StartPos.z + z);

            x = (EndRot.x - StartRot.x) / Length * TimeOffset;
            y = (EndRot.y - StartRot.y) / Length * TimeOffset;
            z = (EndRot.z - StartRot.z) / Length * TimeOffset;
            Rotation = new vec3(StartRot.x + x, StartRot.y + y, StartRot.z + z);

            return true;
        }

        public bool Update()
        {
            return true;
        }

        public void Animate(float deltaTime)
        {
            float rotationSpeed = ClipSpeed(this.RotationVelocity * deltaTime, 500f);
            if (Math.Abs(rotationSpeed) > 0.1)
            {
                RotationAccelleration = RotationVelocity * -2f;
                RotationVelocity += RotationAccelleration * deltaTime;
                this.Yaw += rotationSpeed * deltaTime ;
            }
            else
            {
                RotationAccelleration = 0;
                RotationVelocity = 0;
            }

            float cosineYaw = Front.x;// (float)Math.Cos(this.Rotation.y);
            float sinYaw = Front.z;// (float)Math.Sin(this.Rotation.y);
            //float sinPitch = (float)Math.Sin(this.Rotation.x);

            if (Velocity.Length() > 0.04f || new vec3(fAcceleration.x, 0, fAcceleration.z).Length() > 0.02f)
            {
                fAcceleration = Velocity * -2f;
            }
            else
            {
                fAcceleration = new vec3();
                Velocity = new vec3();
            }

            float speed = ClipSpeed(this.Velocity.z, 15f);
            float strafeSpeed = ClipSpeed(this.Velocity.x, 10f);


            var delta = new vec3();

            //delta.y += Velocity.y * deltaTime;
            delta.x += (cosineYaw * speed  - (float)(Math.Sin(-this.Rotation.y + PI)) * strafeSpeed) * deltaTime;
            delta.z += (sinYaw * speed  - (float)(Math.Cos(-this.Rotation.y + PI)) * strafeSpeed) * deltaTime;
            if (Math.Abs(delta.x) < 0.0001) delta.x = 0;
            if (Math.Abs(delta.z) < 0.0001) delta.z = 0;
            Location += delta;

            //fAcceleration.y = -9.8f;
            Velocity += fAcceleration * deltaTime;

            GL.LookAt(Location.x, Location.y, Location.z,
                        Location.x + Front.x, Location.y + Front.y, Location.z + Front.z,
                        Up.x, Up.y, Up.z);
        }

        private static float ClipSpeed(float value, float maximum)
        {
            if (value > maximum)
            {
                value = maximum;
            }
            if (value < -maximum)
            {
                value = -maximum;
            }
            return value;
        }

        #endregion

        public bool PointInView(vec3 position)
        {
            var normal = new vec3();
            normal.x = Rotation.x;
            normal.y = Rotation.y;
            normal.z = Rotation.z;
            normal.Normalize();

            return true;
            //return (normal + position).Length() < 0;
        }
    }
}

using System;

namespace SpaceViewer.Objects
{
    /// <summary>
    /// Represents a three dimensional vec3.
    /// </summary>
	public struct vec3
	{
		public float x;
		public float y;
		public float z;

		public float this[int index]
		{
			get 
			{
				if(index == 0) return x;
				else if(index == 1) return y;
				else if(index == 2) return z;
                else throw new Exception("Out of range.");
			}
			set 
			{
				if(index == 0) x = value;
                else if (index == 1) y = value;
                else if (index == 2) z = value;
                else throw new Exception("Out of range.");
			}
		}

		public vec3(float s)
		{
			x = y = z = s;
		}

		public vec3(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
            this.z = z;
		}

        public vec3(vec3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public vec3(vec4 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z; 
        }

        public vec3(vec2 xy, float z)
        {
            this.x = xy.x;
            this.y = xy.y;
            this.z = z;
        }
		
		public static vec3 operator + (vec3 lhs, vec3 rhs)
		{
			return new vec3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
		}

        public static vec3 operator +(vec3 lhs, float rhs)
        {
            return new vec3(lhs.x + rhs, lhs.y + rhs, lhs.z + rhs);
        }

        public static vec3 operator -(vec3 lhs, vec3 rhs)
        {
            return new vec3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        public static vec3 operator - (vec3 lhs, float rhs)
        {
            return new vec3(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs);
        }

        public static vec3 operator *(vec3 self, float s)
		{
			return new vec3(self.x * s, self.y * s, self.z * s);
		}
        public static vec3 operator *(float lhs, vec3 rhs)
        {
            return new vec3(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs);
        }

        public static vec3 operator /(vec3 lhs, float rhs)
        {
            return new vec3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        public static vec3 operator * (vec3 lhs, vec3 rhs)
        {
            return new vec3(rhs.x * lhs.x, rhs.y * lhs.y, rhs.z * lhs.z);
        }

        public float[] to_array()
        {
            return new[] { x, y, z };
        }

        public override bool Equals(object obj)
        {
            if (obj is vec3)
            {
                vec3 vec3 = (vec3)obj;
                return Math.Abs(vec3.x - this.x) < 0.001f && Math.Abs(vec3.y - this.y) < 0.001f && Math.Abs(vec3.z - this.z) < 0.001f;
            }
            return false;
        }

        public override int GetHashCode()
        {
            try
            {
                var hash = 17;
                hash = hash * 23 + (int)x * 1000;
                hash = hash * 23 + (int)y * 1000;
                hash = hash * 23 + (int)z * 1000;
                return hash;
            }
            catch (NullReferenceException)
            {
                return -1;
            }
        }

        public static bool operator ==(vec3 x, vec3 y)
        {
            try
            {
                return !(object.Equals(null, x)) && !(object.Equals(null, x)) && Math.Abs(x.x - y.x) < 0.001f && Math.Abs(x.y - y.y) < 0.001f && Math.Abs(x.z - y.z) < 0.001f;
            }
            catch (Exception)
            {
            }
            return false;
        }

        public static bool operator !=(vec3 x, vec3 y)
        {
            return !(x == y);
        }

        public float Length()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public vec3 Unitvec3()
        {
            return this / this.Length();
        }

        public void Normalize()
        {
            var result = this / this.Length();
            x = result.x;
            y = result.y;
            z = result.z;
        }

        public float Angle(vec3 normal)
        {
            return (float)Math.Acos(this % normal);
        }

        public vec3 CrossProduct(vec3 vec3)
        {
            return new vec3(y * vec3.z - z * vec3.y, z * vec3.x - x * vec3.z, x * vec3.y - y * vec3.x);
        }

        public static vec3 operator ^(vec3 x, vec3 y)
        {
            return new vec3(x.y * y.z - x.z * y.y, x.z * y.x - x.x * y.z, x.x * y.y - x.y * y.x);
        }

        public float DotProduct(vec3 vec3)
        {
            return x * vec3.x + y * vec3.y + z * vec3.z;
        }

        public static float operator %(vec3 x, vec3 y)
        {
            return x.x * y.x + x.y * y.y + x.z * y.z;
        }

    }
}
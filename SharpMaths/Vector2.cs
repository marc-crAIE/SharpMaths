using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpMaths
{
    public struct Vector2
    {
        public float x, y;

        public Vector2() : this(0.0f) { }

        public Vector2(float f) : this(f, f) { }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(Vector3 vec3)
        {
            this.x = vec3.x;
            this.y = vec3.y;
        }

        public Vector2(Vector4 vec4)
        {
            this.x = vec4.x;
            this.y = vec4.y;
        }

        public float Dot(Vector2 v)
        {
            return this.x * v.x + this.y * v.y;
        }

        public float Cross(Vector2 v)
        {
            return this.x * v.x - this.y * v.y;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        public void Normalize()
        {
            float mag = Magnitude();

            if (mag == 0.0f)
                return;

            this.x /= mag;
            this.y /= mag;
        }

        public static Vector2 operator +(Vector2 v, float scalar) => new Vector2(v.x + scalar, v.y + scalar);
        public static Vector2 operator +(float scalar, Vector2 v) => v + scalar;
        public static Vector2 operator +(Vector2 v1, Vector2 v2) => new Vector2(v1.x + v2.x, v1.y + v2.y);
        public static Vector2 operator +(Vector2 v1, Vector3 v2) => new Vector2(v1.x + v2.x, v1.y + v2.y);
        public static Vector2 operator +(Vector2 v1, Vector4 v2) => new Vector2(v1.x + v2.x, v1.y + v2.y);

        public static Vector2 operator -(Vector2 v, float scalar) => new Vector2(v.x - scalar, v.y - scalar);
        public static Vector2 operator -(float scalar, Vector2 v) => v - scalar;
        public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1.x - v2.x, v1.y - v2.y);
        public static Vector2 operator -(Vector2 v1, Vector3 v2) => new Vector2(v1.x - v2.x, v1.y - v2.y);
        public static Vector2 operator -(Vector2 v1, Vector4 v2) => new Vector2(v1.x - v2.x, v1.y - v2.y);

        public static Vector2 operator *(Vector2 v, float scalar) => new Vector2(v.x * scalar, v.y * scalar);
        public static Vector2 operator *(float scalar, Vector2 v) => v * scalar;
        public static Vector2 operator *(Vector2 v1, Vector2 v2) => new Vector2(v1.x * v2.x, v1.y * v2.y);
        public static Vector2 operator *(Vector2 v1, Vector3 v2) => new Vector2(v1.x * v2.x, v1.y * v2.y);
        public static Vector2 operator *(Vector2 v1, Vector4 v2) => new Vector2(v1.x * v2.x, v1.y * v2.y);

        public static Vector2 operator /(Vector2 v, float scalar) => new Vector2(v.x / scalar, v.y / scalar);
        public static Vector2 operator /(float scalar, Vector2 v) => v / scalar;
        public static Vector2 operator /(Vector2 v1, Vector2 v2) => new Vector2(v1.x / v2.x, v1.y / v2.y);
        public static Vector2 operator /(Vector2 v1, Vector3 v2) => new Vector2(v1.x / v2.x, v1.y / v2.y);
        public static Vector2 operator /(Vector2 v1, Vector4 v2) => new Vector2(v1.x / v2.x, v1.y / v2.y);

        public static bool operator ==(Vector2 v1, Vector2 v2) => (v1.x == v2.x) && (v1.y == v2.y);
        public static bool operator !=(Vector2 v1, Vector2 v2) => !(v1 == v2);

        public float this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return x;
                    case 1: return y;
                }
                return 0;
            }
            set
            {
                switch (i)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                }
            }
        }

        public static implicit operator Vector2(Vector3 v) => new Vector2(v.x, v.y);
        public static implicit operator Vector2(Vector4 v) => new Vector2(v.x, v.y);

        public override string ToString() => $"( {x}, {y} )";
    }
}

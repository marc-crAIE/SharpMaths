using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpMaths
{
    public struct Vector3
    {
        public float x, y, z;

        public Vector3() : this(0.0f) { }

        public Vector3(float f) : this(f, f, f) { }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(Vector2 vec2, float z = 0.0f)
        {
            this.x = vec2.x;
            this.y = vec2.y;
            this.z = z;
        }

        public Vector3(Vector4 vec4)
        {
            this.x = vec4.x;
            this.y = vec4.y;
            this.z = vec4.z;
        }

        public float Dot(Vector3 v)
        {
            return this.x * v.x + this.y * v.y + this.z * v.z;
        }

        public Vector3 Cross(Vector3 v)
        {
            return new Vector3(
                this.y * v.z - this.z * v.y,
                this.z * v.x - this.x * v.z,
                this.x * v.y - this.y * v.x
            );
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public void Normalize()
        {
            float mag = Magnitude();

            if (mag == 0.0f)
                return;

            this.x /= mag;
            this.y /= mag;
            this.z /= mag;
        }

        public static Vector3 operator +(Vector3 v, float scalar) => new Vector3(v.x + scalar, v.y + scalar, v.z + scalar);
        public static Vector3 operator +(float scalar, Vector3 v) => v + scalar;
        public static Vector3 operator +(Vector3 v1, Vector2 v2) => new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z);
        public static Vector3 operator +(Vector3 v1, Vector3 v2) => new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        public static Vector3 operator +(Vector3 v1, Vector4 v2) => new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);

        public static Vector3 operator -(Vector3 v, float scalar) => new Vector3(v.x - scalar, v.y - scalar, v.z - scalar);
        public static Vector3 operator -(float scalar, Vector3 v) => v - scalar;
        public static Vector3 operator -(Vector3 v1, Vector2 v2) => new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z);
        public static Vector3 operator -(Vector3 v1, Vector3 v2) => new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        public static Vector3 operator -(Vector3 v1, Vector4 v2) => new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);

        public static Vector3 operator *(Vector3 v, float scalar) => new Vector3(v.x * scalar, v.y * scalar, v.z * scalar);
        public static Vector3 operator *(float scalar, Vector3 v) => v * scalar;
        public static Vector3 operator *(Vector3 v1, Vector2 v2) => new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z);
        public static Vector3 operator *(Vector3 v1, Vector3 v2) => new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        public static Vector3 operator *(Vector3 v1, Vector4 v2) => new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);

        public static Vector3 operator /(Vector3 v, float scalar) => new Vector3(v.x / scalar, v.y / scalar, v.z / scalar);
        public static Vector3 operator /(float scalar, Vector3 v) => v / scalar;
        public static Vector3 operator /(Vector3 v1, Vector2 v2) => new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z);
        public static Vector3 operator /(Vector3 v1, Vector3 v2) => new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        public static Vector3 operator /(Vector3 v1, Vector4 v2) => new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);

        public override string ToString() => $"( {x}, {y}, {z} )";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
namespace SharpMaths
{
    public struct Vector4
    {
        public float x, y, z, w;

        #region Constructors

        public Vector4() : this(0.0f) { }

        public Vector4(float f) : this(f, f, f, f) { }

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Vector4(Vector2 vec2, float z = 0.0f, float w = 0.0f)
        {
            this.x = vec2.x;
            this.y = vec2.y;
            this.z = z;
            this.w = w;
        }

        public Vector4(Vector3 vec3, float w = 0.0f)
        {
            this.x = vec3.x;
            this.y = vec3.y;
            this.z = vec3.z;
            this.w = w;
        }

        #endregion

        #region General Functions

        public float Dot(Vector4 v)
        {
            return this.x * v.x + this.y * v.y + this.z * v.z + this.w * v.w;
        }

        public Vector4 Cross(Vector4 v)
        {
            return new Vector4(
                this.y * v.z - this.z * v.y,
                this.z * v.x - this.x * v.z,
                this.x * v.y - this.y * v.x,
                0.0f
            );
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
        }

        public void Normalize()
        {
            float mag = Magnitude();

            if (mag == 0.0f)
                return;

            this /= mag;
        }

        #endregion

        #region Operators

        #region Binary Operators

        public static Vector4 operator +(Vector4 v, float scalar) => new Vector4(v.x + scalar, v.y + scalar, v.z + scalar, v.w + scalar);
        public static Vector4 operator +(float scalar, Vector4 v) => v + scalar;
        public static Vector4 operator +(Vector4 v1, Vector2 v2) => new Vector4(v1.x + v2.x, v1.y + v2.y, v1.z, v1.w);
        public static Vector4 operator +(Vector4 v1, Vector3 v2) => new Vector4(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z, v1.w);
        public static Vector4 operator +(Vector4 v1, Vector4 v2) => new Vector4(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z, v1.w + v2.w);

        public static Vector4 operator -(Vector4 v, float scalar) => new Vector4(v.x - scalar, v.y - scalar, v.z - scalar, v.w - scalar);
        public static Vector4 operator -(float scalar, Vector4 v) => v - scalar;
        public static Vector4 operator -(Vector4 v1, Vector2 v2) => new Vector4(v1.x - v2.x, v1.y - v2.y, v1.z, v1.w);
        public static Vector4 operator -(Vector4 v1, Vector3 v2) => new Vector4(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z, v1.w);
        public static Vector4 operator -(Vector4 v1, Vector4 v2) => new Vector4(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z, v1.w - v2.w);

        public static Vector4 operator *(Vector4 v, float scalar) => new Vector4(v.x * scalar, v.y * scalar, v.z * scalar, v.w * scalar);
        public static Vector4 operator *(float scalar, Vector4 v) => v * scalar;
        public static Vector4 operator *(Vector4 v1, Vector2 v2) => new Vector4(v1.x * v2.x, v1.y * v2.y, v1.z, v1.w);
        public static Vector4 operator *(Vector4 v1, Vector3 v2) => new Vector4(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z, v1.w);
        public static Vector4 operator *(Vector4 v1, Vector4 v2) => new Vector4(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z, v1.w * v2.w);
        public static Vector4 operator *(Quaternion q, Vector4 v) => new Vector4(q * (Vector3)v, v.w);
        public static Vector4 operator *(Vector4 v, Quaternion q) => q.Inverse() * v;
        public static Vector4 operator *(Matrix4 m, Vector4 v)
        {
            return new Vector4(
                m[0, 0] * v.x + m[1, 0] * v.y + m[2, 0] * v.z + m[3, 0] * v.w,
			    m[0, 1] * v.x + m[1, 1] * v.y + m[2, 1] * v.z + m[3, 1] * v.w,
			    m[0, 2] * v.x + m[1, 2] * v.y + m[2, 2] * v.z + m[3, 2] * v.w,
			    m[0, 3] * v.x + m[1, 3] * v.y + m[2, 3] * v.z + m[3, 3] * v.w);
        }

        public static Vector4 operator /(Vector4 v, float scalar) => new Vector4(v.x / scalar, v.y / scalar, v.z / scalar, v.w / scalar);
        public static Vector4 operator /(float scalar, Vector4 v) => v / scalar;
        public static Vector4 operator /(Vector4 v1, Vector2 v2) => new Vector4(v1.x / v2.x, v1.y / v2.y, v1.z, v1.w);
        public static Vector4 operator /(Vector4 v1, Vector3 v2) => new Vector4(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z, v1.w);
        public static Vector4 operator /(Vector4 v1, Vector4 v2) => new Vector4(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z, v1.w / v2.w);

        #endregion

        #region Comparison Operators

        public static bool operator ==(Vector4 v1, Vector4 v2) => v1.x.IsEqual(v2.x) && v1.y.IsEqual(v2.y) && v1.z.IsEqual(v2.z) && v1.w.IsEqual(v2.w);
        public static bool operator !=(Vector4 v1, Vector4 v2) => !(v1 == v2);

        #endregion

        #region Unary Operators

        public static Vector4 operator +(Vector4 v)
        {
            return v;
        }

        public static Vector4 operator -(Vector4 v)
        {
            Vector4 result = new Vector4();
            result.x = -v.x;
            result.y = -v.y;
            result.z = -v.z;
            result.w = -v.w;
            return result;
        }

        public static Vector4 operator ++(Vector4 v)
        {
            Vector4 result = new Vector4();
            result.x = v.x++;
            result.y = v.y++;
            result.z = v.z++;
            result.w = v.w++;
            return v;
        }

        public static Vector4 operator --(Vector4 v)
        {
            Vector4 result = new Vector4();
            result.x = v.x--;
            result.y = v.y--;
            result.z = v.z--;
            result.w = v.w--;
            return v;
        }

        #endregion

        #endregion

        #region Accessors

        public float this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return x; 
                    case 1: return y; 
                    case 2: return z; 
                    case 3: return w;
                }
                return 0;
            }
            set
            {
                switch (i)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    case 3: w = value; break;
                }
            }
        }

        #endregion

        #region Type Conversion

        public static implicit operator Vector4(Vector3 v) => new Vector4(v.x, v.y, v.z, 0.0f);
        public static implicit operator Vector4(Vector2 v) => new Vector4(v.x, v.y, 0.0f, 0.0f);

        public static implicit operator System.Numerics.Vector2(Vector4 v) => new System.Numerics.Vector2(v.x, v.y);
        public static implicit operator System.Numerics.Vector3(Vector4 v) => new System.Numerics.Vector3(v.x, v.y, v.z);
        public static implicit operator System.Numerics.Vector4(Vector4 v) => new System.Numerics.Vector4(v.x, v.y, v.z, v.w);

        public static implicit operator Vector4(System.Numerics.Vector2 v) => new Vector4(v.X, v.Y, 0.0f, 0.0f);
        public static implicit operator Vector4(System.Numerics.Vector3 v) => new Vector4(v.X, v.Y, v.Z, 0.0f);
        public static implicit operator Vector4(System.Numerics.Vector4 v) => new Vector4(v.X, v.Y, v.Z, v.W);

        #endregion

        #region Function Overloads

        public override string ToString() => $"( {x}, {y}, {z}, {w} )";

        #endregion
    }
}

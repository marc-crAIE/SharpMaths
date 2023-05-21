using System.Runtime.CompilerServices;

namespace SharpMaths
{
    public struct Vector3
    {
        public float x, y, z;

        #region Constructors

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

        #endregion

        #region General Functions

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

            this /= mag;
        }

        #endregion

        #region Operators

        #region Binary Operators

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
        public static Vector3 operator *(Quaternion q, Vector3 v)
        {
            Quaternion vQuat = new Quaternion(v.x, v.y, v.z, 0.0f);
            Quaternion resultQuat = q * vQuat * q.Conjugate();

            return new Vector3(resultQuat.x, resultQuat.y, resultQuat.z);
        }
        public static Vector3 operator *(Vector3 v, Quaternion q) => q.Inverse() * v;
        public static Vector3 operator *(Matrix3 m, Vector3 v)
        {
            return new Vector3(
                m[0, 0] * v.x + m[1, 0] * v.y + m[2, 0] * v.z,
                m[0, 1] * v.x + m[1, 1] * v.y + m[2, 1] * v.z,
                m[0, 2] * v.x + m[1, 2] * v.y + m[2, 2] * v.z);
        }

        public static Vector3 operator /(Vector3 v, float scalar) => new Vector3(v.x / scalar, v.y / scalar, v.z / scalar);
        public static Vector3 operator /(float scalar, Vector3 v) => v / scalar;
        public static Vector3 operator /(Vector3 v1, Vector2 v2) => new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z);
        public static Vector3 operator /(Vector3 v1, Vector3 v2) => new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        public static Vector3 operator /(Vector3 v1, Vector4 v2) => new Vector3(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);

        #endregion

        #region Comparison Operators

        public static bool operator ==(Vector3 v1, Vector3 v2) => v1.x.IsEqual(v2.x) && v1.y.IsEqual(v2.y) && v1.z.IsEqual(v2.z);
        public static bool operator !=(Vector3 v1, Vector3 v2) => !(v1 == v2);

        #endregion

        #region Unary Operators

        public static Vector3 operator +(Vector3 v)
        {
            return v;
        }

        public static Vector3 operator -(Vector3 v)
        {
            Vector3 result = new Vector3();
            result.x = -v.x;
            result.y = -v.y;
            result.z = -v.z;
            return result;
        }

        public static Vector3 operator ++(Vector3 v)
        {
            Vector3 result = new Vector3();
            result.x = v.x++;
            result.y = v.y++;
            result.z = v.z++;
            return v;
        }

        public static Vector3 operator --(Vector3 v)
        {
            Vector3 result = new Vector3();
            result.x = v.x--;
            result.y = v.y--;
            result.z = v.z--;
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
                }
            }
        }

        #endregion

        #region Type Conversion

        public static implicit operator Vector3(Vector2 v) => new Vector3(v.x, v.y, 0.0f);
        public static implicit operator Vector3(Vector4 v) => new Vector3(v.x, v.y, v.z);

        public static implicit operator System.Numerics.Vector2(Vector3 v) => new System.Numerics.Vector2(v.x, v.y);
        public static implicit operator System.Numerics.Vector3(Vector3 v) => new System.Numerics.Vector3(v.x, v.y, v.z);
        public static implicit operator System.Numerics.Vector4(Vector3 v) => new System.Numerics.Vector4(v.x, v.y, v.z, 0.0f);

        public static implicit operator Vector3(System.Numerics.Vector2 v) => new Vector3(v.X, v.Y, 0.0f);
        public static implicit operator Vector3(System.Numerics.Vector3 v) => new Vector3(v.X, v.Y, v.Z);
        public static implicit operator Vector3(System.Numerics.Vector4 v) => new Vector3(v.X, v.Y, v.Z);

        #endregion

        #region Function Overloads

        public override string ToString() => $"( {x}, {y}, {z} )";

        #endregion
    }
}

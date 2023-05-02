using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpMaths
{
    public struct Quaternion
    {
        public float x, y, z, w;

        #region Constructors

        public Quaternion() : this(0, 0, 0, 1) { }

        public Quaternion(float f) : this(f, f, f, f) { }

        public Quaternion(Vector3 eulerAngles)
        {
            this = Euler(eulerAngles);
        }

        public Quaternion(Vector4 v) : this(v.w, v.x, v.y, v.z) { }

        public Quaternion(float w, float x, float y, float z)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        #endregion

        #region General Functions

        public static Quaternion Identity() => new Quaternion(0, 0, 0, 1);

        public float Dot(Quaternion v)
        {
            return this.w * v.w +this.x * v.x + this.y * v.y + this.z * v.z;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(w * w + x * x + y * y + z * z);
        }

        public void Normalize()
        {
            float mag = Magnitude();

            if (mag == 0.0f)
                return;

            this /= mag;
        }

        public Quaternion Conjugate()
        {
            return new Quaternion(w, -x, -y, -z);
        }

        public Quaternion Inverse()
        {
            return Conjugate() / Dot(this);
        }

        public static Quaternion Euler(Vector3 v)
        {
            Vector3 c = new Vector3((float)Math.Cos(v.x / 2), (float)Math.Cos(v.y / 2), (float)Math.Cos(v.z / 2));
            Vector3 s = new Vector3((float)Math.Sin(v.x / 2), (float)Math.Sin(v.y / 2), (float)Math.Sin(v.z / 2));

            Quaternion quat = new Quaternion();
            quat.w = c.x * c.y * c.z + s.x * s.y * s.z;
            quat.x = s.x * c.y * c.z - c.x * s.y * s.z;
            quat.y = c.x * s.y * c.z + s.x * c.y * s.z;
            quat.z = c.x * c.y * s.z - s.x * s.y * c.z;
            return quat;
        }

        public static Quaternion FromAxisAngle(Vector3 axis, float angle)
        {
            float sin = (float)Math.Sin(angle / 2);
            float cos = (float)Math.Cos(angle / 2);
            return new Quaternion(cos, axis.x * sin, axis.y * sin, axis.z * sin);
        }

        #endregion

        #region Operators

        #region Binary Operators

        public static Quaternion operator +(Quaternion a, Quaternion b) => new Quaternion(a.w + b.w, a.x + b.x, a.y + b.y, a.z + b.z);

        public static Quaternion operator -(Quaternion a, Quaternion b) => new Quaternion(a.w - b.w, a.x - b.x, a.y - b.y, a.z - b.z);

        public static Quaternion operator *(Quaternion a, float scalar) => new Quaternion(a.w * scalar, a.x * scalar, a.y * scalar, a.z * scalar);
        public static Quaternion operator *(Quaternion a, Quaternion b)
        {
            return new Quaternion(
                a.w * b.w - a.x * b.x - a.y * b.y - a.z * b.z,
                a.w * b.x + a.x * b.w + a.y * b.z - a.z * b.y,
                a.w * b.y - a.x * b.z + a.y * b.w + a.z * b.x,
                a.w * b.z + a.x * b.y - a.y * b.x + a.z * b.w
            );
        }

        public static Quaternion operator /(Quaternion q, float scalar) => new Quaternion(q.w / scalar, q.x / scalar, q.y / scalar, q.z / scalar);

        #endregion

        #endregion

        #region Type Conversions

        public static implicit operator Vector4(Quaternion q) => new Vector4(q.x, q.y, q.z, q.w);

        #endregion

        #region Function Overloads

        public override string ToString()
        {
            return $"( {w} {{ {x}, {y}, {z} }} )";
        }

        #endregion
    }
}

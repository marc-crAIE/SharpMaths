namespace SharpMaths
{
    public struct Vector2
    {
        public float x, y;

        #region Constructors

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

        #endregion

        #region General Functions

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

        #endregion

        #region Operators

        #region Binary Operators

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

        #endregion

        #region Comparison Operators

        public static bool operator ==(Vector2 v1, Vector2 v2) => (v1.x == v2.x) && (v1.y == v2.y);
        public static bool operator !=(Vector2 v1, Vector2 v2) => !(v1 == v2);

        #endregion

        #region Unary Operators

        public static Vector2 operator +(Vector2 v)
        {
            return v;
        }

        public static Vector2 operator -(Vector2 v)
        {
            Vector2 result = new Vector2();
            result.x = -v.x;
            result.y = -v.y;
            return result;
        }

        public static Vector2 operator ++(Vector2 v)
        {
            Vector2 result = new Vector2();
            result.x = v.x++;
            result.y = v.y++;
            return v;
        }

        public static Vector2 operator --(Vector2 v)
        {
            Vector2 result = new Vector2();
            result.x = v.x--;
            result.y = v.y--;
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

        #endregion

        #region Type Conversion

        public static implicit operator Vector2(Vector3 v) => new Vector2(v.x, v.y);
        public static implicit operator Vector2(Vector4 v) => new Vector2(v.x, v.y);

        public static implicit operator System.Numerics.Vector2(Vector2 v) => new System.Numerics.Vector2(v.x, v.y);
        public static implicit operator System.Numerics.Vector3(Vector2 v) => new System.Numerics.Vector3(v.x, v.y, 0.0f);
        public static implicit operator System.Numerics.Vector4(Vector2 v) => new System.Numerics.Vector4(v.x, v.y, 0.0f, 0.0f);

        public static implicit operator Vector2(System.Numerics.Vector2 v) => new Vector2(v.X, v.Y);
        public static implicit operator Vector2(System.Numerics.Vector3 v) => new Vector2(v.X, v.Y);
        public static implicit operator Vector2(System.Numerics.Vector4 v) => new Vector2(v.X, v.Y);

        #endregion

        #region Function Overloads

        public override string ToString() => $"( {x}, {y} )";

        #endregion
    }
}

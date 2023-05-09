namespace SharpMaths
{
    public struct Matrix4
    {
        private float[,] matrix;

        #region Properties

        // First row
        public Vector4 m0 { get => this[0]; set => this[0] = value; }
        public float m00 { get => matrix[0, 0]; set => matrix[0, 0] = value; }
        public float m01 { get => matrix[0, 1]; set => matrix[0, 1] = value; }
        public float m02 { get => matrix[0, 2]; set => matrix[0, 2] = value; }
        public float m03 { get => matrix[0, 3]; set => matrix[0, 3] = value; }

        // Second row
        public Vector4 m1 { get => this[1]; set => this[1] = value; }
        public float m10 { get => matrix[1, 0]; set => matrix[1, 0] = value; }
        public float m11 { get => matrix[1, 1]; set => matrix[1, 1] = value; }
        public float m12 { get => matrix[1, 2]; set => matrix[1, 2] = value; }
        public float m13 { get => matrix[1, 3]; set => matrix[1, 3] = value; }

        // Third row
        public Vector4 m2 { get => this[2]; set => this[2] = value; }
        public float m20 { get => matrix[2, 0]; set => matrix[2, 0] = value; }
        public float m21 { get => matrix[2, 1]; set => matrix[2, 1] = value; }
        public float m22 { get => matrix[2, 2]; set => matrix[2, 2] = value; }
        public float m23 { get => matrix[2, 3]; set => matrix[2, 3] = value; }

        // Forth row
        public Vector4 m3 { get => this[3]; set => this[3] = value; }
        public float m30 { get => matrix[3, 0]; set => matrix[3, 0] = value; }
        public float m31 { get => matrix[3, 1]; set => matrix[3, 1] = value; }
        public float m32 { get => matrix[3, 2]; set => matrix[3, 2] = value; }
        public float m33 { get => matrix[3, 3]; set => matrix[3, 3] = value; }

        #endregion

        #region Constructors

        public Matrix4() : this(1.0f) { }

        public Matrix4(float f)
        {
            this.matrix = new float[4, 4];
            this.matrix[0, 0] = f;
            this.matrix[1, 1] = f;
            this.matrix[2, 2] = f;
            this.matrix[3, 3] = f;
        }

        public Matrix4(float[,] m)
        {
            if (m.GetLength(0) != 4 || m.GetLength(1) != 4)
                throw new ArgumentException("Input data must be a 4x4 matrix!");

            this.matrix = m;
        }

        public Matrix4(Vector4 m0, Vector4 m1, Vector4 m2, Vector4 m3)
        {
            this.matrix = new float[4, 4];
            this[0] = m0;
            this[1] = m1;
            this[2] = m2;
            this[3] = m3;
        }

        public Matrix4(float m00, float m01, float m02, float m03,
                       float m10, float m11, float m12, float m13,
                       float m20, float m21, float m22, float m23,
                       float m30, float m31, float m32, float m33)
        {
            this.matrix = new float[4, 4];
            matrix[0, 0] = m00; matrix[0, 1] = m01; matrix[0, 2] = m02; matrix[0, 3] = m03;
            matrix[1, 0] = m10; matrix[1, 1] = m11; matrix[1, 2] = m12; matrix[1, 3] = m13;
            matrix[2, 0] = m20; matrix[2, 1] = m21; matrix[2, 2] = m22; matrix[2, 3] = m23;
            matrix[3, 0] = m30; matrix[3, 1] = m31; matrix[3, 2] = m32; matrix[3, 3] = m33;
        }

        #endregion

        #region General Functions

        public static Matrix4 Identity() => new Matrix4(1.0f);

        public float Determinant()
        {
            float q = m11 * m22 * m33 + m21 * m32 * m13 + m31 * m12 * m23 - m11 * m23 * m32 - m12 * m21 * m33 - m13 * m22 * m31;
            float r = m10 * m22 * m33 + m20 * m32 * m13 + m30 * m12 * m23 - m10 * m23 * m32 - m12 * m20 * m33 - m13 * m22 * m30;
            float s = m10 * m21 * m33 + m20 * m31 * m13 + m30 * m11 * m23 - m10 * m23 * m31 - m11 * m20 * m33 - m13 * m21 * m30;
            float t = m10 * m21 * m32 + m20 * m31 * m12 + m30 * m11 * m22 - m10 * m22 * m31 - m11 * m20 * m32 - m12 * m21 * m30;

            return m00 * q - m01 * r + m02 * s - m03 * t;
        }

        public Matrix4 Transpose()
        {
            Matrix4 result = new Matrix4(0.0f);
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    result[row, col] = this[col, row];
                }
            }
            return result;
        }

        public Matrix4 Inverse()
        {
            float det = Determinant();
            if (det == 0)
                throw new InvalidOperationException("Matrix is not invertible.");

            Matrix4 result = new Matrix4(0.0f);

            float m2a1 = m11 * m22 * m33 + m21 * m32 * m13 + m31 * m12 * m23 - m11 * m23 * m32 - m12 * m21 * m33 - m13 * m22 * m31;
            float m2b1 = m10 * m22 * m33 + m20 * m32 * m13 + m30 * m12 * m23 - m10 * m23 * m32 - m12 * m20 * m33 - m13 * m22 * m30;
            float m2c1 = m10 * m21 * m33 + m20 * m31 * m13 + m30 * m11 * m23 - m10 * m23 * m31 - m11 * m20 * m33 - m13 * m21 * m30;
            float m2d1 = m10 * m21 * m32 + m20 * m31 * m12 + m30 * m11 * m22 - m10 * m22 * m31 - m11 * m20 * m32 - m12 * m21 * m30;
            float m2a2 = m01 * m22 * m33 + m21 * m32 * m03 + m31 * m02 * m23 - m01 * m23 * m32 - m02 * m21 * m33 - m03 * m22 * m31;
            float m2b2 = m00 * m22 * m33 + m20 * m32 * m03 + m30 * m02 * m23 - m00 * m23 * m32 - m02 * m20 * m33 - m03 * m22 * m30;
            float m2c2 = m00 * m21 * m33 + m20 * m31 * m03 + m30 * m01 * m23 - m00 * m23 * m31 - m01 * m20 * m33 - m03 * m21 * m30;
            float m2d2 = m00 * m21 * m32 + m20 * m31 * m02 + m30 * m01 * m22 - m00 * m22 * m31 - m01 * m20 * m32 - m02 * m21 * m30;
            float m2a3 = m01 * m12 * m33 + m11 * m32 * m03 + m31 * m02 * m13 - m01 * m13 * m32 - m02 * m11 * m33 - m03 * m12 * m31;
            float m2b3 = m00 * m12 * m33 + m10 * m32 * m03 + m30 * m02 * m13 - m00 * m13 * m32 - m02 * m10 * m33 - m03 * m12 * m30;
            float m2c3 = m00 * m11 * m33 + m10 * m31 * m03 + m30 * m01 * m13 - m00 * m13 * m31 - m01 * m10 * m33 - m03 * m11 * m30;
            float m2d3 = m00 * m11 * m32 + m10 * m31 * m02 + m30 * m01 * m12 - m00 * m12 * m31 - m01 * m10 * m32 - m02 * m11 * m30;
            float m2a4 = m01 * m12 * m23 + m11 * m22 * m03 + m21 * m02 * m13 - m01 * m13 * m22 - m02 * m11 * m23 - m03 * m12 * m21;
            float m2b4 = m00 * m12 * m23 + m10 * m22 * m03 + m20 * m02 * m13 - m00 * m13 * m22 - m02 * m10 * m23 - m03 * m12 * m20;
            float m2c4 = m00 * m11 * m23 + m10 * m21 * m03 + m20 * m01 * m13 - m00 * m13 * m21 - m01 * m10 * m23 - m03 * m11 * m20;
            float m2d4 = m00 * m11 * m22 + m10 * m21 * m02 + m20 * m01 * m12 - m00 * m12 * m21 - m01 * m10 * m22 - m02 * m11 * m20;

            m2b1 = -m2b1; m2d1 = -m2d1;
            m2a2 = -m2a2; m2c2 = -m2c2;
            m2b3 = -m2b3; m2d3 = -m2d3;
            m2a4 = -m2a4; m2c4 = -m2c4;

            result[0, 0] = m2a1; result[1, 0] = m2b1; result[2, 0] = m2c1; result[3, 0] = m2d1;
            result[0, 1] = m2a2; result[1, 1] = m2b2; result[2, 1] = m2c2; result[3, 1] = m2d2;
            result[0, 2] = m2a3; result[1, 2] = m2b3; result[2, 2] = m2c3; result[3, 2] = m2d3;
            result[0, 3] = m2a4; result[1, 3] = m2b4; result[2, 3] = m2c4; result[3, 3] = m2d4;

            return result / det;
        }

        #endregion

        #region Transformation Functions

        public void SetTranslation(Vector3 v) => this *= Translation(v);
        public void SetTranslation(float x, float y, float z) => SetTranslation(new Vector3(x, y, z));

        public void SetRotation(float angle, Vector3 axis) => this *= Rotation(angle, axis);
        public void SetRotation(float angle, float x, float y, float z) => SetRotation(angle, new Vector3(x, y, z));
        public void SetRotationX(float angle) => SetRotation(angle, new Vector3(1.0f, 0.0f, 0.0f));
        public void SetRotationY(float angle) => SetRotation(angle, new Vector3(0.0f, 1.0f, 0.0f));
        public void SetRotationZ(float angle) => SetRotation(angle, new Vector3(0.0f, 0.0f, 1.0f));

        public void SetScale(Vector3 v) => this *= Scale(v);
        public void SetScale(float x, float y, float z) => SetScale(new Vector3(x, y, z));

        #region Create Transform Matrices

        public static Matrix4 Translation(Vector3 v)
        {
            Matrix4 translation = new Matrix4();
            translation[3, 0] = v.x;
            translation[3, 1] = v.y;
            translation[3, 2] = v.z;
            return translation;
        }
        public static Matrix4 Translation(float x, float y, float z) => Translation(new Vector3(x, y, z));

        public static Matrix4 Rotation(float angle, Vector3 axis)
        {
            Matrix4 rotation = new Matrix4();

            axis.Normalize();

            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);

            axis.Normalize();

            Vector3 omc = (1.0f - cos) * axis;

            float x = axis.x;
            float y = axis.y;
            float z = axis.z;

            rotation[0, 0] = cos + omc.x * x;
            rotation[0, 1] = omc.x * y + sin * z;
            rotation[0, 2] = omc.x * z - sin * y;

            rotation[1, 0] = omc.y * x - sin * z;
            rotation[1, 1] = cos + omc.y * y;
            rotation[1, 2] = omc.y * z + sin * x;

            rotation[2, 0] = omc.z * x + sin * y;
            rotation[2, 1] = omc.z * y - sin * x;
            rotation[2, 2] = cos + omc.z * z;

            return rotation;
        }
        public static Matrix4 Rotation(float angle, float x, float y, float z) => Rotation(angle, new Vector3(x, y, z));

        public static Matrix4 RotationX(float angle) => Rotation(angle, new Vector3(1.0f, 0.0f, 0.0f));
        public static Matrix4 RotationY(float angle) => Rotation(angle, new Vector3(0.0f, 1.0f, 0.0f));
        public static Matrix4 RotationZ(float angle) => Rotation(angle, new Vector3(0.0f, 0.0f, 1.0f));

        public static Matrix4 Scale(Vector3 v)
        {
            Matrix4 scale = new Matrix4();
            scale[0, 0] = v.x;
            scale[1, 1] = v.y;
            scale[2, 2] = v.z;
            return scale;
        }
        public static Matrix4 Scale(float x, float y, float z) => Scale(new Vector3(x, y, z));

        #endregion

        #endregion

        #region Operators

        #region Binary Operators

        public static Matrix4 operator +(Matrix4 m, float scalar)
        {
            Matrix4 result = new Matrix4();
            result[0] = m[0] + scalar;
            result[1] = m[1] + scalar;
            result[2] = m[2] + scalar;
            result[3] = m[3] + scalar;
            return result;
        }
        public static Matrix4 operator +(float scalar, Matrix4 m) => m + scalar;

        public static Matrix4 operator +(Matrix4 a, Matrix4 b)
        {
            var result = new Matrix4();
            result[0] = a[0] + b[0];
            result[1] = a[1] + b[1];
            result[2] = a[2] + b[2];
            result[3] = a[3] + b[3];
            return result;
        }

        public static Matrix4 operator -(Matrix4 m, float scalar)
        {
            Matrix4 result = new Matrix4();
            result[0] = m[0] - scalar;
            result[1] = m[1] - scalar;
            result[2] = m[2] - scalar;
            result[3] = m[3] - scalar;
            return result;
        }
        public static Matrix4 operator -(float scalar, Matrix4 m) => m - scalar;

        public static Matrix4 operator -(Matrix4 a, Matrix4 b)
        {
            var result = new Matrix4();
            result[0] = a[0] - b[0];
            result[1] = a[1] - b[1];
            result[2] = a[2] - b[2];
            result[3] = a[3] - b[3];
            return result;
        }

        public static Matrix4 operator *(Matrix4 m, float scalar)
        {
            Matrix4 result = new Matrix4();
            result[0] = m[0] * scalar;
            result[1] = m[1] * scalar;
            result[2] = m[2] * scalar;
            result[3] = m[3] * scalar;
            return result;
        }
        public static Matrix4 operator *(float scalar, Matrix4 m) => m * scalar;

        public static Matrix4 operator *(Matrix4 a, Matrix4 b)
        {
            Matrix4 result = new Matrix4(0.0f);
            result[0] = a[0] * b[0, 0] + a[1] * b[0, 1] + a[2] * b[0, 2] + a[3] * b[0, 3];
            result[1] = a[0] * b[1, 0] + a[1] * b[1, 1] + a[2] * b[1, 2] + a[3] * b[1, 3];
            result[2] = a[0] * b[2, 0] + a[1] * b[2, 1] + a[2] * b[2, 2] + a[3] * b[2, 3];
            result[3] = a[0] * b[3, 0] + a[1] * b[3, 1] + a[2] * b[3, 2] + a[3] * b[3, 3];
            return result;
        }

        public static Matrix4 operator /(Matrix4 m, float scalar)
        {
            Matrix4 result = new Matrix4();
            result[0] = m[0] / scalar;
            result[1] = m[1] / scalar;
            result[2] = m[2] / scalar;
            result[3] = m[3] / scalar;
            return result;
        }
        public static Matrix4 operator /(float scalar, Matrix4 m) => scalar * m.Inverse();
        public static Matrix4 operator /(Matrix4 a, Matrix4 b) => a * b.Inverse();

        #endregion

        #region Comparison Operators

        public static bool operator ==(Matrix4 a, Matrix4 b) => (a[0] == b[0]) && (a[1] == b[1]) && (a[2] == b[2]) && (a[3] == b[3]);
        public static bool operator !=(Matrix4 a, Matrix4 b) => !(a == b);

        #endregion

        #region Unary Operators

        public static Matrix4 operator +(Matrix4 m)
        {
            return m;
        }

        public static Matrix4 operator -(Matrix4 m)
        {
            Matrix4 result = new Matrix4();
            result[0] = -m[0];
            result[1] = -m[1];
            result[2] = -m[2];
            result[3] = -m[3];
            return result;
        }

        public static Matrix4 operator ++(Matrix4 m)
        {
            Matrix4 result = new Matrix4();
            result[0] = m[0]++;
            result[1] = m[1]++;
            result[2] = m[2]++;
            result[3] = m[3]++;
            return result;
        }

        public static Matrix4 operator --(Matrix4 m)
        {
            Matrix4 result = new Matrix4();
            result[0] = m[0]--;
            result[1] = m[1]--;
            result[2] = m[2]--;
            result[3] = m[3]--;
            return result;
        }

        #endregion

        #endregion

        #region Accessors

        public Vector4 this[int row]
        {
            get
            {
                return new Vector4(matrix[row, 0], matrix[row, 1], matrix[row, 2], matrix[row, 3]);
            }
            set
            {
                matrix[row, 0] = value.x;
                matrix[row, 1] = value.y;
                matrix[row, 2] = value.z;
                matrix[row, 3] = value.w;
            }
        }

        public float this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }

        #endregion

        #region Type Conversion

        public static implicit operator Matrix4(Matrix3 m)
        {
            return new Matrix4(m[0], m[1], m[2], new Vector4(0, 0, 0, 1));
        }

        public static implicit operator Matrix4(Quaternion q) => (Matrix4)((Matrix3)q);

        public static implicit operator System.Numerics.Matrix4x4(Matrix4 m)
        {
            return new System.Numerics.Matrix4x4(
                m[0, 0], m[0, 1], m[0, 2], m[0, 3],
                m[1, 0], m[1, 1], m[1, 2], m[1, 3],
                m[2, 0], m[2, 1], m[2, 2], m[2, 3],
                m[3, 0], m[3, 1], m[3, 2], m[3, 3]
                );
        }

        public static implicit operator Matrix4(System.Numerics.Matrix4x4 m)
        {
            return new Matrix4(
                m.M11, m.M12, m.M13, m.M14,
                m.M21, m.M22, m.M23, m.M24,
                m.M31, m.M32, m.M33, m.M34,
                m.M41, m.M42, m.M43, m.M44
                );
        }

        #endregion

        #region Function Overloads

        public override string ToString()
        {
            string result = "";
            for (int row = 0; row < 4; row++)
            {
                result += "[ ";
                for (int col = 0; col < 4; col++)
                {
                    result += this[row, col].ToString("F2");
                    if (col < 3)
                    {
                        result += ", ";
                    }
                }
                result += " ]";
                if (row < 3)
                {
                    result += '\n';
                }
            }
            return result;
        }

        #endregion
    }
}

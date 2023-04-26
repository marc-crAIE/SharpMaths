namespace SharpMaths
{
    public struct Matrix4
    {
        public float[,] matrix;

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

        public Matrix4(float m00, float m01, float m02, float m03,
                       float m10, float m11, float m12, float m13,
                       float m20, float m21, float m22, float m23)
        {
            this.matrix = new float[3, 3];
            this[0, 0] = m00; this[1, 0] = m01; this[2, 0] = m02; this[3, 0] = m03;
            this[0, 1] = m10; this[1, 1] = m11; this[2, 1] = m12; this[3, 1] = m13;
            this[0, 2] = m20; this[1, 2] = m21; this[2, 2] = m22; this[3, 2] = m23;
        }

        public static Matrix4 Identity() => new Matrix4(1.0f);

        public float Determinant()
        {
            float m00 = matrix[0, 0], m01 = matrix[1, 0], m02 = matrix[2, 0], m03 = matrix[3, 0];
            float m10 = matrix[0, 1], m11 = matrix[1, 1], m12 = matrix[2, 1], m13 = matrix[3, 1];
            float m20 = matrix[0, 2], m21 = matrix[1, 2], m22 = matrix[2, 2], m23 = matrix[3, 2];
            float m30 = matrix[0, 3], m31 = matrix[1, 3], m32 = matrix[2, 3], m33 = matrix[3, 3];

            float q = m11 * m22 * m33 + m12 * m23 * m31 + m13 * m21 * m32 - m11 * m32 * m23 - m21 * m12 * m33 - m31 * m22 * m13;
            float r = m01 * m22 * m33 + m02 * m23 * m31 + m03 * m21 * m32 - m01 * m32 * m23 - m21 * m02 * m33 - m31 * m22 * m03;
            float s = m01 * m12 * m33 + m02 * m13 * m31 + m03 * m11 * m32 - m01 * m32 * m13 - m11 * m02 * m33 - m31 * m12 * m03;
            float t = m01 * m12 * m23 + m02 * m13 * m21 + m03 * m11 * m22 - m01 * m22 * m13 - m11 * m02 * m23 - m21 * m12 * m03;

            return m00 * q - m10 * r + m20 * s - m30 * t;
        }

        public Matrix4 Transpose()
        {
            Matrix4 result = new Matrix4(0.0f);
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    result[x, y] = this[y, x];
                }
            }
            return result;
        }

        public Matrix4 Inverse()
        {
            float det = Determinant();
            if (det == 0)
                throw new InvalidOperationException("Matrix is not invertible.");

            float m00 = matrix[0, 0], m01 = matrix[1, 0], m02 = matrix[2, 0], m03 = matrix[3, 0];
            float m10 = matrix[0, 1], m11 = matrix[1, 1], m12 = matrix[2, 1], m13 = matrix[3, 1];
            float m20 = matrix[0, 2], m21 = matrix[1, 2], m22 = matrix[2, 2], m23 = matrix[3, 2];
            float m30 = matrix[0, 3], m31 = matrix[1, 3], m32 = matrix[2, 3], m33 = matrix[3, 3];

            Matrix4 result = new Matrix4(0.0f);

            float m2a1 = m11 * m22 * m33 + m12 * m23 * m31 + m13 * m21 * m32 - m11 * m32 * m23 - m21 * m12 * m33 - m31 * m22 * m13;
            float m2b1 = m01 * m22 * m33 + m02 * m23 * m31 + m03 * m21 * m32 - m01 * m32 * m23 - m21 * m02 * m33 - m31 * m22 * m03;
            float m2c1 = m01 * m12 * m33 + m02 * m13 * m31 + m03 * m11 * m32 - m01 * m32 * m13 - m11 * m02 * m33 - m31 * m12 * m03;
            float m2d1 = m01 * m12 * m23 + m02 * m13 * m21 + m03 * m11 * m22 - m01 * m22 * m13 - m11 * m02 * m23 - m21 * m12 * m03;
            float m2a2 = m10 * m22 * m33 + m12 * m23 * m30 + m13 * m20 * m32 - m10 * m32 * m23 - m20 * m12 * m33 - m30 * m22 * m13;
            float m2b2 = m00 * m22 * m33 + m02 * m23 * m30 + m03 * m20 * m32 - m00 * m32 * m23 - m20 * m02 * m33 - m30 * m22 * m03;
            float m2c2 = m00 * m12 * m33 + m02 * m13 * m30 + m03 * m10 * m32 - m00 * m32 * m13 - m10 * m02 * m33 - m30 * m12 * m03;
            float m2d2 = m00 * m12 * m23 + m02 * m13 * m20 + m03 * m10 * m22 - m00 * m22 * m13 - m10 * m02 * m23 - m20 * m12 * m03;
            float m2a3 = m10 * m21 * m33 + m11 * m23 * m30 + m13 * m20 * m31 - m10 * m31 * m23 - m20 * m11 * m33 - m30 * m21 * m13;
            float m2b3 = m00 * m21 * m33 + m01 * m23 * m30 + m03 * m20 * m31 - m00 * m31 * m23 - m20 * m01 * m33 - m30 * m21 * m03;
            float m2c3 = m00 * m11 * m33 + m01 * m13 * m30 + m03 * m10 * m31 - m00 * m31 * m13 - m10 * m01 * m33 - m30 * m11 * m03;
            float m2d3 = m00 * m11 * m23 + m01 * m13 * m20 + m03 * m10 * m21 - m00 * m21 * m13 - m10 * m01 * m23 - m20 * m11 * m03;
            float m2a4 = m10 * m21 * m32 + m11 * m22 * m30 + m12 * m20 * m31 - m10 * m31 * m22 - m20 * m11 * m32 - m30 * m21 * m12;
            float m2b4 = m00 * m21 * m32 + m01 * m22 * m30 + m02 * m20 * m31 - m00 * m31 * m22 - m20 * m01 * m32 - m30 * m21 * m02;
            float m2c4 = m00 * m11 * m32 + m01 * m12 * m30 + m02 * m10 * m31 - m00 * m31 * m12 - m10 * m01 * m32 - m30 * m11 * m02;
            float m2d4 = m00 * m11 * m22 + m01 * m12 * m20 + m02 * m10 * m21 - m00 * m21 * m12 - m10 * m01 * m22 - m20 * m11 * m02;

            m2b1 = -m2b1; m2d1 = -m2d1;
            m2a2 = -m2a2; m2c2 = -m2c2;
            m2b3 = -m2b3; m2d3 = -m2d3;
            m2a4 = -m2a4; m2c4 = -m2c4;

            result[0, 0] = m2a1 / det; result[1, 0] = m2b1 / det; result[2, 0] = m2c1 / det; result[3, 0] = m2d1 / det;
            result[0, 1] = m2a2 / det; result[1, 1] = m2b2 / det; result[2, 1] = m2c2 / det; result[3, 1] = m2d2 / det;
            result[0, 2] = m2a3 / det; result[1, 2] = m2b3 / det; result[2, 2] = m2c3 / det; result[3, 2] = m2d3 / det;
            result[0, 3] = m2a4 / det; result[1, 3] = m2b4 / det; result[2, 3] = m2c4 / det; result[3, 3] = m2d4 / det;

            return result;
        }

        public void SetTranslation(Vector3 v) => this *= Translation(v);
        public void SetTranslation(float x, float y, float z) => SetTranslation(new Vector3(x, y, z));

        public void SetRotation(float angle, Vector3 axis) => this *= Rotation(angle, axis);
        public void SetRotation(float angle, float x, float y, float z) => SetRotation(angle, new Vector3(x, y, z));
        public void SetRotationX(float angle) => SetRotation(angle, new Vector3(1.0f, 0.0f, 0.0f));
        public void SetRotationY(float angle) => SetRotation(angle, new Vector3(0.0f, 1.0f, 0.0f));
        public void SetRotationZ(float angle) => SetRotation(angle, new Vector3(0.0f, 0.0f, 1.0f));

        public void SetScale(Vector3 v) => this *= Scale(v);
        public void SetScale(float x, float y, float z) => SetScale(new Vector3(x, y, z));

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

            float sin = (float)Math.Sin(angle);
            float cos = (float)Math.Cos(angle);

            axis.Normalize();

            Vector3 omc = (1.0f - cos) * axis;

            float x = axis.x;
            float y = axis.y;
            float z = axis.z;

            rotation[0, 0] = cos + omc.x * x;
            rotation[1, 0] = omc.y * x - sin * z;
            rotation[2, 0] = omc.z * x + sin * y;

            rotation[0, 1] = omc.x * y + sin * z;
            rotation[1, 1] = cos + omc.y * y;
            rotation[2, 1] = omc.z * y - sin * x;

            rotation[0, 2] = omc.x * z - sin * y;
            rotation[1, 2] = omc.y * z + sin * x;
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

        public static Matrix4 operator +(Matrix4 m, float scalar)
        {
            var result = new Matrix4();
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    result[x, y] = m[x, y] + scalar;
                }
            }
            return result;
        }
        public static Matrix4 operator +(float scalar, Matrix4 m) => m + scalar;

        public static Matrix4 operator +(Matrix4 a, Matrix4 b)
        {
            var result = new Matrix4();
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    result[x, y] = a[x, y] + b[x, y];
                }
            }
            return result;
        }

        public static Matrix4 operator -(Matrix4 m, float scalar)
        {
            var result = new Matrix4();
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    result[x, y] = m[x, y] - scalar;
                }
            }
            return result;
        }
        public static Matrix4 operator -(float scalar, Matrix4 m) => m - scalar;

        public static Matrix4 operator -(Matrix4 a, Matrix4 b)
        {
            var result = new Matrix4();
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    result[x, y] = a[x, y] - b[x, y];
                }
            }
            return result;
        }

        public static Matrix4 operator *(Matrix4 m, float scalar)
        {
            var result = new Matrix4();
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    result[x, y] = m[x, y] * scalar;
                }
            }
            return result;
        }
        public static Matrix4 operator *(float scalar, Matrix4 m) => m * scalar;

        public static Matrix4 operator *(Matrix4 a, Matrix4 b)
        {
            Matrix4 result = new Matrix4(0.0f);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        result[i, j] += a[k, j] * b[i, k];
                    }
                }
            }
            return result;
        }

        public static Matrix4 operator /(Matrix4 m, float scalar)
        {
            var result = new Matrix4();
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    result[x, y] = m[x, y] / scalar;
                }
            }
            return result;
        }
        public static Matrix4 operator /(float scalar, Matrix4 m) => scalar * m.Inverse();
        public static Matrix4 operator /(Matrix4 a, Matrix4 b) => a * b.Inverse();

        public float this[int x, int y]
        {
            get { return matrix[x, y]; }
            set { matrix[x, y] = value; }
        }

        public override string ToString()
        {
            string result = "";
            for (int x = 0; x < 4; x++)
            {
                result += "[ ";
                for (int y = 0; y < 4; y++)
                {
                    result += this[x, y].ToString("F2");
                    if (y < 3)
                    {
                        result += ", ";
                    }
                }
                result += " ]";
                if (x < 3)
                {
                    result += '\n';
                }
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpMaths
{
    public struct Matrix3
    {
        public float[,] matrix;

        public Matrix3() : this(1.0f) { }

        public Matrix3(float f)
        {
            this.matrix = new float[3, 3];
            this[0, 0] = f;
            this[1, 1] = f;
            this[2, 2] = f;
        }

        public Matrix3(float[,] m)
        {
            if (m.GetLength(0) != 3 || m.GetLength(1) != 3)
                throw new ArgumentException("Input data must be a 3x3 matrix!");

            this.matrix = m;
        }

        public Matrix3(float m00, float m01, float m02,
                       float m10, float m11, float m12,
                       float m20, float m21, float m22)
        {
            this.matrix = new float[3,3];
            this[0, 0] = m00; this[0, 1] = m01; this[0, 2] = m02;
            this[1, 0] = m10; this[1, 1] = m11; this[1, 2] = m12;
            this[2, 0] = m20; this[2, 1] = m21; this[2, 2] = m22;
        }

        public static Matrix3 Identity() => new Matrix3(1.0f);

        public float Determinant()
        {
            float m00 = matrix[0, 0], m01 = matrix[0, 1], m02 = matrix[0, 2];
            float m10 = matrix[1, 0], m11 = matrix[1, 1], m12 = matrix[1, 2];
            float m20 = matrix[2, 0], m21 = matrix[2, 1], m22 = matrix[2, 2];

            return m00 * m11 * m22 + m10 * m21 * m02 + m20 * m01 * m12
                - m02 * m11 * m20 - m12 * m21 * m00 - m22 * m01 * m10;
        }

        public Matrix3 Transpose()
        {
            Matrix3 result = new Matrix3(0.0f);
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    result[x, y] = this[y, x];
                }
            }
            return result;
        }

        public Matrix3 Inverse()
        {
            float det = Determinant();
            if (det == 0)
                throw new InvalidOperationException("Matrix is not invertible.");

            float m00 = matrix[0, 0], m01 = matrix[0, 1], m02 = matrix[0, 2];
            float m10 = matrix[1, 0], m11 = matrix[1, 1], m12 = matrix[1, 2];
            float m20 = matrix[2, 0], m21 = matrix[2, 1], m22 = matrix[2, 2];

            Matrix3 result = new Matrix3(0.0f);

            result[0, 0] = (m11 * m22 - m12 * m21) / det;
            result[0, 1] = (m02 * m21 - m01 * m22) / det;
            result[0, 2] = (m01 * m12 - m02 * m11) / det;

            result[1, 0] = (m12 * m20 - m10 * m22) / det;
            result[1, 1] = (m00 * m22 - m02 * m20) / det;
            result[1, 2] = (m02 * m10 - m00 * m12) / det;

            result[2, 0] = (m10 * m21 - m11 * m20) / det;
            result[2, 1] = (m01 * m20 - m00 * m21) / det;
            result[2, 2] = (m00 * m11 - m01 * m10) / det;

            return result;
        }

        public void SetTranslation(Vector2 v) => this *= Translation(v);
        public void SetTranslation(float x, float y) => SetTranslation(new Vector2(x, y));

        public void SetRotation(float angle, Vector3 axis) => this *= Rotation(angle, axis);
        public void SetRotation(float angle, float x, float y, float z) => SetRotation(angle, new Vector3(x, y, z));
        public void SetRotationX(float angle) => SetRotation(angle, new Vector3(1.0f, 0.0f, 0.0f));
        public void SetRotationY(float angle) => SetRotation(angle, new Vector3(0.0f, 1.0f, 0.0f));
        public void SetRotationZ(float angle) => SetRotation(angle, new Vector3(0.0f, 0.0f, 1.0f));

        public void SetScale(Vector2 v) => this *= Scale(v);
        public void SetScale(float x, float y) => SetScale(new Vector2(x, y));

        public static Matrix3 Translation(Vector2 v)
        {
            Matrix3 translation = new Matrix3();
            translation[2, 0] = v.x;
            translation[2, 1] = v.y;
            return translation;
        }

        public static Matrix3 Rotation(float angle, Vector3 axis)
        {
            Matrix3 rotation = new Matrix3();

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
        public static Matrix3 Rotation(float angle, float x, float y, float z) => Rotation(angle, new Vector3(x, y, z));

        public static Matrix3 RotationX(float angle) => Rotation(angle, new Vector3(1.0f, 0.0f, 0.0f));
        public static Matrix3 RotationY(float angle) => Rotation(angle, new Vector3(0.0f, 1.0f, 0.0f));
        public static Matrix3 RotationZ(float angle) => Rotation(angle, new Vector3(0.0f, 0.0f, 1.0f));

        public static Matrix3 Scale(Vector2 v)
        {
            Matrix3 scale = new Matrix3();
            scale[0, 0] = v.x;
            scale[1, 1] = v.y;
            return scale;
        }
        public static Matrix3 Scale(float x, float y) => Scale(new Vector2(x, y));

        public static Matrix3 operator +(Matrix3 m, float scalar)
        {
            Matrix3 result = new Matrix3(0.0f);
            for (int row = 0; row < 3; row++)
            {
                result[row] = m[row] + scalar;
            }
            return result;
        }
        public static Matrix3 operator +(float scalar, Matrix3 m) => m + scalar;

        public static Matrix3 operator +(Matrix3 a, Matrix3 b)
        {
            Matrix3 result = new Matrix3(0.0f);
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    result[x, y] = a[x, y] + b[x, y];
                }
            }
            return result;
        }

        public static Matrix3 operator -(Matrix3 m, float scalar)
        {
            Matrix3 result = new Matrix3(0.0f);
            for (int row = 0; row < 3; row++)
            {
                result[row] = m[row] - scalar;
            }
            return result;
        }
        public static Matrix3 operator -(float scalar, Matrix3 m) => m - scalar;

        public static Matrix3 operator -(Matrix3 a, Matrix3 b)
        {
            Matrix3 result = new Matrix3(0.0f);
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    result[x, y] = a[x, y] - b[x, y];
                }
            }
            return result;
        }

        public static Matrix3 operator *(Matrix3 m, float scalar)
        {
            Matrix3 result = new Matrix3(0.0f);
            for (int row = 0; row < 3; row++)
            {
                result[row] = m[row] * scalar;
            }
            return result;
        }
        public static Matrix3 operator *(float scalar, Matrix3 m) => m * scalar;
        public static Matrix3 operator *(Matrix3 a, Matrix3 b)
        {
            Matrix3 result = new Matrix3(0.0f);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        result[i, j] += a[k, j] * b[i, k];
                    }
                }
            }
            return result;
        }

        public static Matrix3 operator /(Matrix3 m, float scalar)
        {
            Matrix3 result = new Matrix3(0.0f);
            for (int row = 0; row < 3; row++)
            {
                result[row] = m[row] / scalar;
            }
            return result;
        }
        public static Matrix3 operator /(float scalar, Matrix3 m) => scalar * m.Inverse();
        public static Matrix3 operator /(Matrix3 a, Matrix3 b) => a * b.Inverse();

        public Vector3 this[int row]
        {
            get
            {
                return new Vector3(matrix[row, 0], matrix[row, 1], matrix[row, 2]);
            }
            set
            {
                matrix[row, 0] = value.x;
                matrix[row, 1] = value.y;
                matrix[row, 2] = value.z;
            }
        }

        public float this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < 3; i++)
            {
                result += "[ ";
                for (int j = 0; j < 3; j++)
                {
                    result += this[i, j].ToString("F2");
                    if (j < 2)
                    {
                        result += ", ";
                    }
                }
                result += " ]";
                if (i < 2)
                {
                    result += '\n';
                }
            }
            return result;
        }
    }
}

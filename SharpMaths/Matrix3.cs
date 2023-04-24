using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpMaths
{
    public struct Matrix3
    {
        public float[,] matrix;

        public Matrix3() : this(0.0f) { }

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
            this[0, 0] = m00; this[1, 0] = m01; this[2, 0] = m02;
            this[0, 1] = m10; this[1, 1] = m11; this[2, 1] = m12;
            this[0, 2] = m20; this[1, 2] = m21; this[2, 2] = m22;
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

        public static Matrix3 operator +(Matrix3 m, float scalar)
        {
            Matrix3 result = new Matrix3(0.0f);
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    result[x, y] = m[x, y] + scalar;
                }
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
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    result[x, y] = m[x, y] - scalar;
                }
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
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    result[x, y] = m[x, y] * scalar;
                }
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
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    result[x, y] = m[x, y] / scalar;
                }
            }
            return result;
        }
        public static Matrix3 operator /(float scalar, Matrix3 m) => scalar * m.Inverse();
        public static Matrix3 operator /(Matrix3 a, Matrix3 b) => a * b.Inverse();

        public float this[int x, int y]
        {
            get { return matrix[x, y]; }
            set { matrix[x, y] = value; }
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

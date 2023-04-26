using SharpMaths;

namespace Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix4 matrix4 = new Matrix4(new float[,] { { 1, 0, 2, 0 }, { 0, 3, 0, 4 }, { 0, 0, 5, 0 }, { 6, 0, 0, 7 } });
            Vector4 vector4 = new Vector4(2, 5, 1, 8);

            Console.WriteLine(matrix4 * vector4);
            Console.WriteLine();

            Matrix3 matrix3 = new Matrix3(new float[,] { { 1, 0, 2 }, { 0, 3, 0 }, { 0, 0, 5 } });
            Vector3 vector3 = new Vector3(2, 5, 1);

            Console.WriteLine(matrix3 * vector3);
        }
    }
}
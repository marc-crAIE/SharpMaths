using SharpMaths;

namespace Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix4 matrix4 = new Matrix4(new float[,] { { 1, 0, 2, 0 }, { 0, 3, 0, 4 }, { 0, 0, 5, 0 }, { 6, 0, 0, 7 } });

            Console.WriteLine(matrix4 / 2);
        }
    }
}
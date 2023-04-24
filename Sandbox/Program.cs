using SharpMaths;

namespace Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector2 vec2 = new Vector2(2.0f, 1.5f);
            Matrix3 matrix3 = new Matrix3(new float[,] { { 1.234f, 2.345f, 3.456f }, { 4.567f, 5.678f, 6.789f }, { 7.890f, 8.901f, 9.012f } });
            Matrix4 matrix4 = new Matrix4(new float[,] { { 1.234f, 2.345f, 3.456f, 8.234f }, { 4.567f, 5.678f, 6.789f, 6.587f }, { 7.890f, 8.901f, 9.012f, 1.658f }, { 2.482f, 8.437f, 6.372f, 2.378f } });

            Console.WriteLine(vec2);
            Console.WriteLine(matrix3 * matrix3.Inverse());
            Console.WriteLine(matrix4 * matrix4.Inverse());
        }
    }
}
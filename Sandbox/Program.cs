using SharpMaths;

namespace Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix4 mat4 = Matrix4.Translation(new Vector3(3.5f, 2.8f, 9.4f))
                * Matrix4.Rotation(45.0f, new Vector3(1.0f, 0.0f, 0.0f))
                * Matrix4.Scale(new Vector3(2.5f, 2.5f, 1.5f));

            Console.WriteLine(mat4 * mat4.Inverse());

            Console.Write(mat4.m0 * 2);
        }
    }
}
using SharpMaths;

namespace Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test matrix");

            Matrix4 mat4 = Matrix4.Translation(new Vector3(3.5f, 2.8f, 9.4f)) 
                * Matrix4.Rotation(45.0f, new Vector3(1.0f, 0.0f, 0.0f))
                * Matrix4.Scale(new Vector3(2.5f, 2.5f, 1.5f));

            Console.WriteLine(mat4);

            Console.WriteLine("\nModifying an existing matrix");

            Matrix4 mat4_2 = new Matrix4();
            mat4_2.SetTranslation(new Vector3(3.5f, 2.8f, 9.4f));
            mat4_2.SetRotation(45.0f, new Vector3(1.0f, 0.0f, 0.0f));
            mat4_2.SetScale(new Vector3(2.5f, 2.5f, 1.5f));

            Console.WriteLine(mat4_2);
        }
    }
}
using SharpMaths;

namespace Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test 4x4 matrix");

            Matrix4 mat4 = Matrix4.Translation(new Vector3(3.5f, 2.8f, 9.4f)) 
                * Matrix4.Rotation(45.0f, new Vector3(0.0f, 0.0f, 1.0f))
                * Matrix4.Scale(new Vector3(2.5f, 2.5f, 1.5f));

            Console.WriteLine(mat4);

            Console.WriteLine("\nModifying an existing 4x4 matrix");

            Matrix4 mat4_2 = new Matrix4();
            mat4_2.SetTranslation(new Vector3(3.5f, 2.8f, 9.4f));
            mat4_2.SetRotation(45.0f, new Vector3(1.0f, 0.0f, 0.0f));
            mat4_2.SetScale(new Vector3(2.5f, 2.5f, 1.5f));

            Console.WriteLine(mat4_2);

            Console.WriteLine("\nTest 3x3 matrix");

            Matrix3 mat3 = Matrix3.Translation(new Vector2(3.5f, 2.8f))
                * Matrix3.Rotation(45.0f, new Vector3(0.0f, 0.0f, 1.0f))
                * Matrix3.Scale(new Vector2(2.5f, 2.5f));

            Console.WriteLine(mat3);

            Console.WriteLine("\nModifying an existing 3x3 matrix");

            Matrix3 mat3_2 = new Matrix3();
            mat3_2.SetTranslation(new Vector2(3.5f, 2.8f));
            mat3_2.SetRotation(45.0f, new Vector3(0.0f, 0.0f, 1.0f));
            mat3_2.SetScale(new Vector2(2.5f, 2.5f));

            Console.WriteLine(mat3_2);
        }
    }
}
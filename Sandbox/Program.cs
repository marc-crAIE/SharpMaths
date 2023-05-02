using SharpMaths;
using Raylib_cs;
using ExtensionMethods;

namespace Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Quaternion quat1 = new Quaternion(new Vector3(2, 3, 4));
            Quaternion quat2 = new Quaternion(new Vector3(4, 3, 2));
            Console.WriteLine(quat1 * quat2);

            //Raylib.InitWindow(800, 600, "Sandbox");

            //Raylib.SetTargetFPS(60);

            //while (!Raylib.WindowShouldClose())
            //{
            //    Raylib.BeginDrawing();

            //    Colour colour = new Vector4(1.0f);

            //    Raylib.ClearBackground(colour.ToColor());

            //    Raylib.DrawRectangleV(new Vector2(50.0f), new Vector2(150.0f), Color.BLUE);

            //    Raylib.EndDrawing();
            //}

            //Raylib.CloseWindow();
        }
    }
}
using SharpMaths;
using Raylib_cs;
using ExtensionMethods;

namespace Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Sandbox");

            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();

                Colour colour = new Vector4(1.0f);

                Raylib.ClearBackground(colour.ToColor());

                Raylib.DrawRectangleV(new Vector2(50.0f), new Vector2(150.0f), Color.BLUE);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
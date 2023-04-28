using SharpMaths;
using Raylib_cs;

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

                Raylib.ClearBackground(Color.RAYWHITE);

                Raylib.DrawRectangleV(new Vector2(50.0f), new Vector2(150.0f), Color.BLUE);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
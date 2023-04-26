using SharpMaths;

namespace Sandbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Colour colour = new Colour();
            colour.alpha = 0xFF;
            colour.green = 0xFF;
            colour = new Vector3(0.75f, 0.5f, 0.25f);

            Console.WriteLine(colour);
            Console.WriteLine(colour.green);
        }
    }
}
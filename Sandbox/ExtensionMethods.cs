using SharpMaths;
using Raylib_cs;

namespace ExtensionMethods
{
    public static class Extensions
    {
        public static Color ToColor(this Colour c)
        {
            return new Color(c.red, c.green, c.blue, c.alpha);
        }
    }
}

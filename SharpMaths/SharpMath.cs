using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpMaths
{
    public static partial class SharpMath
    {
        public static float ToRadians(float degrees) => degrees * (float)(Math.PI / 180.0f);
        public static float ToDegrees(float radians) => radians * (float)(180.0f / Math.PI);

        public static Vector2 Sin(Vector2 v) => new Vector2((float)Math.Sin(v.x), (float)Math.Sin(v.y));
        public static Vector3 Sin(Vector3 v) => new Vector3((float)Math.Sin(v.x), (float)Math.Sin(v.y), (float)Math.Sin(v.z));
        public static Vector4 Sin(Vector4 v) => new Vector4((float)Math.Sin(v.x), (float)Math.Sin(v.y), (float)Math.Sin(v.z), (float)Math.Sin(v.w));

        public static Vector2 Cos(Vector2 v) => new Vector2((float)Math.Cos(v.x), (float)Math.Cos(v.y));
        public static Vector3 Cos(Vector3 v) => new Vector3((float)Math.Cos(v.x), (float)Math.Cos(v.y), (float)Math.Cos(v.z));
        public static Vector4 Cos(Vector4 v) => new Vector4((float)Math.Cos(v.x), (float)Math.Cos(v.y), (float)Math.Cos(v.z), (float)Math.Cos(v.w));
    }
}

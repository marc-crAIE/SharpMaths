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
        public static Vector3 ToRadians(Vector2 v) => new Vector2(ToRadians(v.x), ToRadians(v.y));
        public static Vector4 ToRadians(Vector3 v) => new Vector3(ToRadians(v.x), ToRadians(v.y), ToRadians(v.z));
        public static Vector4 ToRadians(Vector4 v) => new Vector4(ToRadians(v.x), ToRadians(v.y), ToRadians(v.z), ToRadians(v.w));

        public static float ToDegrees(float radians) => radians * (float)(180.0f / Math.PI);
        public static Vector4 ToDegrees(Vector2 v) => new Vector2(ToDegrees(v.x), ToDegrees(v.y));
        public static Vector4 ToDegrees(Vector3 v) => new Vector3(ToDegrees(v.x), ToDegrees(v.y), ToDegrees(v.z));
        public static Vector4 ToDegrees(Vector4 v) => new Vector4(ToDegrees(v.x), ToDegrees(v.y), ToDegrees(v.z), ToDegrees(v.w));

        public static Vector2 Sin(Vector2 v) => new Vector2((float)Math.Sin(v.x), (float)Math.Sin(v.y));
        public static Vector3 Sin(Vector3 v) => new Vector3((float)Math.Sin(v.x), (float)Math.Sin(v.y), (float)Math.Sin(v.z));
        public static Vector4 Sin(Vector4 v) => new Vector4((float)Math.Sin(v.x), (float)Math.Sin(v.y), (float)Math.Sin(v.z), (float)Math.Sin(v.w));

        public static Vector2 Cos(Vector2 v) => new Vector2((float)Math.Cos(v.x), (float)Math.Cos(v.y));
        public static Vector3 Cos(Vector3 v) => new Vector3((float)Math.Cos(v.x), (float)Math.Cos(v.y), (float)Math.Cos(v.z));
        public static Vector4 Cos(Vector4 v) => new Vector4((float)Math.Cos(v.x), (float)Math.Cos(v.y), (float)Math.Cos(v.z), (float)Math.Cos(v.w));
    }
}

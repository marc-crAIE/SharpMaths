using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpMaths
{
    public static partial class SharpMath
    {
        public const float FloatTolerance = 0.0001f;

        public static bool IsEqual(this float a, float b, float tolerance = FloatTolerance)
        {
            return MathF.Abs(a - b) < tolerance;
        }

        public static float ToRadians(float degrees) => degrees * (MathF.PI / 180.0f);
        public static Vector3 ToRadians(Vector2 v) => new Vector2(ToRadians(v.x), ToRadians(v.y));
        public static Vector4 ToRadians(Vector3 v) => new Vector3(ToRadians(v.x), ToRadians(v.y), ToRadians(v.z));
        public static Vector4 ToRadians(Vector4 v) => new Vector4(ToRadians(v.x), ToRadians(v.y), ToRadians(v.z), ToRadians(v.w));

        public static float ToDegrees(float radians) => radians * (180.0f / MathF.PI);
        public static Vector4 ToDegrees(Vector2 v) => new Vector2(ToDegrees(v.x), ToDegrees(v.y));
        public static Vector4 ToDegrees(Vector3 v) => new Vector3(ToDegrees(v.x), ToDegrees(v.y), ToDegrees(v.z));
        public static Vector4 ToDegrees(Vector4 v) => new Vector4(ToDegrees(v.x), ToDegrees(v.y), ToDegrees(v.z), ToDegrees(v.w));

        public static Vector2 Sin(Vector2 v) => new Vector2(MathF.Sin(v.x), MathF.Sin(v.y));
        public static Vector3 Sin(Vector3 v) => new Vector3(MathF.Sin(v.x), MathF.Sin(v.y), MathF.Sin(v.z));
        public static Vector4 Sin(Vector4 v) => new Vector4(MathF.Sin(v.x), MathF.Sin(v.y), MathF.Sin(v.z), MathF.Sin(v.w));

        public static Vector2 Cos(Vector2 v) => new Vector2(MathF.Cos(v.x), MathF.Cos(v.y));
        public static Vector3 Cos(Vector3 v) => new Vector3(MathF.Cos(v.x), MathF.Cos(v.y), MathF.Cos(v.z));
        public static Vector4 Cos(Vector4 v) => new Vector4(MathF.Cos(v.x), MathF.Cos(v.y), MathF.Cos(v.z), MathF.Cos(v.w));
    }
}

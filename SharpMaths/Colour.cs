using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpMaths
{
    public struct Colour
    {
        public uint colour;

        public byte red
        {
            get { return (byte)(colour >> 24); }
            set { colour = (uint)value << 24 | colour; }
        }

        public byte green
        {
            get { return (byte)(colour >> 16); }
            set { colour = (uint)value << 16 | colour; }
        }

        public byte blue
        {
            get { return (byte)(colour >> 8); }
            set { colour = (uint)value << 8 | colour; }
        }

        public byte alpha
        {
            get { return (byte)(colour & 0xFF); }
            set { colour = (uint)value & 0xFF | colour; }
        }

        public Colour() : this (0) { }

        public Colour(uint colour)
        {
            this.colour = colour;
        }

        public Colour(byte r, byte g, byte b) : this(r, g, b, 0xFF) { }

        public Colour(byte r, byte g, byte b, byte a)
        {
            this.colour = (uint)r << 24 | (uint)g << 16 | (uint)b << 8 | a;
        }

        public byte GetRed() => red;
        public void SetRed(byte red) => this.red = red;

        public byte GetGreen() => green;
        public void SetGreen(byte green) => this.green = green;

        public byte GetBlue() => blue;
        public void SetBlue(byte blue) => this.blue = blue;

        public byte GetAlpha() => alpha;
        public void SetAlpha(byte alpha) => this.alpha = alpha;

        public static implicit operator Vector3(Colour colour) => new Vector3(colour.red / 255.0f, colour.green / 255.0f, colour.blue / 255.0f);
        public static implicit operator Vector4(Colour colour) => new Vector4(colour.red / 255.0f, colour.green / 255.0f, colour.blue / 255.0f, colour.alpha / 255.0f);

        public static implicit operator Colour(Vector3 v) => new Colour((byte)(v.x * 255), (byte)(v.y * 255), (byte)(v.z * 255));
        public static implicit operator Colour(Vector4 v) => new Colour((byte)(v.x * 255), (byte)(v.y * 255), (byte)(v.z * 255));

        public override string ToString()
        {
            return colour.ToString("X");
        }
    }
}

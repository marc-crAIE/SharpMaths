namespace SharpMaths
{
    public struct Colour
    {
        public uint colour;

        #region Properties

        public byte red
        {
            get { return (byte)(colour >> 24); }
            set { colour = (uint)value << 24 | colour & 0x00FFFFFF; }
        }

        public byte green
        {
            get { return (byte)(colour >> 16); }
            set { colour = (uint)value << 16 | colour & 0xFF00FFFF; }
        }

        public byte blue
        {
            get { return (byte)(colour >> 8); }
            set { colour = (uint)value << 8 | colour & 0xFFFF00FF; }
        }

        public byte alpha
        {
            get { return (byte)(colour & 0xFF); }
            set { colour = (uint)value & 0xFF | colour & 0xFFFFFF00; }
        }

        #endregion

        #region Constructors

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

        #endregion

        #region Getters and Setters

        public byte GetRed() => red;
        public void SetRed(byte red) => this.red = red;

        public byte GetGreen() => green;
        public void SetGreen(byte green) => this.green = green;

        public byte GetBlue() => blue;
        public void SetBlue(byte blue) => this.blue = blue;

        public byte GetAlpha() => alpha;
        public void SetAlpha(byte alpha) => this.alpha = alpha;

        #endregion

        #region Accessors

        public byte this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return red;
                    case 1: return green;
                    case 2: return blue;
                    case 3: return alpha;
                }
                return 0;
            }
            set
            {
                switch (i)
                {
                    case 0: red = value; break;
                    case 1: green = value; break;
                    case 2: blue = value; break;
                    case 3: alpha = value; break;
                }
            }
        }

        #endregion

        #region Type Conversions

        public static implicit operator Vector3(Colour colour) => new Vector3(colour.red / 255.0f, colour.green / 255.0f, colour.blue / 255.0f);
        public static implicit operator Vector4(Colour colour) => new Vector4(colour.red / 255.0f, colour.green / 255.0f, colour.blue / 255.0f, colour.alpha / 255.0f);

        public static implicit operator Colour(Vector3 v) => new Colour((byte)(v.x * 255), (byte)(v.y * 255), (byte)(v.z * 255));
        public static implicit operator Colour(Vector4 v) => new Colour((byte)(v.x * 255), (byte)(v.y * 255), (byte)(v.z * 255));

        #endregion

        #region Function Overloads

        public override string ToString()
        {
            return colour.ToString("X");
        }

        #endregion
    }
}

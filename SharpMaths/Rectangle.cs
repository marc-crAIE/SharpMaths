using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpMaths
{
    public struct Rectangle
    {
        public float x, y, width, height;

        #region Properties

        public Vector2 Position
        {
            get => new Vector2(x, y);
            set { x = value.x; y = value.y; }
        }

        public Vector2 Size
        {
            get => new Vector2(width, height);
            set { width = value.x; height = value.y;}
        }

        #endregion

        #region Constructors

        public Rectangle() : this(0, 0) { }

        public Rectangle(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public Rectangle(float width, float height)
        {
            this.x = 0;
            this.y = 0;
            this.width = width;
            this.height = height;
        }

        public Rectangle(Vector2 position, Vector2 size)
        {
            this.x = position.x;
            this.y = position.y;
            this.width = size.x;
            this.height = size.y;
        }

        public Rectangle(Vector2 size)
        {
            this.x = 0;
            this.y = 0;
            this.width = size.x;
            this.height = size.y;
        }

        #endregion
    }
}

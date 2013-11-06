using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    struct Color
    {
        byte r, g, b;

        public byte B
        {
            get { return b; }
            set { b = value; }
        }

        public byte G
        {
            get { return g; }
            set { g = value; }
        }

        public byte R
        {
            get { return r; }
            set { r = value; }
        }

        public Color(byte R, byte G, byte B)
        {
            r = R;
            g = G;
            b = B;
        }

        public static explicit operator System.Drawing.Color (Color Value)
        {
            return System.Drawing.Color.FromArgb(Value.R, Value.G, Value.B);
        }

        public readonly static Color Red = new Color(255, 0, 0);
        public readonly static Color Blue = new Color(0, 0, 255);
    }
}

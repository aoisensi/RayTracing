using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    struct Illuminance
    {
        double r, g, b;

        public double R
        {
            get { return r; }
            set { r = value; }
        }

        public double G
        {
            get { return g; }
            set { g = value; }
        }

        public double B
        {
            get { return b; }
            set { b = value; }
        }

        public Illuminance(Color Color)
        {
            r = Color.R / (double)byte.MaxValue;
            g = Color.G / (double)byte.MaxValue;
            b = Color.B / (double)byte.MaxValue; 
        }

        public Illuminance(Color Color, double Brightness)
        {
            r = Color.R / (double)byte.MaxValue * Brightness;
            g = Color.G / (double)byte.MaxValue * Brightness;
            b = Color.B / (double)byte.MaxValue * Brightness;
        }

        public Illuminance(double Brightness)
        {
            r = Brightness;
            g = Brightness;
            b = Brightness;
        }

        public Illuminance(double R, double G, double B)
        {
            r = R; g = G; b = B;
        }

        public Illuminance Add(Illuminance Value)
        {
            return new Illuminance(R + Value.R, G + Value.G, B + Value.B);
        }

        public Illuminance Sub(Illuminance Value)
        {
            return new Illuminance(R - Value.R, G - Value.G, B - Value.B);
        }

        public Illuminance Mul(Illuminance Value)
        {
            return new Illuminance(R * Value.R, G * Value.G, B * Value.B);
        }

        public Illuminance Mul(double Value)
        {
            return new Illuminance(R * Value, G * Value, B * Value);
        }

        readonly static Func<double, byte> castf = (v) => ((byte)((v < 0.0 ? 0.0 : v > 1.0 ? 1.0 : v) * byte.MaxValue));
        public static explicit operator Color(Illuminance Value)
        {
            return new Color(castf(Value.r), castf(Value.g), castf(Value.b));
        }

        public static Illuminance Black
        {
            get { return new Illuminance(0.0, 0.0, 0.0); }
        }


    }
}

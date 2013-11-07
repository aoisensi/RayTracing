using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class LightDiffuse : Light
    {
        Vector3 p;
        Illuminance c;

        public Vector3 Point
        {
            get { return p; }
            set { p = value; }
        }

        public LightDiffuse(Vector3 Point, Illuminance Illuminance)
        {
            p = Point;
            c = Illuminance;
        }

        public override Illuminance Spotlight(World World, Vector3 Spot)
        {
            Vector3 l = Point.Sub(Spot);
            double Dl = l.Norm() - MathHelper.Epsilon;
            l.Normalize();
            Ray shadow = new Ray(Spot.Add(l.Mul(MathHelper.Epsilon)), l);
            foreach (var s in World.Shapes)
            {
                double d = s.Intersection(shadow);
                if (!double.IsNaN(d))
                    return Illuminance.Black;
            }
            return c;
            if (World.Shapes.All((s) => (double.IsNaN(s.Intersection(shadow)))))
                return c;
            else
                return Illuminance.Black;
        }
    }
}

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

        public override Illuminance Spotlight(World World, Vector3 Spot, out Vector3 Incident)
        {
            Incident = Point.Sub(Spot);
            double Dl = Incident.Norm() - MathHelper.Epsilon;
            Incident.Normalize();
            Ray shadow = new Ray(Spot.Add(Incident.Mul(MathHelper.Epsilon)), Incident);
            foreach (var s in World.Shapes)
            {
                var t = s.Intersection(shadow);
                if (t.IsPositive()) return Illuminance.Black;
            }
            return c;
        }
    }
}

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

        public Vector3 Point
        {
            get { return p; }
            set { p = value; }
        }

        public LightDiffuse(Vector3 Point, Illuminance Illuminance) : base(Illuminance)
        {
            p = Point;
        }

        public override Illuminance Spotlight(World World, Shape Shape, Vector3 Spot, Ray Ray, Vector3 Normal)
        {
            Vector3 Incident = Point.Sub(Spot);
            double Dl = Incident.Norm() - MathHelper.Epsilon;
            Incident.Normalize();
            Ray shadow = new Ray(Spot.Add(Incident.Mul(MathHelper.Epsilon)), Incident);
            foreach (var s in World.Shapes)
            {
                var t = s.Intersection(shadow);
                if (t < Dl) return Illuminance.Black;
            }
            double d = Normal.Dot(Incident).ToRate();
            Illuminance ld = Shape.Material.DRC.Mul(Illuminance.Mul(d));
            if(d > 0.0 && (!Shape.Material.SRC.IsDark()) && Shape.Material.Shininess > 0.0)
            {
                Vector3 r = Normal.Mul(d * 2).Sub(Incident).Normalized();
                Vector3 v = Ray.Direction.Reversed();
                ld = ld.Add(Illuminance.Mul(Shape.Material.SRC.Mul(Math.Pow(r.Dot(v).ToRate(), Shape.Material.Shininess))));
            }

            return ld;
        }
    }
}

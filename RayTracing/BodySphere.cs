using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class BodySphere
    {
        double r;
        Vector3 p;
        public BodySphere(Vector3 Point, double Radius)
        {
            r = Radius;
            p = Point;
        }

        public bool Intersection(Ray Ray)
        {
            double A = Ray.Direction.SquaredNorm();
            double B = 2.0 * ((Ray.Origin.Sub(p).Dot(Ray.Direction)));
            double C = Ray.Origin.Sub(p).SquaredNorm() - Math.Pow(r, 2.0);
            double D = Math.Pow(B, 2.0) - 4 * A * C;
            return D >= 0.0;
        }
    }
}

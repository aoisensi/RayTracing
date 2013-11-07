using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing
{
    abstract class Shape
    {
        public abstract double Intersection(Ray Ray);
        public abstract Vector3 NormalVector(Vector3 Intersection);
    }
}

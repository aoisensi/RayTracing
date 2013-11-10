using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracing
{
    abstract class Shape
    {
        Material mat;

        public Material Material
        {
            get { return mat; }
            set { mat = value; }
        }

        public Shape(Material Material)
        {
            mat = Material;
        }

        public abstract double Intersection(Ray Ray);
        public abstract Vector3 NormalVector(Vector3 Intersection);
        
    }
}

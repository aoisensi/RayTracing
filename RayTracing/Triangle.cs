using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    struct Triangle
    {
        Vector3 a, b, c;
        public Triangle(Vector3 A, Vector3 B, Vector3 C)
        {
            a = A;
            b = B;
            c = C;
        }
    }
}

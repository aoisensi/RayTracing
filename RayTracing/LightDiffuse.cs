using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class LightDiffuse
    {
        Vector3 p;

        internal Vector3 Point
        {
            get { return p; }
            set { p = value; }
        }
        public LightDiffuse(Vector3 Point)
        {
            p = Point;
        }
    }
}

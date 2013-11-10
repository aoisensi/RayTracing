using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class LightAmbient : Light
    {
        Illuminance l;

        public LightAmbient(Illuminance Illuminance) : base(Illuminance) { }

        public override Illuminance Spotlight(World World, Shape Shape, Vector3 Spot, Ray Ray)
        {
            return l.Mul(Shape.Material.ARC);
        }
    }
}

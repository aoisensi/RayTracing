using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class LightAmbient : Light
    {
        public override Illuminance Spotlight(World World, Vector3 Spot, out Vector3 Incident)
        {
            throw new NotImplementedException();
        }
    }
}

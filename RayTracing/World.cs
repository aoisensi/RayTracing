using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class World
    {
        LinkedList<Shape> shapes = new LinkedList<Shape>();

        internal LinkedList<Shape> Shapes
        {
            get { return shapes; }
            set { shapes = value; }
        }
        LinkedList<Light> lightes = new LinkedList<Light>();
        Illuminance sky;

        public World(Color SkyColor) { sky = new Illuminance(SkyColor); }

        public void AddShape(Shape Shape)
        {
            shapes.AddLast(Shape);
        }

        public void AddLight(Light Light)
        {
            lightes.AddLast(Light);
        }

        public Illuminance ShootRay(Ray Ray)
        {
            Shape shape = null;
            var distance = double.PositiveInfinity;
            foreach (var s in shapes)
            {
                var t = s.Intersection(Ray);
                if (double.IsNaN(t)) break;
                if (distance < t) break;
                shape = s;
                distance = t;
            }
            if (shape == null) return sky;
            return lightes.Select((l) => (l.Spotlight(this, Ray.Away(distance)))).Aggregate((l,r)=>(l.Add(r)));
        }
    }
}

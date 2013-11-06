using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class Program
    {
        const int Width = 512, Height = 512;

        static void Main(string[] args)
        {
            Image img = new Image(Width, Height);
            Vector3 camera = new Vector3(0.0, 0.0, -5.0);
            BodySphere sphere = new BodySphere(new Vector3(0.0, 0.0, 5.0), 1.0);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Ray ray = new Ray(camera, camera.Add(new Vector3((x - (Width / 2)) / (Width / 2.0), (y - (Height / 2)) / (Height / 2.0), 0.0)));
                    Color c = sphere.Intersection(ray) ? Color.Red : Color.Blue;
                    img.SetPixel(x, y, c);
                }
            }
            img.Save("out.bmp");
        }
    }
}

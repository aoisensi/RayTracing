using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RayTracing
{
    class Program
    {
        const int Width = 512, Height = 512;

        static void Main(string[] args)
        {
            Image img = new Image(Width, Height);
            Vector3 camera = new Vector3(0.0, 0.0, -5.0);
            World world = new World(Color.CornflowerBlue);

            world.AddShape(new ShapeSphere(new Material(Color.Red), new Vector3(0.0, 0.0, 5.0), 1.0));
            world.AddShape(new ShapePlane(Material.Concrete, new Vector3(0.0, -1.0, 0.0), new Vector3(0.0, 1.0, 0.0)));

            world.AddLight(new LightDiffuse(new Vector3(-5.0, 5.0, -5.0), new Illuminance(1.0)));
            world.AddLight(new LightAmbient(new Illuminance(Color.Blue, 0.1)));
            
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (y == 250 && x == 250)
                        Console.WriteLine("d");
                    Ray ray = new Ray(camera, new Vector3((x - (Width / 2)) / (Width / 2.0), (-y + (Height / 2)) / (Height / 2.0), 0.0).Sub(camera));
                    Color c = (Color)world.ShootRay(ray);
                    img.SetPixel(x, y, c);
                }
                Console.WriteLine("X = {0}, Y = {1}, {2:f5}%", Width, y, (y * Width + Width) / (double)(Width * Height) * 100.0);

            }
            img.Save("out.bmp");
            Console.WriteLine("Complite!!");
            Console.ReadLine();
        }
    }
}

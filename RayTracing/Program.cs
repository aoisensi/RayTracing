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
            World world = new World(Color.Black);


            world.AddShape(new ShapeSphere(Material.Mirror, new Vector3(-0.25, -0.5, 3.0), 0.5));
            world.AddShape(new ShapePlane(Material.Vinyl.ChangeColor(Illuminance.White), new Vector3(0.0, -1.0, 0.0), new Vector3(0.0, 1.0, 0.0)));//床
            world.AddShape(new ShapePlane(Material.Vinyl.ChangeColor(Illuminance.White), new Vector3(0.0, 1.0, 0.0), new Vector3(0.0, -1.0, 0.0)));//天井
            world.AddShape(new ShapePlane(Material.Vinyl.ChangeColor(Illuminance.Green), new Vector3(1.0, 0.0, 0.0), new Vector3(-1.0, 0.0, 0.0)));//右壁
            world.AddShape(new ShapePlane(Material.Vinyl.ChangeColor(Illuminance.Red), new Vector3(-1.0, 0.0, 0.0), new Vector3(1.0, 0.0, 0.0)));//左壁
            world.AddShape(new ShapePlane(Material.Vinyl.ChangeColor(Illuminance.White), new Vector3(0.0, 0.0, 5.0), new Vector3(0.0, 0.0, -1.0)));//奥

            world.AddLight(new LightDiffuse(new Vector3(0.0, 0.9, 2.5), new Illuminance(1.0)));


            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
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

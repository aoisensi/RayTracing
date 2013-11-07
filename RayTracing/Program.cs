﻿using System;
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
            LightDiffuse light = new LightDiffuse(new Vector3(-5.0, 5.0, -5.0));
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Color c;
                    Ray ray = new Ray(camera, new Vector3((x - (Width / 2)) / (Width / 2.0), (-y + (Height / 2)) / (Height / 2.0), 0.0).Sub(camera));
                    double t = sphere.Intersection(ray);
                    if (double.IsNaN(t)) c = Color.CornflowerBlue;
                    else
                    {
                        Vector3 Pi = ray.Origin.Add(ray.Direction.Mul(t));
                        Vector3 l = light.Point.Sub(Pi);
                        l.Normalize();
                        Vector3 n = Pi.Sub(sphere.Point);
                        n.Normalize();
                        double g = n.Dot(l);
                        if (g < 0.0) g = 0.0;
                        byte gray = (byte)(byte.MaxValue * g);
                        c = new Color(gray, gray, gray);
                    }
                    img.SetPixel(x, y, c);
                }
            }
            img.Save("out.bmp");
        }
    }
}

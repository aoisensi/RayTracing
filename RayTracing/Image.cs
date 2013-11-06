using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracing
{
    class Image
    {
        Bitmap bmp;

        public Image(int Width, int Height)
        {
            bmp = new Bitmap(Width, Height);
        }

        public void SetPixel(int X, int Y, Color Color)
        {
            bmp.SetPixel(X, Y, (System.Drawing.Color)Color);
        }

        public void Save(string filename)
        {
            bmp.Save(filename);
        }
    }
}

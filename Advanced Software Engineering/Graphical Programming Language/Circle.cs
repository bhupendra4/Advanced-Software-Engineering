using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language
{
  public  class Circle :Shape
    {
        public int x, y, size, size1;
        Color f1;
        int texturestyle;
        Brush kk;

        public override void Draw(Graphics g)
        {
            Pen p = new Pen(f1, 5);
            if (texturestyle == 0)
            {
                g.DrawEllipse(p, x, y, size, size1);
            }
            else
            {
                g.FillEllipse(kk, x, y, size, size1);
            }
        }
        /// <summary>
        /// setting required parameter to draw circle
        /// </summary>
        /// <param name="texturestyle"></param>
        /// <param name="bb"></param>
        /// <param name="c1"></param>
        /// <param name="list"></param>
        public override void set(int texturestyle, Brush kk, Color f1, params int[] list)
        {
            this.texturestyle = texturestyle;
            this.kk = kk;
            this.f1 = f1;
            this.x = list[0];
            this.y = list[1];
            this.size = list[2];
            this.size1 = list[3];
        }
    }
}

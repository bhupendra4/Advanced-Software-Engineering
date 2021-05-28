using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language
{
  public  class Triangle :Shape
    {
        
        public int m1, n1, o1, p1, q1, mm1, nn2, oo2, pp2, qq2, mno1, mno2;
        Color c1;
        int texturestyle;
        Brush bb;
        public override void draw(Graphics g)
        {
            Pen p = new Pen(c1, 5);

            //----------------------------------------------------------------------------------------------------------------------
            g.DrawLine(p, m1, n1, o1, p1);
            g.DrawLine(p, q1, mm1, nn2, oo2);
            g.DrawLine(p, pp2, qq2, mno1, mno2);
            //---------------------------------------------------------------------------------------------------------------------
        }
        public override void set(int texturestyle, Brush kk, Color f1, params int[] list)
        {
            this.texturestyle = texturestyle;
            this.bb = kk;
            this.c1 = f1;

            this.m1 = list[0];
            this.n1 = list[1];
            this.o1 = list[2];
            this.p1 = list[3];

            this.q1 = list[4];
            this.mm1 = list[5];
            this.nn2 = list[6];
            this.oo2 = list[7];

            this.pp2 = list[8];
            this.qq2 = list[9];
            this.mno1 = list[10];
            this.mno2 = list[11];

        }

    }
}


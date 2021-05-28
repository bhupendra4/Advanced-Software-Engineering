using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language
{
   public abstract class Shape
    {
  
            public abstract void draw(Graphics g);

            public abstract void set(int texture, Brush myBrush, Color myColor, params int[] list);
        
    }
}

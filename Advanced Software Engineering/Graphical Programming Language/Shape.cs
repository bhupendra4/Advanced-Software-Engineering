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
    
        
            /// <summary>
            /// passing graphical value to shapes
            /// </summary>
            /// <param name="g"></param>
            public abstract void Draw(Graphics g);

            public abstract void set(int texturestyle, Brush kk, Color c, params int[] list);
        
    }
}

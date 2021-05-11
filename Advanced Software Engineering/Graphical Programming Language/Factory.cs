using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language
{
    class Factory : AbstractFactory
    {
        public override Shape GetShape(String shapeType)
        {
            if (shapeType == "circle")
            {
                return new Circle();
            }
            else if (shapeType == "rectangle")
            {
                return new Rectangle();
            }
            else if (shapeType == "triangle")
            {
                return new Triangle();
            }
            return null;

        }
    }
}

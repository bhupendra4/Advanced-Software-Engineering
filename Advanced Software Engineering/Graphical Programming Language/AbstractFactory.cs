using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphical_Programming_Language
{
  public abstract  class AbstractFactory
    {
        public abstract Shape GetShape(String shapeType);
    }

}

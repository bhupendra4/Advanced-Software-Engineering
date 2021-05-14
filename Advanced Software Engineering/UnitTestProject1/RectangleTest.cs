using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
  public  class RectangleTest
    {
        int texturstyle;
        Brush kk;
        Color f1 = Color.Black;
    public RectangleTest()
        {

        }
        private TestContext testContextInstance;


        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;

            }
        }
            [TestMethod]
        
        public void TestMethod()
        {
            var r = new Graphical_Programming_Language.Rectangle();
            int xPos = 200, y = 200, size = 100, size1 = 100;
            r.set(texturstyle, kk, f1, xPos, y, size, size1);
            Assert.AreEqual(200, r.xPos);
        }
            }
}

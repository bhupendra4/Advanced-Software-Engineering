using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class Triangle
    {
        int test;
        Brush kk;
        Color f1 = Color.Black;

        public Triangle()
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
            var t = new Graphical_Programming_Language.Triangle();
            int xi1 = 200, yi1 = 200, xi2 = 200, yi2 = 200, xii1 = 200, yii1 = 200, xii2 = 200, yii2 = 200, xiii1 = 200, yiii1 = 200, xiii2 = 200, yiii2 = 200;
            t.set(test, kk, f1, xi1, yi1, xi2, yi2, xii1, yii1, xii2, yii2, xiii1, yiii1, xiii2, yiii2);
            Assert.AreEqual(200, t.xi1);
        }
    }
}

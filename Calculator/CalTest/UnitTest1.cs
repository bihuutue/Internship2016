using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testPlus()
        {
            Calculator.Request req = new Calculator.Request();
            req.setValue("4 + 5");
            double ans = req.getResult();
            Assert.AreEqual(9, ans);
        }
        [TestMethod]
        public void testMinus()
        {
            Calculator.Request req = new Calculator.Request();
            req.setValue("4 - 5");
            double ans = req.getResult();
            Assert.AreEqual(-1, ans);
        }
        [TestMethod]
        public void testTime()
        {
            Calculator.Request req = new Calculator.Request();
            req.setValue("4 * 5");
            double ans = req.getResult();
            Assert.AreEqual(20, ans);
        }

        [TestMethod]
        public void testDivide1()
        {
            Calculator.Request req = new Calculator.Request();
            req.setValue("4 / 5");
            double ans = req.getResult();
            Assert.AreEqual(0.8, ans);
        }
        [TestMethod]
        public void testDivide2()
        {
            Calculator.Request req = new Calculator.Request();
            req.setValue("4 / 0");
            double ans = req.getResult();
            bool valid = req.getValid();
            Assert.AreEqual(0, ans);
            Assert.AreEqual(false, valid);
        }
        [TestMethod]
        public void testInvalidInput1()
        {
            Calculator.Request req = new Calculator.Request();
            req.setValue("4 x 0");
            double ans = req.getResult();
            bool valid = req.getValid();
            Assert.AreEqual(0, ans);
            Assert.AreEqual(false, valid);
        }
        [TestMethod]
        public void testInvalidInput2()
        {
            Calculator.Request req = new Calculator.Request();
            bool valid = req.setValue("4 x 0 +");
            Assert.AreEqual(false, valid);
        }
        [TestMethod]
        public void testInvalidInput3()
        {
            Calculator.Request req = new Calculator.Request();
            req.setValue("4 x +");
            double ans = req.getResult();
            bool valid = req.getValid();
            Assert.AreEqual(0, ans);
            Assert.AreEqual(false, valid);
        }
    }
}

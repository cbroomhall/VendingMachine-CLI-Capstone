using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDExercises.Tests
{
    [TestClass]
    public class KataStringCalculatorTest
    {
        [TestMethod]
        public void AddTests()
        {
            KataStringCalculator testObject = new KataStringCalculator();
            //Assert.AreEqual(0, testObject.Add(""));
            //Assert.AreEqual(1, testObject.Add("1"));
            //Assert.AreEqual(3, testObject.Add("1,2"));
            //Assert.AreEqual(57, testObject.Add("12,45"));
            //Assert.AreEqual(1100, testObject.Add("500,600"));
            //Assert.AreEqual(1, testObject.Add("-1,2"));
            //Assert.AreEqual(12, testObject.Add("3,4,5"));
            //Assert.AreEqual(25, testObject.Add("3,4,5,6,7"));

            //Assert.AreEqual(3, testObject.Add("1\n2"));
            //Assert.AreEqual(12, testObject.Add("3\n4\n5"));
            //Assert.AreEqual(25, testObject.Add("3\n4\n5,6,7"));

            Assert.AreEqual(3, testObject.Add("//;\n1;2"));
            Assert.AreEqual(13, testObject.Add("//!\n4!9"));


        }
    }
}

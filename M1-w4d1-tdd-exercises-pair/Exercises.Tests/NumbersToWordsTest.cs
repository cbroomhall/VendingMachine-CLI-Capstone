using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDExercises.Tests
{
    [TestClass]
    public class NumbersToWordsTest
    {
        [TestMethod]
        public void NumsToWordsTests()
        {
            NumbersToWords testObject = new NumbersToWords();
            Assert.AreEqual("zero", testObject.NumsToWords(0));
            Assert.AreEqual("three", testObject.NumsToWords(3));
            Assert.AreEqual("fourteen", testObject.NumsToWords(14));
            Assert.AreEqual("twenty-six", testObject.NumsToWords(26));
            Assert.AreEqual("two hundred and nine", testObject.NumsToWords(209));
            Assert.AreEqual("three thousand and four", testObject.NumsToWords(3004));
            Assert.AreEqual("eighty-seven thousand and six hundred and fifty-four", testObject.NumsToWords(87654));
            Assert.AreEqual("eight hundred and three thousand and three hundred and eight", testObject.NumsToWords(803308));



        }
    }
}

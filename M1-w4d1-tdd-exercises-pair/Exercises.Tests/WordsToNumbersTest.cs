using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDExercises.Tests
{
    [TestClass]
    public class WordsToNumbersTest
    {
        [TestMethod]
        public void WordsToNumbers()
        {
            WordsToNumbers testObject = new WordsToNumbers();

            //Assert.AreEqual(0, testObject.WordsToNums("zero"));
            //Assert.AreEqual(3, testObject.WordsToNums("three"));
            //Assert.AreEqual(90, testObject.WordsToNums("ninety"));
            //Assert.AreEqual(14, testObject.WordsToNums("fourteen"));
            //Assert.AreEqual(26, testObject.WordsToNums("twenty-six"));
            //Assert.AreEqual(79, testObject.WordsToNums("seventy-nine"));
            //Assert.AreEqual(209, testObject.WordsToNums("two hundred and nine"));
            //Assert.AreEqual(200, testObject.WordsToNums("two hundred"));
            //Assert.AreEqual(250, testObject.WordsToNums("two hundred and fifty"));
            //Assert.AreEqual(257, testObject.WordsToNums("two hundred and fifty-seven"));
            Assert.AreEqual(4000, testObject.WordsToNums("four thousand"));
            //Assert.AreEqual(3004, testObject.WordsToNums("three thousand and four"));
            //Assert.AreEqual(3050, testObject.WordsToNums("three thousand and fifty"));
            //Assert.AreEqual(3057, testObject.WordsToNums("three thousand and fifty-seven"));
            //Assert.AreEqual(3500, testObject.WordsToNums("three thousand and five hundred"));
            //Assert.AreEqual(3504, testObject.WordsToNums("three thousand and five hundred and four"));
            //Assert.AreEqual(3557, testObject.WordsToNums("three thousand and five hundred and fifty-seven"));
            //Assert.AreEqual(21000, testObject.WordsToNums("twenty-one thousand"));//if thous and less than 4

            //Assert.AreEqual(20050, testObject.WordsToNums("twenty thousand and fifty"));//less than 5
            //Assert.AreEqual(20004, testObject.WordsToNums("twenty thousand and four"));

            //Assert.AreEqual(21004, testObject.WordsToNums("twenty-one thousand and four"));//less than 6
            //Assert.AreEqual(21050, testObject.WordsToNums("twenty-one thousand and fifty"));
            //Assert.AreEqual(20055, testObject.WordsToNums("twenty thousand and fifty-five"));


            //Assert.AreEqual(21021, testObject.WordsToNums("twenty-one thousand and twenty-one"));//less than 7

            //Assert.AreEqual(21500, testObject.WordsToNums("twenty-one thousand and five hundred"));
            //Assert.AreEqual(20504, testObject.WordsToNums("twenty thousand and five hundred and four"));//less than 8
            //Assert.AreEqual(21504, testObject.WordsToNums("twenty-one thousand and five hundred and four"));//less than 9
            //Assert.AreEqual(20546, testObject.WordsToNums("twenty thousand and five hundred and forty-six"));
            //Assert.AreEqual(20546, testObject.WordsToNums("twenty thousand and five hundred and forty-six"));
            //Assert.AreEqual(22546, testObject.WordsToNums("twenty-two thousand and five hundred and forty-six")); //less than 10
            //Assert.AreEqual(87654, testObject.WordsToNums("eighty-seven thousand and six hundred and fifty-four"));
            //Assert.AreEqual(803308, testObject.WordsToNums("eight hundred and three thousand and three hundred and eight"));


        }
    }
}

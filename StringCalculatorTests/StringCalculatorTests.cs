using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeKata;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeKata.Tests
{
    [TestClass()]
    public class StringCalculatorTests
    {
        [TestMethod()]
        public void ShouldReturnZeroForEmptyString()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add(string.Empty);

            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void ShouldReturnValueForSingleNumber()
        {
            var stringCalculator = new StringCalculator();
            var value = "52";

            var result = stringCalculator.Add(value);

            Assert.AreEqual(int.Parse(value), result);
        }

        [TestMethod()]
        public void ShouldReturnSumForTwoNumbersCommaDelimited()
        {
            var stringCalculator = new StringCalculator();
            var value = "5,4";
            var expected = 9;

            var result = stringCalculator.Add(value);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ShouldReturnSumForTwoNumbersNewlineDelimited()
        {
            var stringCalculator = new StringCalculator();
            var value = "5\n4";
            var expected = 9;

            var result = stringCalculator.Add(value);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ShouldReturnSumForThreeNumbersDelimitedEitherWay()
        {
            var stringCalculator = new StringCalculator();
            var value = "5,4\n1";
            var expected = 10;

            var result = stringCalculator.Add(value);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionForNegativeNumbers()
        {
            var stringCalculator = new StringCalculator();
            var value = "-5";

            stringCalculator.Add(value);
        }

        [TestMethod()]
        public void ShouldIgnoreNumbersGreaterThan1000()
        {
            var stringCalculator = new StringCalculator();
            var value = "5,4000\n1";
            var expected = 6;

            var result = stringCalculator.Add(value);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void ShouldAcceptDefiningSingleCharDelimiters()
        {
            var stringCalculator = new StringCalculator();
            var value = "//#5#4\n1";
            var expected = 10;

            var result = stringCalculator.Add(value);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldAcceptDefiningMultiCharDelimiters()
        {
            var stringCalculator = new StringCalculator();
            var value = "//[###]5###4\n1";
            var expected = 10;

            var result = stringCalculator.Add(value);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldAcceptDefiningManySingleAndMultiCharDelimiters()
        {
            var stringCalculator = new StringCalculator();
            var value = "//[###][%%%]5###4%%%1";
            var expected = 10;

            var result = stringCalculator.Add(value);

            Assert.AreEqual(expected, result);
        }
    }
}
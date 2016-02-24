using System;
using NUnit.Framework;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        private ICalculator calculator = new Calculator();

        [TestCase("2+2", 4)]
        [TestCase("2,5+2,5", 5)]
        [TestCase("2.5+2,5", 5)]
        public void TestAddition(string expression, double result)
        {
            Assert.AreEqual(Double.Parse(calculator.GetResult(expression)), result);
        }

        [TestCase("5-2", 3)]
        [TestCase("2-5", -3)]
        public void TestSubtraction(string expression, double result)
        {
            Assert.AreEqual(Double.Parse(calculator.GetResult(expression)), result);
        }

        [TestCase("2*2", 4)]
        [TestCase("2,5*2", 5)]
        [TestCase("2.5*3", 7.5)]
        public void TestMultiply(string expression, double result)
        {
            Assert.AreEqual(Double.Parse(calculator.GetResult(expression)), result);
        }

        [TestCase("2/2", 1)]
        [TestCase("2/1", 2)]
        [TestCase("2.5/2,5", 1)]
        public void TestDivision(string expression, double result)
        {
            Assert.AreEqual(Double.Parse(calculator.GetResult(expression)), result);
        }

        [TestCase("2/0")]
        [TestCase("2*(2+3")]
        public void TestException(string expression)
        {
            Assert.Throws<Exception>(() => { new Calculator().Compute(expression); });
        }

        [TestCase("-(2+2)", -4)]
        [TestCase("-2+2", 0)]
        [TestCase("2*(2+2)", 8)]
        public void TestCustomOperation(string expression, double result)
        {
            Assert.AreEqual(Double.Parse(calculator.GetResult(expression)), result);
        }

        [TestCase("(2+2)+(3*(4+5))", 31)]
        public void TestHardCustomOperation(string expression, double result)
        {
            Assert.AreEqual(Double.Parse(calculator.GetResult(expression)), result);
        }


    }
}

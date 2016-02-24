using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Tests
{
    public class OperationTests
    {
        [Test]
        public void TestSimpleDigit()
        {
            Assert.AreEqual(new SimpleDigit(5).Calculate(), 5);
        }

        [Test]
        public void TestUnaryOperation()
        {
            Assert.AreEqual(new UnaryOperation(new SimpleDigit(5),"-").Calculate(),-5);
        }

        [Test]
        public void TestBinaryOperation()
        {
            Assert.AreEqual(new BinaryOperation(new SimpleDigit(5), "-", new SimpleDigit(4)).Calculate(), 1);
        }
    }
}

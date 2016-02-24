using System;

namespace Calculator.Operations
{
    public class SimpleDigit : IOperation
    {
        private readonly double _value;

        public SimpleDigit(double digit)
        {
            _value = digit;
        }
        
        public double Calculate()
        {
            return _value;
        }

        public override string ToString()
        {
            return String.Format("{0}", _value);
        }
    }
}

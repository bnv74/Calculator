using System;

namespace Calculator.Operations
{
    public class BinaryOperation : IOperation
    {
        private readonly IOperation _leftOperation;

        private readonly IOperation _rightOperation;

        private readonly string _code;

        public BinaryOperation(IOperation left, string symbol, IOperation right)
        {
            _leftOperation = left;
            _code = symbol;
            _rightOperation = right;
        }

        public double Calculate()
        {
            switch (_code)
            {
                case "+":
                    return _leftOperation.Calculate() + _rightOperation.Calculate();
                case "-":
                    return _leftOperation.Calculate() - _rightOperation.Calculate();
                case "*":
                    return _leftOperation.Calculate() * _rightOperation.Calculate();
                case "/":
                    return _leftOperation.Calculate() / _rightOperation.Calculate();
            }
            return 0D;
        }

        public override string ToString()
        {
            return String.Format("{0}{1}{2}", _leftOperation, _code, _rightOperation);
        }
    }
}

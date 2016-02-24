using System;

namespace Calculator.Operations
{
    public class UnaryOperation : IOperation
    {
        private readonly IOperation _operation;
        private readonly string _code;

        public UnaryOperation(IOperation operation, string symbol)
        {
            _operation = operation;
            _code = symbol;
        }

        public double Calculate()
        {
            switch (_code)
            {
                case "-":
                    return -_operation.Calculate();
            }
            return 0D;
        }

        public override string ToString()
        {
            return String.Format("{0}{1}", _code, _operation);
        }
    }
}

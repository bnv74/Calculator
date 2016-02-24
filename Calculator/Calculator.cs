using System;
using System.Globalization;
using Calculator.Operations;

namespace Calculator
{
    public class Calculator : ICalculator
    {
        private string _expression;
        private int _position;

        public string GetResult(string expression)
        {
            string result;
            try
            {
                result = Compute(expression).ToString(CultureInfo.CurrentCulture);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        internal double Compute(string expression)
        { 
            _expression = expression.Replace('.', ',').Replace(" ", string.Empty);
            _position = 0;
            IOperation operation = AdditionOrSubtraction();
            return operation.Calculate();
        }

        private bool CurrentOperator(string code)
        {
            if (_position>=_expression.Length)
                return false;

            if (code.Length > 1 && _expression.Substring(_position,code.Length) == code)
            {
                _position += code.Length;
                return true;
            }
            
            if(_expression[_position].ToString(CultureInfo.CurrentCulture) == code)
            {
                _position++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Парсинг выражения
        /// </summary>
        /// <returns></returns>
        private double ParseOperation()
        {
            double result;
            var startPosition = _position;
            while (_position<_expression.Length && (char.IsDigit(_expression[_position]) || _expression[_position] == ','))
            {
                _position++;
            }
            var parseString = _expression.Substring(startPosition, _position - startPosition);
            if (!double.TryParse(parseString, out result))
                throw new Exception(String.Format("Неизвестное выражение: {0}", parseString));
            return result;
        }

        /// <summary>
        /// Обработка специфических операций
        /// </summary>
        /// <returns></returns>
        private IOperation AnyOperation()
        {
            IOperation operation;

            if (CurrentOperator("-"))
            {
                if (char.IsDigit(_expression[_position]))
                    operation = new UnaryOperation(new SimpleDigit(ParseOperation()), "-");
                else operation = new UnaryOperation(AdditionOrSubtraction(),"-");
            }
                
            else if (CurrentOperator("("))
            {
                operation = AdditionOrSubtraction();
                if (!CurrentOperator(")"))
                    throw new Exception(String.Format("Отсутствует закрывающая скобка в операции {0}", operation));
            }

            else
                operation =  new SimpleDigit(ParseOperation());
            return operation;
        }

        private IOperation AdditionOrSubtraction()
        {
            var operation = MultiplyOrDivision();
            while (_position <_expression.Length)
            {
                if (CurrentOperator("+"))
                    operation = new BinaryOperation(operation,"+",AdditionOrSubtraction());
                else if (CurrentOperator("-"))
                    operation = new BinaryOperation(operation, "-", AdditionOrSubtraction());
                else
                    break;
            }
            return operation;
        }

        private IOperation MultiplyOrDivision()
        {
            var operation = AnyOperation();
            while (_position < _expression.Length)
            {
                if (CurrentOperator("*"))
                    operation = new BinaryOperation(operation, "*", AdditionOrSubtraction());
                else if (CurrentOperator("/"))
                {
                    var rightOperation = AdditionOrSubtraction();
                    if (rightOperation.Calculate().Equals(0))
                        throw new Exception(String.Format("Деление на 0 в операции {0}/{1}", operation, rightOperation));
                    operation = new BinaryOperation(operation, "/", rightOperation);
                }
                else
                    break;
            }
            return operation;
        }
    }
}

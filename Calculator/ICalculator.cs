using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface ICalculator
    {
        /// <summary>
        /// Получить результат выражения
        /// </summary>
        /// <param name="expression">Строка выражения</param>
        /// <returns>Результат вычисления или ошибку</returns>
        string GetResult(string expression);
    }
}

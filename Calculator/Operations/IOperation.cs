using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Operations
{
    public interface IOperation
    {
        /// <summary>
        /// Вычисление результата операции
        /// </summary>
        /// <returns></returns>
        double Calculate();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите выражение:");
            var inputString = Console.ReadLine();
            ICalculator calculator = new Calculator();
            Console.WriteLine(calculator.GetResult(inputString));
            Console.Read();
        }
    }
}

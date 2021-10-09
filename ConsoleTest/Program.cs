using System;
using System.Globalization;
using System.Threading;
using CalcTheoryLab1;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var input = "((sin(1))^2 + (cos(1))^2)*exp(PI)";

            Console.WriteLine($"{input}={ExpressionCalculator.Calculate(input)}");


            Console.ReadKey();
        }
    }
}

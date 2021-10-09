using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcTheoryLab1
{
    public static class ExpressionCalculator
    {
        public static Dictionary<double, double> CalculateParametrized(string expression, string paramName, double min, double max, double step)
        {
            var res = new Dictionary<double, double>();
            var tokens = Parser.Parse(expression);
            var toks = new List<string>(tokens);

            for (double i = min; i<=max; i+=step)
            {
                for (int j=0; j<tokens.Count; ++j)
                {
                    if (tokens[j].Equals(paramName))
                        toks[j] = i.ToString();
                }

                res[i] = RPN.CalculateRPN(RPN.ToRpn(toks));
            }

            return res;
        }

        public static double Calculate(string expression)
        {
            var tokens = Parser.Parse(expression);
            return RPN.CalculateRPN(RPN.ToRpn(tokens));
        }
    }
}

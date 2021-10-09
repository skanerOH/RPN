using System;
using System.Collections.Generic;
using System.Text;

namespace CalcTheoryLab1
{
    internal static class Lexer
    {
        private static List<string> Functions = new List<string> { "sin", "cos", "tg", "abs", "exp", "^", "sqrt" };
        private static Dictionary<string, double> Constants = new Dictionary<string, double> {["PI"] = 3.14159265359D, ["E"] = 2.71828182846D };
        private static List<string> Operators = new List<string> { "+", "-", "/", "*" };

        public static bool IsFunc(string token)
        {
            return Functions.Contains(token);
        }

        public static bool IsOperator(string token)
        {
            return Operators.Contains(token);
        }

        public static bool IsValue(string token)
        {
            if ((new List<string>(Constants.Keys)).Contains(token))
                return true;
            double res;
            return Double.TryParse(token, out res);
        }

        public static double GetValue(string token)
        {
            if ((new List<string>(Constants.Keys)).Contains(token))
                return Constants[token];
            return Double.Parse(token);
        }

        public static int GetPriority(string token)
        {
            if (IsValue(token))
                return 999;
            if (IsFunc(token))
                return 10;
            if (IsOperator(token))
            {
                if (token.Equals("+"))
                    return 6;
                if (token.Equals("-"))
                    return 6;
                if (token.Equals("/"))
                    return 8;
                if (token.Equals("*"))
                    return 8;
            }

            return -1;
        }
    }
}

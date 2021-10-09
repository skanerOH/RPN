using System;
using System.Collections.Generic;
using System.Text;

namespace CalcTheoryLab1
{
    internal static class RPN
    {
        public static List<string> ToRpn(List<string> tokens)
        {
            if (tokens[0].Equals("-"))
                tokens.Insert(0, "0");
            for (int i=1; i< tokens.Count; ++i)
            {
                if (tokens[i].Equals("-") && !Lexer.IsValue(tokens[i - 1]))
                    tokens.Insert(i, "0");
            }

            List<string> res = new List<string>();
            Stack<string> stack = new Stack<string>();

            foreach (var token in tokens)
            {
                if (Lexer.IsValue(token))
                    res.Add(token);
                else if (Lexer.IsFunc(token) || token.Equals("("))
                    stack.Push(token);
                else if (Lexer.IsOperator(token))
                {
                    while (stack.Count > 0 && !stack.Peek().Equals("(") && Lexer.GetPriority(token) <= Lexer.GetPriority(stack.Peek()))
                    {
                        res.Add(stack.Pop());
                    }
                    stack.Push(token);
                }
                else if (token.Equals(")"))
                {
                    while (stack.Count > 0 && !stack.Peek().Equals("("))
                    {
                        res.Add(stack.Pop());
                    }
                    if (stack.Count > 0)
                        stack.Pop();
                    else
                        throw new Exception($"Brackets error");
                }
                else
                    throw new Exception($"Unknown token {token}");
            }

            while (stack.Count > 0)
                res.Add(stack.Pop());

            return res;
        }

        public static double CalculateRPN(List<string> tokensInRNP)
        {
            Stack<double> stack = new Stack<double>();

            foreach (var token in tokensInRNP)
            {
                if (Lexer.IsValue(token))
                {
                    stack.Push(Lexer.GetValue(token));
                }
                else switch (token)
                    {
                        case "+":
                            {
                                double v1 = stack.Pop();
                                double v2 = stack.Pop();
                                stack.Push(v2 + v1);
                            }
                            break;
                        case "-":
                            {
                                double v1 = stack.Pop();
                                double v2 = stack.Pop();
                                stack.Push(v2 - v1);
                            }
                            break;
                        case "*":
                            {
                                double v1 = stack.Pop();
                                double v2 = stack.Pop();
                                stack.Push(v2 * v1);
                            }
                            break;
                        case "/":
                            {
                                double v1 = stack.Pop();
                                double v2 = stack.Pop();
                                if (v2 == 0)
                                    throw new Exception($"Zero devision");
                                stack.Push(v2 / v1);
                            }
                            break;
                        case "sin":
                            {
                                double v1 = stack.Pop();
                                stack.Push(Math.Sin(v1));
                            }
                            break;
                        case "cos":
                            {
                                double v1 = stack.Pop();
                                stack.Push(Math.Cos(v1));
                            }
                            break;
                        case "tg":
                            {
                                double v1 = stack.Pop();
                                stack.Push(Math.Tan(v1));
                            }
                            break;
                        case "abs":
                            {
                                double v1 = stack.Pop();
                                stack.Push(Math.Abs(v1));
                            }
                            break;
                        case "exp":
                            {
                                double v1 = stack.Pop();
                                stack.Push(Math.Exp(v1));
                            }
                            break;
                        case "sqrt":
                            {
                                double v1 = stack.Pop();
                                if (v1 < 0)
                                    throw new Exception($"Sqrt negative value");
                                stack.Push(Math.Sqrt(v1));
                            }
                            break;
                        case "^":
                            {
                                double v1 = stack.Pop();
                                double v2 = stack.Pop();
                                if (v1 == 0 && v2 == 0)
                                    throw new Exception($"0^0");
                                stack.Push(Math.Pow(v2, v1));
                            }
                            break;
                        default:
                            if (token.Equals("("))
                                throw new Exception($"Brackets error");
                            throw new Exception($"Unknown error");
                    }
            }

            if (stack.Count > 1)
                throw new Exception($"Input expression error");

            return stack.Pop();
        }
    }
}

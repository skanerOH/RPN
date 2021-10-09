using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CalcTheoryLab1
{
    internal static class Parser
    {
        public static List<string> Parse(string input)
        {
            var res = Regex.Split(input, @"(\b\w*[\.]?\w+\b|[\(\)\+\*\-\/])");

            return res.Where(t => !String.IsNullOrWhiteSpace(t)).ToList();
        }
    }
}

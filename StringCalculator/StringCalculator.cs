using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeKata
{
    public class StringCalculator
    {
        private static readonly string[] DELIMITERS = new string[] { ",", "\n" }; 

        public int Add(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return 0;
            }

            var match = Regex.Match(number, @"^//((\[.+\])+|.{1})");
            var foundDelimiters = match.Value.TrimStart('/').Split("][", StringSplitOptions.RemoveEmptyEntries).Select(m => m.Trim('[', ']'));

            if (match.Success)
            {
                number = number.Substring(match.Index + match.Length);
            }

            var delimiters = DELIMITERS.Concat(foundDelimiters);

            var values = number.Split(delimiters.ToArray(), StringSplitOptions.None);

            var sum = 0;
            foreach (var value in values)
            {
                var num = int.Parse(value);
                if(num < 0)
                {
                    throw new ArgumentException();
                }
                if(num > 1000)
                {
                    continue;
                }
                sum += num;
            }

            return sum;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderPractice
{
    //https://atcoder.jp/contests/abc237/tasks/abc237_a
    class NotOverFlow
    {
        static void Main(string[] args)
        {
            try
            {
                var input = Console.ReadLine();
                var isNumber = new ValidateNum().IsNumber(input);
                if (!isNumber)
                {
                    throw new FormatException("数字のみを入力してください");
                }

                Console.WriteLine("Yes");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
                Console.WriteLine("No");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
                Console.WriteLine("No");
            }
        }
    }

    class ValidateNum
    {
        public bool IsNumber(string num_str)
        {
            var minus = "-";
            if (string.IsNullOrEmpty(num_str))
            {
                return false;
            }
            num_str = (num_str.StartsWith(minus)) ? num_str.Substring(1) : num_str;
            return (num_str.All(char.IsDigit));
        }
    }
}

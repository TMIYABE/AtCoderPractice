using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderPractice
{
    class NotOverFlow
    {
        static void Main(string[] args)
        {
            try
            {
                var input = Console.ReadLine();
                var isNumber = new ValidateNum().isNumber(input);
                if (!isNumber)
                {
                    throw new FormatException("数字のみを入力してください");
                }

                var num = int.Parse(input);
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
        public bool isNumber(string num_str)
        {
            if (string.IsNullOrEmpty(num_str))
            {
                return false;
            }
            var headChar = num_str.Substring(0, 1);
            num_str = (headChar == "-") ? num_str.Substring(1) : num_str;
            return (num_str.All(char.IsDigit));
        }
    }
}

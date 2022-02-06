using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderPractice._236
{
    class A___chukodai
    {
        static void Main(string[] args)
        {
            try
            {
                var S = Console.ReadLine();
                var ab = Console.ReadLine().Split(' ');
                var inputExchanger = new InputExchanger(S, ab);

                Console.WriteLine(inputExchanger.ExchangeTwoChars(inputExchanger.input, inputExchanger.a, inputExchanger.b));

            }
            catch (FormatException ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
            }
        }
    }

    class InputExchanger
    {
        public char[] input;
        public int a;
        public int b;
        public InputExchanger(string inputStr, string[] nums)
        {
            checkSmallLetter(inputStr);
            checkTwoNumbers(nums, inputStr);
            input = inputStr.ToCharArray();
            a = int.Parse(nums[0]);
            b = int.Parse(nums[1]);
        }
        private void checkSmallLetter(string input)
        {
            if (string.IsNullOrEmpty(input) || !input.All(Char.IsLower))
            {
                throw new FormatException("小文字のみの文字列を、1文字以上入力してください。");
            }
        }
        private void checkTwoNumbers(string[] input, string inputStr)
        {
            if (input.Count() != 2 || input.Any(x => string.IsNullOrEmpty(x)))
            {
                throw new FormatException("スペースで区切った2つの数字を渡して下さい");
            }

            if (input.Any(x => !x.All(Char.IsDigit)))
            {
                throw new FormatException("数字のみを渡してください");
            }

            if (int.Parse(input[1]) <= int.Parse(input[0]) || inputStr.Length < int.Parse(input[1]))
            {
                throw new FormatException("数字は2つ目が1つ目より大きく、2つ目は1行目で入力した文字列長以下にしてください。");
            }
        }
        public string ExchangeTwoChars(char[] arr_char, int firstNum, int secondNum)
        {
            var firstIdx = firstNum - 1;
            var secondIdx = secondNum - 1;
            var firstChar = arr_char[firstIdx];
            var secondChar = arr_char[secondIdx];

            arr_char[firstIdx] = secondChar;
            arr_char[secondIdx] = firstChar;

            return String.Join("", arr_char);
        }
    }
}

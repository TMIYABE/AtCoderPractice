using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderPractice
{
    //https://atcoder.jp/contests/abc237/tasks/abc237_c
    class C___kasaka
    {
        static void Main(string[] args)
        {
            try
            {
                var input = Console.ReadLine();
                var checker = new Checker();
                checker.CheckInput(input);

                if (checker.CheckReversible_ByAdding_a(input))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }


            }
            catch (FormatException ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
                Console.WriteLine("No");
            }
        }
    }

    class Checker
    {
        public void CheckInput(string input)
        {
            if (input.Count() == 0 || !input.All(Char.IsLower))
            {
                throw new FormatException("小文字のみの文字列を、1文字以上入力してください。");
            }
        }

        //先頭にaを加えることで反転可能になるかどうかのチェック
        public bool CheckReversible_ByAdding_a(string input)
        {
            string input_without_a;
            char a = 'a';
            if (input.All(x => x == a)) return true;

            var a_count_front = Count_a(input);

            var input_reverse = String.Join("", input.Reverse());
            var a_count_back = Count_a(input_reverse);

            if (a_count_front > a_count_back) return false;

            input_without_a = input.Substring(a_count_front, input.Length - a_count_front - a_count_back);
            return CheckReversible(input_without_a.ToArray());


        }

        private int Count_a(string str)
        {
            char a = 'a';
            var a_count = str.TakeWhile(x => x == a).Count();

            return a_count;
        }

        private bool CheckReversible(char[] arr)
        {
            var arrClone = new String(arr);
            return arrClone.Reverse().ToArray().SequenceEqual(arr);
        }
    }
}

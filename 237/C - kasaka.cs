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
            var input = Console.ReadLine();
            var checker = new Checker();

            if (checker.CheckInput(input) && checker.CheckReversibleByAdding_a(input))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
                checker.errList.ForEach(ex =>
                    Console.WriteLine("\nMessage ---\n{0}", ex.Message));
            }
        }
    }

    class Checker
    {
        public List<Exception> errList = new List<Exception>();
        public bool hasError = false;
        public bool CheckInput(string input)
        {
            if (input.Count() == 0 || !input.All(Char.IsLower))
            {
                hasError = true;
                errList.Add(new FormatException("小文字のみの文字列を、1文字以上入力してください。"));
            }

            return hasError;
        }

        //先頭にaを加えることで反転可能になるかどうかのチェック
        public bool CheckReversibleByAdding_a(string input)
        {
            string inputWithout_a;
            char a = 'a';
            if (input.All(x => x == a)) return true;

            var frontCount_a = Count_a(input);

            var inputReversed = String.Join("", input.Reverse());
            var backCount_a = Count_a(inputReversed);

            if (frontCount_a > backCount_a) return false;

            inputWithout_a = input.Substring(frontCount_a, input.Length - frontCount_a - backCount_a);
            return CheckReversible(inputWithout_a.ToArray());


        }

        private int Count_a(string str)
        {
            char a = 'a';
            var count = str.TakeWhile(x => x == a).Count();

            return count;
        }

        private bool CheckReversible(char[] arr)
        {
            var arrClone = new String(arr);
            return arrClone.Reverse().ToArray().SequenceEqual(arr);
        }
    }
}

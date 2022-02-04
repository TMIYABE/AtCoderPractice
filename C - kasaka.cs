using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderPractice
{
    class C___kasaka
    {
        static void Main(string[] args)
        {
            try
            {
                var input = Console.ReadLine();
                var check = new Check();
                check.CheckInput(input);

                if (check.CheckReversible_ByAdding_a(input))
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

    class Check
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
            char a = 'a';
            if (input.All(x => x == a)) return true;

            var a_count_front = Count_a(ref input);

            input = String.Join("", input.Reverse());
            var a_count_back = Count_a(ref input);

            if (a_count_front > a_count_back) return false;

            return CheckReversible(input.ToArray());


        }

        private int Count_a(ref string str)
        {
            char a = 'a';
            int a_count = 0;
            var str_length = str.Count();
            for (int i = 0; i < str_length; i++)
            {
                if (str[i] == a)
                {
                    a_count++;
                    continue;
                }
                break;
            }
            str = str.Substring(a_count);
            return a_count;
        }

        private bool CheckReversible(char[] arr)
        {
            var arrClone = new String(arr);
            return arrClone.Reverse().ToArray().SequenceEqual(arr);
        }
    }
}

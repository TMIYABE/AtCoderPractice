using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderPractice._236
{
    //https://atcoder.jp/contests/abc236/tasks/abc236_b
    class B___Who_is_missing
    {
        static void Main(string[] args)
        {
            var N = Console.ReadLine();
            var AList = Console.ReadLine().Split(' ').ToArray();

            var checker = new Checker();
            if (!checker.CheckN(N))
            {
                if (!checker.CheckAList(AList, N))
                {
                    var card = new Card(N, AList);
                    Console.WriteLine(card.JudgeSelectedCard());
                }
            }

            if (checker.hasError)
            {
                checker.errList.ForEach(ex =>
                {
                    Console.WriteLine("\nMessage ---\n{0}", ex.Message);
                });
            }

        }
    }
    class Card
    {
        public int maxNum;
        public int NumOfCards;
        public int[] cardList;

        public Card(string N, string[] AList)
        {
            maxNum = int.Parse(N);
            NumOfCards = 4 * maxNum - 1;

            cardList = AList.Select(A => int.Parse(A)).ToArray();
        }

        public int JudgeSelectedCard()
        {
            var groupedCards = cardList.GroupBy(x => x).Select(y => new { num = y.Key, count = y.Count() });

            return groupedCards.FirstOrDefault(x => x.count != 4).num;
        }
    }

    class Checker
    {
        public List<Exception> errList = new List<Exception>();
        public bool hasError = false;

        public bool CheckN(string N)
        {
            if (String.IsNullOrEmpty(N) || !N.All(Char.IsDigit))
            {
                errList.Add(new FormatException("Nは数値でなければいけません。"));
                hasError = true;
            }

            if (int.Parse(N) < 1 || 100000 < int.Parse(N))
            {
                errList.Add(new FormatException("Nは1以上100000以下でなければいけません。"));
                hasError = true;
            }

            return hasError;
        }
        public bool CheckAList(string[] AList, string N)
        {
            var numN = int.Parse(N);
            if (AList.Count() != 4 * numN - 1)
            {
                errList.Add(new FormatException("渡したカード枚数が正しくありません"));
                hasError = true;
            }

            if (AList.Any(A => !A.All(Char.IsDigit)))
            {
                errList.Add(new FormatException("渡したカードの値として、全て数値を入力してください。"));
                hasError = true;
            }

            if (AList.Any(A => int.Parse(A) < 1 || numN < int.Parse(A)))
            {
                errList.Add(new FormatException("渡すカードの値は1以上N以下でなければいけません。"));
                hasError = true;
            }

            return hasError;
        }
    }
}

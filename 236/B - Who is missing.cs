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

            var card = new Card(N, AList);

            if (!card.hasError)
            {
                Console.WriteLine(card.JudgeSelectedCard());
            }
            else
            {
                card.errList.ForEach(ex =>
                {
                    Console.WriteLine("\nMessage ---\n{0}", ex.Message);
                });
            }

        }
    }
    class Card
    {
        public int maxNum;
        public int NumofCards;
        public int[] cardList;

        public List<Exception> errList = new List<Exception>();
        public bool hasError = false;

        public Card(string N, string[] AList)
        {
            if (!CheckN(N))
            {
                maxNum = int.Parse(N);
                NumofCards = 4 * maxNum - 1;

                if (!CheckAList(AList))
                {
                    cardList = AList.Select(A => int.Parse(A)).ToArray();
                }
            }
        }
        private bool CheckN(string N)
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
        private bool CheckAList(string[] AList)
        {
            if (AList.Count() != NumofCards)
            {
                errList.Add(new FormatException("渡したカード枚数が正しくありません"));
                hasError = true;
            }

            if (AList.Any(A => !A.All(Char.IsDigit)))
            {
                errList.Add(new FormatException("渡したカードの値として、全て数値を入力してください。"));
                hasError = true;
            }

            if (AList.Any(A => int.Parse(A) < 1 || maxNum < int.Parse(A)))
            {
                errList.Add(new FormatException("渡すカードの値は1以上N以下でなければいけません。"));
                hasError = true;
            }

            return hasError;
        }

        public int JudgeSelectedCard()
        {
            var groupedCards = cardList.GroupBy(x => x).Select(y => new { num = y.Key, count = y.Count() });

            return groupedCards.FirstOrDefault(x => x.count != 4).num;
        }
    }
}

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
            try
            {
                var N = Console.ReadLine();
                var AList = Console.ReadLine().Split(' ').ToArray();

                var card = new Card(N, AList);

                Console.WriteLine(card.JudgeSelectedCard());
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
            }

        }
    }
    class Card
    {
        public int maxNum;
        public int NumofCards;
        public int[] cardList;

        public Card(string N, string[] AList)
        {
            CheckN(N);
            maxNum = int.Parse(N);
            NumofCards = 4 * maxNum - 1;

            CheckAList(AList);
            cardList = AList.Select(A => int.Parse(A)).ToArray();
        }
        private void CheckN(string N)
        {
            if (String.IsNullOrEmpty(N) || !N.All(Char.IsDigit))
            {
                throw new FormatException("Nは数値でなければいけません。");
            }

            if (int.Parse(N) < 1 || 100000 < int.Parse(N))
            {
                throw new FormatException("Nは1以上100000以下でなければいけません。");
            }
        }
        private void CheckAList(string[] AList)
        {
            if (AList.Count() != NumofCards)
            {
                throw new FormatException("渡したカード枚数が正しくありません");
            }

            if (AList.Any(A => !A.All(Char.IsDigit)))
            {
                throw new FormatException("渡したカードの値として、全て数値を入力してください。");
            }

            if (AList.Any(A => int.Parse(A) < 1 || maxNum < int.Parse(A)))
            {
                throw new FormatException("渡すカードの値は1以上N以下でなければいけません。");
            }
        }

        public int JudgeSelectedCard()
        {
            var groupedCards = cardList.GroupBy(x => x).Select(y => new { num = y.Key, count = y.Count() });

            return groupedCards.FirstOrDefault(x => x.count != 4).num;
        }
    }
}

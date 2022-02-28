using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderPractice._236
{
    //https://atcoder.jp/contests/abc236/tasks/abc236_c
    class C___Route_Map
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split(' ');
            var secondInput = Console.ReadLine().Split(' ');
            var thirdInput = Console.ReadLine().Split(' ');
            var station = new Station(firstInput, secondInput, thirdInput);
            if (station.err.hasError)
            {
                station.err.errList.ForEach(ex => Console.WriteLine("\nMessage ---\n{0}", ex.Message));
            }
            else
            {
                station.Output_RapidStopsOrNot();
            }
        }
    }
    class Station
    {
        public int stationNum_localStop;
        public int stationNum_rapidStop;
        public string[] localStops;
        public string[] rapidStops;

        public ErrorList err = new ErrorList() { hasError = false, errList = new List<Exception>() };

        public Station(string[] firstInput, string[] secondInput, string[] thirdInput)
        {
            var checker = new Checker();
            err.errList.AddRange(checker.FirstInputCheck(firstInput));
            if (err.errList.Any())
            {
                err.hasError = true;
            }
            else
            {
                var stationNums = firstInput.Select(x => int.Parse(x)).ToArray();
                stationNum_localStop = stationNums[0];
                stationNum_rapidStop = stationNums[1];
                err.errList.AddRange(checker.StationNameInputCheck(secondInput, stationNum_localStop));
                err.errList.AddRange(checker.StationNameInputCheck(thirdInput, stationNum_rapidStop));
                if (err.errList.Any())
                {
                    err.hasError = true;
                }
                else
                {
                    err.errList.AddRange(checker.StationNameConsistencyCheck(secondInput, thirdInput));
                    if (err.errList.Any())
                    {
                        err.hasError = true;
                    }
                    else
                    {
                        localStops = secondInput;
                        rapidStops = thirdInput;
                    }
                }
            }
        }

        public void Output_RapidStopsOrNot()
        {
            var nextRapidStopIdx = 0;
            foreach (var stop in localStops)
            {
                if (rapidStops[nextRapidStopIdx] == stop)
                {
                    Console.WriteLine("Yes");
                    nextRapidStopIdx++;
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
        }
    }
    class Checker
    {
        public List<Exception> FirstInputCheck(string[] firstInput)
        {
            var ret = new List<Exception>();
            if (firstInput.Count() != 2)
            {
                ret.Add(new FormatException("1行目の入力は、半角スペース区切りで2つでなければいけません。"));
            }
            if (firstInput.Any(x => String.IsNullOrEmpty(x) || !x.All(y => Char.IsDigit(y))))
            {
                ret.Add(new FormatException("2つの入力はどちらも数字でなければいけません。"));
            }
            var stationNums = firstInput.Select(x => int.Parse(x)).ToArray();
            if (stationNums[0] < 2 || 100000 < stationNums[1] || stationNums[0] < stationNums[1])
            {
                ret.Add(new FormatException("2≦M≦N≦10^5の範囲で2つの入力は定義してください。"));
            }
            return ret;
        }

        public List<Exception> StationNameInputCheck(string[] input, int stationNum)
        {
            var ret = new List<Exception>();
            if (input.Count() != stationNum)
            {
                ret.Add(new FormatException("1行目で設定した駅数分、駅名をセットしてください。"));
            }
            if (input.Any(x => String.IsNullOrEmpty(x) || !x.All(y => Char.IsLower(y)) || 10 < x.Count()))
            {
                ret.Add(new FormatException("入力は全て英小文字で10文字以下である必要があります。"));
            }
            if (input.GroupBy(x => x).Where(y => y.Count() > 1).Count() > 0)
            {
                ret.Add(new FormatException("入力の中に重複した駅名があります。"));
            }

            return ret;
        }
        public List<Exception> StationNameConsistencyCheck(string[] secondInput, string[] thirdInput)
        {
            var ret = new List<Exception>();
            if (secondInput.FirstOrDefault() != thirdInput.FirstOrDefault()
                || secondInput.LastOrDefault() != thirdInput.LastOrDefault())
            {
                ret.Add(new FormatException("2行目の入力と3行目の入力の最初と最後の要素は同一である必要があります。"));
            }
            //(メモ)このチェックを入れるとTLE判定
            //if (thirdInput.Any(x => !secondInput.Contains(x)))
            //{
            //    throw new FormatException("2行目の入力に含まれない文字列が3行目にあってはいけません。");
            //}
            return ret;

        }


    }
    class ErrorList
    {
        public bool hasError;
        public List<Exception> errList;
    }
}

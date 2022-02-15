using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderPractice
{
    //https://atcoder.jp/contests/abc237/tasks/abc237_b
    class B___Matrix_Transposition
    {
        static void Main(string[] args)
        {
            try
            {
                var input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
                if (input.Count() != 2)
                {
                    throw new FormatException("数字を2つ、半角スペースで区切って入力してください");
                }
                var H = input[0];
                var W = input[1];

                var mrx = new Matrix(H, W);
                var matrix = mrx.matrix;
                var matrix_inverted = mrx.matrix_inverted;

                mrx.outputMatrixToConsole(matrix_inverted);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("\nMessage ---\n{0}", ex.Message);
            }
        }
    }

    class Matrix
    {
        public int[,] matrix;
        public int[,] matrix_inverted;

        public Matrix(int Height, int Width)
        {
            matrix = SetupMatrix(Height, Width);
            matrix_inverted = InvertMatrix(matrix);
        }

        private int[,] SetupMatrix(int Height, int Width)
        {
            var ret = new int[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    ret[i, j] = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList()[j];
                }
            }
            return ret;
        }
        private int[,] InvertMatrix(int[,] matrix)
        {
            var argHeight = matrix.GetLength(0);
            var argWidth = matrix.GetLength(1);

            var ret = new int[argWidth, argHeight];

            for (int i = 0; i < argWidth; i++)
            {
                for (int j = 0; j < argHeight; j++)
                {
                    ret[i, j] = matrix[j, i];
                }
            }

            return ret;
        }

        public void outputMatrixToConsole(int[,] matrix)
        {
            var argHeight = matrix.GetLength(0);
            var argWidth = matrix.GetLength(1);

            for (int i = 0; i < argHeight; i++)
            {
                for (int j = 0; j < argWidth; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}

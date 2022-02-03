using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderPractice
{
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
                var A = new int[H, W];

                var setup = new Setup();
                setup.SetupMatrix(A, H, W);

                var B = setup.InvertMatrix(A);
                new Output().outputMatrixToConsole(B);
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

    class Setup
    {
        public void SetupMatrix(int[,] matrix, int Hight, int Width)
        {
            for (int i = 0; i < Hight; i++)
            {
                var matrixRow = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

                for (int j = 0; j < Width; j++)
                {
                    matrix[i, j] = matrixRow[j];
                }
            }
        }

        public int[,] InvertMatrix(int[,] matrix)
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
    }
    class Output
    {
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

﻿using System.Text;

namespace PR2
{
    internal class Program
    {
        public static readonly double[] X = new[] { 1.21, 1.29, 1.45, 1.61, 1.92, 2.22 };
        public static double[] XSquare = new double[X.Length];
        public static readonly double[] Y = new[] { 3.94, 4.11, 4.18, 4.23, 4.48, 4.53 };
        public static double[] XMultiplyByY = new double[X.Length];

        private static void XSquareAndXYMultiply()
        {
            for (int i = 0; i < X.Length; i++)
            {
                XSquare[i] = X[i] * X[i];
                XMultiplyByY[i] = X[i] * Y[i];
            }
        }

        static void Main(string[] args)
        {
            Approximation.ApproximationPrintData(Approximation.ApproximationCalculation());
        }

        public struct Approximation
        {
            public double Triangle;
            public double TriangleA;
            public double TriangleB;
            public double A;
            public double B;

            public static void ApproximationPrintData(Approximation ApproximationData)
            {
                Console.Write("X: ");
                for (int i = 0; i < X.Length; i++)
                {
                    Console.Write($"{X[i]} ");
                }

                Console.WriteLine();

                Console.Write("Y: ");
                for (int i = 0; i < X.Length; i++)
                {
                    Console.Write($"{Y[i]} ");
                }

                Console.WriteLine("\n");

                Console.OutputEncoding = Encoding.Unicode;
                char Symbol = '∆';

                Console.WriteLine($"{Symbol} - {ApproximationData.Triangle}");
                Console.WriteLine($"{Symbol}a - {ApproximationData.TriangleA}");
                Console.WriteLine($"{Symbol}b - {ApproximationData.TriangleB}");
                Console.WriteLine($"\nA - {ApproximationData.A}");
                Console.WriteLine($"B - {ApproximationData.B}");
            }

            public static Approximation ApproximationCalculation()
            {
                Approximation Data = new();
                XSquareAndXYMultiply();

                Data.Triangle = XSquare.Sum() * X.Length;
                Data.Triangle += (X.Sum() * X.Sum()) * -1;

                Data.TriangleA = XMultiplyByY.Sum() * X.Length;
                Data.TriangleA += (Y.Sum() * X.Sum()) * -1;

                Data.TriangleB = XSquare.Sum() * Y.Sum();
                Data.TriangleB += (X.Sum() * XMultiplyByY.Sum()) * -1;

                Data.A = Data.TriangleA / Data.Triangle;
                Data.B = Data.TriangleB / Data.Triangle;

                return Data;
            }
        }
    }
}
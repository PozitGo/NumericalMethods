﻿using System.Reflection.Metadata.Ecma335;

namespace SR1_2._0
{

    internal class Program
    {
        public static readonly double[] X = new[] { 0.206, 0.2065, 0.2069, 0.2075, 0.2085 };
        public static readonly double[] Y = new[] { 0.208964, 0.209486, 0.209904, 0.21053, 0.211575 };

        private static List<double> P = new();
        public static readonly double Xz = 0.2072;

        private static void EulerMethodStep(int Step = 1, int IndexPolinom = 0)
        {
            if (Step == 1)
            {
                for (int i = 0; i < Y.Length - Step && i < X.Length - Step; i++)
                {
                    double Sum = Y[i] * (X[i + Step] - Xz);
                    Sum += (Y[i + Step] * (X[i] - Xz)) * -1;
                    P.Add(Sum / (X[i + Step] - X[i]));
                }
            }
            else
            {
                for (int i = 0; i < Y.Length - Step && i < X.Length - Step; i++)
                {
                    double Sum = P[IndexPolinom] * (X[i + Step] - Xz);
                    Sum += (P[IndexPolinom + 1] * (X[i] - Xz)) * -1;
                    P.Add(Sum / (X[i + Step] - X[i]));
                    IndexPolinom++;
                }
            }

            Step++;
            if (Step != 5)
            {
                if (Step == 2)
                {
                    EulerMethodStep(Step, IndexPolinom);
                }
                else
                {
                    EulerMethodStep(Step, IndexPolinom + 1);
                }
            }


        }

        public static void Print()
        {
            Console.WriteLine($"P01 - {P[0]}");
            Console.WriteLine($"P012 - {P[4]}");
            Console.WriteLine($"P0123 - {P[7]}");
            Console.WriteLine($"P01234 - {P[9]}");

            Console.WriteLine($"\nX* - {Xz}");
        }

        static void Main(string[] args)
        {
            EulerMethodStep();
            Print();
        }
    }
}
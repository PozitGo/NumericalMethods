using System;
using System.Drawing;
using System.Linq;

namespace PR4
{
    class Program
    {
        const int SizeSystem = 4;
        const double eps = 0.001;

        public static double[,] A = new double[SizeSystem, SizeSystem]
        {
                {17.5, 1.75, -4.375, 5.25},
                {2.33, 11.65, 4.0775, -1.165},
                {-3.96, 1.32, 13.2, 5.28},
                {3.6125, -4.335, 2.1675, 14.45}
        };

        public static double[] B = { 13.4, 4.69, -2.01, 17.42 };


        public static double[] Seidel()
        {
            int CountFulfilledСonditions = 0;

            double[] X1 = new double[SizeSystem] { 0, 0, 0, 0 };
            double[] X2 = new double[SizeSystem];

            do
            {
                bool[] Condition = new bool[4] { true, true, true, true };

                for (int i = 0; i < SizeSystem; i++)
                {
                    double Sum = 0;
                    for (int j = 0; j < SizeSystem; j++)
                    {
                        if (i != j)
                        {
                            Sum += A[i, j] * X1[j];
                        }
                    }

                    X2[i] = 1 / A[i, i] * (B[i] + (Sum * -1));
                }

                for (int i = 0; i < SizeSystem; i++)
                {
                    if (Math.Abs(X2[i] - X1[i]) < eps)
                    {
                        Condition[i] = false;
                    }
                }

                for (int i = 0; i < SizeSystem; i++) X1[i] = X2[i];

                CountFulfilledСonditions = Condition.Where(x => x is false).Count();

            } while (!(CountFulfilledСonditions is 4));

            return X2;
        }

        public static void Print(double[] X)
        {
            for (int i = 0; i < X.Length; i++)
            {
                Console.WriteLine($"X{i + 1} - {X[i]}");
            }
        }

        static void Main(string[] args)
        {
            Print(Seidel());
        }
    }

}

using System.Security.Cryptography.X509Certificates;

namespace PR1
{
    internal class Program
    {
        public static readonly double[] X = new[] { 1.21, 1.29, 1.45, 1.61, 1.92, 2.22 };
        public static readonly double[] Y = new[] { 3.94, 4.11, 4.18, 4.23, 4.48, 4.53 };

        public static readonly double Xz = 1.35;

        static void Main(string[] args)
        {
            Print();
        }
        //Линейная
        static double LinearInterpolation(int iter)
        {
            double LineInterpolationResult = 0;

            for (int i = iter; i <= iter + 1; i++)
            {
                double temp = 1;
                for (int j = iter; j <= iter + 1; j++)
                {
                    if (j != i)
                    {
                        temp *= (Xz - X[j]) / (X[i] - X[j]);
                    }
                }

                LineInterpolationResult += Y[i] * temp;
            }

            return LineInterpolationResult;
        }
        //Лагранж
        static double LagrangeInterpolation()
        {
            double LagrangeInterpolationResult = 0;

            for (int i = 0; i < X.Length; i++)
            {
                double temp = 1;
                for (int j = 0; j < X.Length; j++)
                {
                    if (j != i)
                    {
                        temp *= (Xz - X[j]) / (X[i] - X[j]);
                    }
                }

                LagrangeInterpolationResult += Y[i] * temp;
            }

            return LagrangeInterpolationResult;
        }
        //Квадратичная
        static double QuadraticInterpolation(int iter)
        {
            double SquareInterpolationResult = 0;

            for (int i = iter; i <= iter + 2; i++)
            {
                double temp = 1;
                for (int j = iter; j <= iter + 2; j++)
                {
                    if (j != i)
                    {
                        temp *= (Xz - X[j]) / (X[i] - X[j]);
                    }
                }

                SquareInterpolationResult += Y[i] * temp;
            }

            return SquareInterpolationResult;
        }
        //Проверка на то, между какими точками будет находится Xz
        static int CheckIter()
        {
            int ResultIter = 0;
            for (int i = 0; i < X.Length; i++)
            {
                if (Xz > X[i] && Xz < X[i + 1])
                {
                    if (i == X.Length - 1)
                    {
                        ResultIter = i - 2;
                    }
                    else if (i == X.Length - 2)
                    {
                        ResultIter = i - 1;
                    }
                    else
                    {
                        ResultIter = i;
                    }
                }
            }

            return ResultIter;
        }

        static void Print()
            {
                double tempLinearInterpolation = LinearInterpolation(CheckIter());

                Console.WriteLine("i  X    Y    Xz    Yz");
                for (int i = 0; i < X.Length && i < Y.Length; i++)
                {
                    if (i is 0)
                    {
                        if (Xz > X[i] && Xz < X[i + 1])
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{i} {X[i]} {Y[i]} {Xz}  {Math.Round(tempLinearInterpolation, 5)}");
                        }
                        else
                        {
                            Console.WriteLine($"{i} {X[i]} {Y[i]} {Xz}");
                        }
                    }
                    else
                    {
                        if (Xz > X[i] && Xz < X[i + 1])
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{i} {X[i]} {Y[i]}\t  {Math.Round(tempLinearInterpolation, 5)}");
                        }
                        else
                        {
                            Console.WriteLine($"{i} {X[i]} {Y[i]}");
                            Console.ResetColor();
                        }
                    }
                }

                Console.WriteLine("\t");
                Console.WriteLine($"Линейная интерполяция: {tempLinearInterpolation}");
                Console.WriteLine($"Интерполяция Лагранжа:  {LagrangeInterpolation()}");
                Console.WriteLine($"Квадратичная интерполяция: {QuadraticInterpolation(CheckIter())}");
            }
        }
    }
using System.Net;

namespace PR1
{
    internal class Program
    {
        public static readonly double[] X = new[] { 1.22, 1.29, 1.55, 1.71, 1.9, 2.1 };
        public static readonly double[] Y = new[] { 3.04, 2.77, 2.44, 2.28, 2.14, 1.9 };

        public static readonly double Xz = 1.82;

        static void Main(string[] args)
        {
            Print();
        }
        static double LinearInterpolation()
        {
            double LinearInterpolationResult = 0;

            for (int i = 0; i < X.Length - 1; i++)
            {
                if (Xz > X[i] && Xz < X[i + 1])
                {
                    LinearInterpolationResult = (Xz - X[i + 1]) / (X[i] - X[i + 1]) * Y[i]
                                                + (Xz - X[i]) / (X[i + 1] - X[i]) * Y[i + 1];

                    break;
                }
            }

            return LinearInterpolationResult;
        }
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
        static double QuadraticInterpolation()
        {
            double QuadraticInterpolationResult = 0;

            for (int i = 0; i < X.Length; i++)
            {
                if (Xz > X[i] && Xz < X[i + 1])
                {
                    if (X.Length - 1 >= i + 2)
                    {
                        QuadraticInterpolationResult = Y[i] * ((Xz - X[i + 2]) * (Xz - X[i + 1])) / ((X[i] - X[i + 2]) * (X[i] - X[i + 1])) +
                                                       Y[i + 1] * ((Xz - X[i]) * (Xz - X[i + 2])) / ((X[i + 1] - X[i]) * (X[i + 1] - X[i + 2])) +
                                                       Y[i + 2] * ((Xz - X[i]) * (Xz - X[i + 1])) / ((X[i + 2] - X[i]) * (X[i + 2] - X[i + 1]));

                        break;
                    }
                    else if (X.Length - 1 == i + 1)
                    {
                        QuadraticInterpolationResult = Y[i - 1] * ((Xz - X[i + 1]) * (Xz - X[i])) / ((X[i - 1] - X[i + 1]) * (X[i - 1] - X[i])) +
                                                       Y[i] * ((Xz - X[i - 1]) * (Xz - X[i + 1])) / ((X[i] - X[i - 1]) * (X[i] - X[i + 1])) +
                                                       Y[i + 1] * ((Xz - X[i - 1]) * (Xz - X[i])) / ((X[i + 1] - X[i - 1]) * (X[i + 1] - X[i]));

                        break;
                    }
                }
            }

            return QuadraticInterpolationResult;
        }
        static void Print()
        {
            double tempLinearInterpolation = LinearInterpolation();

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
            Console.WriteLine($"Квадратичная интерполяция: {QuadraticInterpolation()}");
        }
    }
}
namespace PR1
{
    internal class Program
    {
        public static readonly double[] X = new[] { 1.22, 1.29, 1.55, 1.71, 2.03, 2.32 };
        public static readonly double[] Y = new[] { 3.04, 2.77, 2.44, 2.18, 2.14, 1.86 };

        public static readonly double Xz = 1.82;

        public static double LinearInterpolationResult;
        public static double LagrangeInterpolationResult;
        public static double QuadraticInterpolationResult;
        static void Main(string[] args)
        {
            QuadraticInterpolation();
            LinearInterpolation();
            LagrangeInterpolation();
            Print();
        }

        private static void LinearInterpolation()
        {
            for (int i = 0; i < X.Length - 1; i++)
            {
                if (Xz > X[i] && Xz < X[i + 1])
                {
                    LinearInterpolationResult = (Xz - X[i + 1]) / (X[i] - X[i + 1]) * Y[i] + (Xz - X[i]) / (X[i + 1] - X[i]) * Y[i + 1];
                }
            }
        }

        private static void LagrangeInterpolation()
        {
            LagrangeInterpolationResult = 0;

            for (int i = 0; i < X.Length; i++)
            {
                LagrangeInterpolationResult += Y[i] * l(i, X, Xz);
            }
        }

        public static void QuadraticInterpolation()
        {
            for (int i = 0; i < X.Length; i++)
            {
                if (Xz > X[i] && Xz < X[i + 1])
                {
                    if (X.Length - 1 >= i + 2)
                    {
                        QuadraticInterpolationResult =
                            Y[i] * ((Xz - X[i + 2]) * (Xz - X[i + 1])) / ((X[i] - X[i + 2]) * (X[i] - X[i + 1])) +
                            Y[i + 1] * ((Xz - X[i]) * (Xz - X[i + 2])) / ((X[i + 1] - X[i]) * (X[i + 1] - X[i + 2])) +
                            Y[i + 2] * ((Xz - X[i]) * (Xz - X[i + 1])) / ((X[i + 2] - X[i]) * (X[i + 2] - X[i + 1]));

                        break;
                    }
                    else if (X.Length - 1 == i + 1)
                    {
                        QuadraticInterpolationResult =
                            Y[i - 1] * ((Xz - X[i + 1]) * (Xz - X[i])) / ((X[i - 1] - X[i + 1]) * (X[i - 1] - X[i])) +
                            Y[i] * ((Xz - X[i - 1]) * (Xz - X[i + 1])) / ((X[i] - X[i - 1]) * (X[i] - X[i + 1])) +
                            Y[i + 1] * ((Xz - X[i - 1]) * (Xz - X[i])) / ((X[i + 1] - X[i - 1]) * (X[i + 1] - X[i]));

                        break;
                    }
                    //else if(X.Length == i)
                    //{
                    //    QuadraticInterpolationResult =
                    //        Y[i] * ((Xz - X[i + 2]) * (Xz - X[i + 1])) / ((X[i] - X[i + 2]) * (X[i] - X[i + 1])) +
                    //        Y[i + 1] * ((Xz - X[i]) * (Xz - X[i + 2])) / ((X[i + 1] - X[i]) * (X[i + 1] - X[i + 2])) +
                    //        Y[i + 2] * ((Xz - X[i]) * (Xz - X[i + 1])) / ((X[i + 2] - X[i]) * (X[i + 2] - X[i + 1]));
                    //}
                }
            }

        }

        private static double l(int index, double[] X, double x)
        {
            double l = 1;
            for (int i = 0; i < X.Length; i++)
            {
                if (i != index)
                {
                    l *= (x - X[i]) / (X[index] - X[i]);
                }
            }

            return l;
        }
        private static void Print()
        {
            Console.WriteLine("i  X    Y    Xz    Yz");

            for (int i = 0; i < X.Length && i < Y.Length; i++)
            {
                if (i is 0)
                {
                    if (Xz > X[i] && Xz < X[i + 1])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{i} {X[i]} {Y[i]} {Xz}  {Math.Round(LinearInterpolationResult, 5)}");
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
                        Console.WriteLine($"{i} {X[i]} {Y[i]}\t  {Math.Round(LinearInterpolationResult, 5)}");
                    }
                    else
                    {
                        Console.WriteLine(i + " " + X[i] + " " + Y[i]);
                        Console.ResetColor();
                    }
                }
            }
            Console.WriteLine("\t");
            Console.WriteLine("Линейная интерполяция: " + LinearInterpolationResult);
            Console.WriteLine("Интерполяция Лагранжа: " + LagrangeInterpolationResult);
            Console.WriteLine("Квадратичная интерполяция: " + QuadraticInterpolationResult);

        }
    }
}
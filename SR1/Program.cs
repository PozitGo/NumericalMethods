namespace SR1
{
    internal class Program
    {
        public static readonly double[] X = new[] { 0.6145, 0.6158, 0.6167, 0.6185, 0.62 };
        public static readonly double[] Y = new[] { 1.8272, 1.8242, 1.8221, 1.81791, 1.8145 };

        private static Dictionary<string, double> P = new();

        public static readonly double Xz = 0.6163;
        public static double Yz;

        static void Main(string[] args)
        {
            EulerMethodStep();
            Print();
        }

        private static void EulerMethodStep()
        {
            //Считаем все с шагом 2, 01,12,23,34
            for (int i = 0; i < Y.Length - 1 && i < X.Length - 1; i++)
            {
                double Sum = Y[i] * (X[i + 1] - Xz);
                Sum += (Y[i + 1] * (X[i] - Xz)) * -1;
                P.Add($"{i}{i + 1}", Sum / (X[i + 1] - X[i]));
            }

            //Считаем все с шагом 3, 012,123,234
            for (int i = 0; i < Y.Length - 2 && i < X.Length - 2; i++)
            {
                double Sum = P[$"{i}{i + 1}"] * (X[i + 2] - Xz);
                Sum += (P[$"{i + 1}{i + 2}"] * (X[i] - Xz)) * -1;
                P.Add($"{i}{i + 1}{i + 2}", Sum / (X[i + 2] - X[i]));
            }

            //Считаем с шагом 4, 0123, 1234
            for (int i = 0; i < Y.Length - 3 && i < X.Length - 3; i++)
            {
                double Sum = P[$"{i}{i + 1}{i + 2}"] * (X[i + 3] - Xz);
                Sum += (P[$"{i + 1}{i + 2}{i + 3}"] * (X[i] - Xz)) * -1;
                P.Add($"{i}{i + 1}{i + 2}{i + 3}", Sum / (X[i + 3] - X[i]));
            }

            //Считаем с шагом 5, 01234
            for (int i = 0; i < Y.Length - 4 && i < X.Length - 4; i++)
            {
                double Sum = P[$"{i}{i + 1}{i + 2}{i + 3}"] * (X[i + 4] - Xz);
                Sum += (P[$"{i + 1}{i + 2}{i + 3}{i + 4}"] * (X[i] - Xz)) * -1;
                P.Add($"{i}{i + 1}{i + 2}{i + 3}{i + 4}", Sum / (X[i + 4] - X[i]));
            }
        }

        private static void Print()
        {
            Console.Write($"X: ");
            for (int i = 0; i < X.Length; i++)
            {
                Console.Write(X[i] + " ");
            }

            Console.WriteLine();
            Console.Write($"Y: ");
            for (int i = 0; i < Y.Length; i++)
            {
                Console.Write(Y[i] + " ");
            }

            Console.WriteLine("\n");

            foreach (var item in P)
            {
                Console.WriteLine($"P{item.Key}: {item.Value}");
            }

            Console.WriteLine($"\nX*: {Xz}");


        }
    }
}

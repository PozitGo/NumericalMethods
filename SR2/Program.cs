namespace SR2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double s = 0;
            const int SizeSystem = 3;

            double[,] a = new double[SizeSystem, SizeSystem]
            {
                {4.56, 4.20, 3.78},
                {3.21, 2.73, 2.25},
                {4.58, 4.04, 3.52},
            };

            double[] b = new double[SizeSystem] { 61.86, 42.98, 61.67 };
            double[] x = new double[SizeSystem];

            Console.WriteLine($"Система размером {SizeSystem}x{SizeSystem}\n");
            for (int i = 0; i < SizeSystem; i++)
            {
                for (int j = 0; j < SizeSystem; j++)
                {
                    Console.Write($"{a[i, j]} ");
                }

                Console.Write($"= {b[i]}");
                Console.WriteLine();
            }

            for (int i = 0; i < SizeSystem; i++) x[i] = 0;

            for (int k = 0; k < SizeSystem - 1; k++)
            {
                for (int i = k + 1; i < SizeSystem; i++)
                {
                    for (int j = k + 1; j < SizeSystem; j++)
                    {
                        a[i, j] = a[i, j] - a[k, j] * (a[i, k] / a[k, k]);
                    }

                    b[i] = b[i] - b[k] * a[i, k] / a[k, k];
                }
            }

            for (int k = SizeSystem - 1; k >= 0; k--)
            {
                s = 0;
                for (int j = k + 1; j < SizeSystem; j++)
                {
                    s = s + a[k, j] * x[j];
                }
                x[k] = (b[k] - s) / a[k, k];
            }


            Console.WriteLine();
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine($"X{i + 1} => {x[i]}");
            }

        }
    }
}
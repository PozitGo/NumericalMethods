namespace PR3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double s = 0;
            const int SizeSystem = 4;

            double[,] a = new double[SizeSystem, SizeSystem]
            {
                {18.1, 1.81, -4.525, 5.43}, 
                {1.06, 5.3, 1.855, -0.53},
                {-4.2750, 1.425, 14.25, 5.7},
                {4.35, -5.22, 2.61, 17.4}
            };

            double[] b = new double[SizeSystem] {9.45, 3.308, -1.418, 12.29};
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
                    s = s + a[k, j] * x[j];
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
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
                {14.45, 1.445, -3.6125, 4.335}, 
                {1.07, 5.35, 1.8725, -0.535},
                {-5.13, 1.71, 17.1, 6.84},
                {2.0875, -2.5050, 1.2525, 8.35}
            };

            double[] b = new double[SizeSystem] {16.30, 5.705, -2.445, 21.19};
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
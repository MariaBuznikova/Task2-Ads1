using System;

namespace Объявленря1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            while (n <= 1)
            {
                Console.WriteLine("Введите количество элементов матрицы");
                n = Convert.ToInt32(Console.ReadLine());
            }
            int[,] Matrix = new int[n, n];
            FillMatrix(ref Matrix, n);
            Console.WriteLine();
            Vyvod(in Matrix, n);
            int Maximum, Minimum, Sum;
            MinMaxSumMatrix(in Matrix, n, out Maximum, out Minimum, out Sum);
            // Вывод информации о всей матрице

        }

        static void  FillMatrix(ref int[,] Matrix, int n)
        {
            for (int i =0; i < n; i++)
            {
                Console.WriteLine("Введите значения строки " + (i + 1).ToString() + ":");
                string buf = Console.ReadLine();
                string[] Split = buf.Split(" ");
                int k = 0;
                for (int j = 0; j < Split.Length; j++)
                {
                    if (Split[j].Length > 0)
                    {
                        if (k < n)
                        {
                            if (!Int32.TryParse(Split[j], out Matrix[i, k]))
                                Matrix[i, k] = 0;
                            k++;
                        }
                        else
                        {
                            Console.WriteLine("Слишком много элементов для записи в строку " + (i + 1).ToString() + ", записаны первые " + n.ToString());
                            break;
                        }
                    }
                    else
                        continue;
                }
                if (k <= n - 1)
                    Console.WriteLine("Слишком мало элементов для записи в строку " + (i + 1).ToString() + ", записаны " + k.ToString());
            }
        }
        
        static void Vyvod(in int[,] Matrix, int n)
        {
            for (int i=0; i<n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    Console.Write(Matrix[i, j].ToString() + " ");
                }
                Console.WriteLine();
            }
        }

        static void MinMaxSumMatrix(in int[,] Matrix, int n, out int Max, out int Min, out int Sum)
        {
            Max = 0;
            Min = 0;
            Sum = 0;
            for (int i=0; i<n; i++)
            {
                Max = 0;
                Min = 0;
                Sum = 0;
                
                for (int j=0; j<n; j++)
                {
                    if (Max < Matrix[i, j])
                        Max = Matrix[i, j];
                    Min = Matrix[i, 0];
                    if (Min >= Matrix[i, j])
                        Min = Matrix[i, j];
                    Sum += Matrix[i, j];
                }
                Console.WriteLine();
                Console.WriteLine($"Максимум {i + 1} строки: {Max}");
                Console.WriteLine($"Минимум {i + 1} строки: {Min}");
                Console.WriteLine($"Сумма элементов {i + 1} строки: {Sum}");
            }

        }
    }
}

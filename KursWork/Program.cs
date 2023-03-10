using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array = {
            { 1, 1, 1, 2, 3 },
            { 4, 4, 1, 2, 3 },
            { 4, 4, 4, 2, 2 },
            { 4, 4, 4, 4, 4 }
        };
            int n = 4, m = 5;

            int count = 0;
            bool[,] visited = new bool[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (!visited[i, j])
                    {
                        count += CountRectangles(array, visited, i, j, n, m);
                    }
                }
            }
            Console.WriteLine("Кількість прямокутників: " + count);
        }

        static int CountRectangles(int[,] array, bool[,] visited, int i, int j, int n, int m)
        {
            int count = 0;
            int value = array[i, j];
            int k = 1, l = 1;
            visited[i, j] = true;

            
            while (j + l < m && array[i, j + l] == value)
            {
                l++;
            }

            while (i + k < n && array[i + k, j] == value)
            {
                bool isValidRectangle = true;
                for (int p = 1; p < l; p++)
                {
                    if (array[i + k, j + p] != value)
                    {
                        isValidRectangle = false;
                        break;
                    }
                }
                if (isValidRectangle)
                {
                    k++;
                }
                else
                {
                    break;
                }
            }

            if (k > 1 && l > 1)
            {
                count = 1;
                
                for (int p = 0; p < k; p++)
                {
                    for (int q = 0; q < l; q++)
                    {
                        visited[i + p, j + q] = true;
                    }
                }
            }

            for (int p = 0; p < k; p++)
            {
                for (int q = 0; q < l; q++)
                {
                    if (!visited[i + p, j + q])
                    {
                        count += CountRectangles(array, visited, i + p, j + q, n, m);
                    }
                }
            }

            return count;
        }
    }
}

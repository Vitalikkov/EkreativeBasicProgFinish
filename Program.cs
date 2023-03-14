using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWork2
{
    internal class Program
    {
        static void PrintArr(int[,] arr)
        {
            Console.WriteLine("Ось наш масив:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]} ");

                }
                Console.WriteLine();
            }
        }

        static int[,] InputArr(int n, int m)
        {
            int[,] arr = new int[n, m];
            Console.WriteLine("Введiть елементи масиву:");
            for (int i = 0; i < n; i++)
            {
                string[] strN = Console.ReadLine().Trim().Split();
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = Convert.ToInt32(strN[j]);
                }
            }
            return arr;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введiть кiлькiсть рядкiв i стовпцiв масиву:");
            string[] str = Console.ReadLine().Trim().Split();
            int n = int.Parse(str[0]);
            int m = int.Parse(str[1]);

            int[,] arr = InputArr(n, m);

            PrintArr(arr);

           /* int[,] arr = {
            { 2, 2, 2, 1, 1 },
            { 1, 2, 2, 3, 1 },
            { 3, 2, 2, 3, 1 },
            { 4, 4, 2, 7, 1 }
            };

            int n = 4, m = 5;*/
           
            int count = 0;
            bool[,] visited = new bool[n, m];
            
            

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (!visited[i, j])
                    {
                        int value = arr[i, j];
                        int k = 1, l = 1;
                        visited[i, j] = true;
                        int[,] first = new int[n, m];
                        while (j + l < m && arr[i, j + l] == value)
                        {
                            l++;
                        }

                        while (i + k < n && arr[i + k, j] == value)
                        {
                            bool isValidRectangle = true;
                            for (int p = 1; p < l; p++)
                            {
                                if (arr[i + k, j + p] != value)
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
                        /* if ((k >= 1 && l > 1) || (k > 1 && l >= 1))*/
                        if (k > 1 && l > 1)
                        {
                            count++;
                            Console.WriteLine($"Прямокутник №{count}");
                            for (int p = 0; p < k; p++)
                            {
                                for (int q = 0; q < l; q++)
                                {
                                    visited[i + p, j + q] = true;
                                    first[i +p, j+q] = arr[i + p, j + q];
                                    Console.Write($"{first[i + p, j + q]} ");
                                    
                                }
                                Console.WriteLine();
                            }
                            for (int p = 0; p < k; p++)
                            {
                                for (int q = 0; q < l; q++)
                                {
                                    
                                    Console.Write($"{i + p},{j + q} ");
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                        } 
                    }
                    

                    
                }
            }
            Console.WriteLine("Кiлькiсть прямокутнiкiв: " + count);


        }
    }
}

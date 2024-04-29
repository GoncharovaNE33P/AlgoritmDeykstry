using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmDeykstry
{
    internal class MDeyk
    {        
        public void Deyk(int[,] graph)
        {
            Console.Write("\nВведите начальную точку: ");
            int start = int.Parse(Console.ReadLine());
            int countIterations = graph.GetLength(0);
            int[] distences = new int[countIterations];
            bool[] topVisit = new bool[countIterations];
            for (int i = 0; i < countIterations; i++)
            {
                distences[i] = int.MaxValue;
            }
            distences[start] = 0;

            for (int i = 0; i < countIterations - 1; i++)
            {
                int minDis = int.MaxValue;
                int minInd = 0;
                for (int j = 0; j < countIterations; j++)
                {
                    if (!topVisit[j] && distences[j] < minDis)
                    {
                        minDis = distences[j];
                        minInd = j;
                    }
                }
                topVisit[minInd] = true;
                for (int j = 0; j < countIterations; j++)
                {
                    if (!topVisit[j] && graph[minInd,j] != 0 && distences[minInd] != int.MaxValue && distences[minInd] + graph[minInd,j] < distences[j])
                    {
                        distences[j] = distences[minInd] + graph[minInd, j];
                    }
                }
            }
            Console.WriteLine();
            for (int i = 0; i < distences.Length; i++)
            {
                Console.WriteLine($"{start} -> {i}: {distences[i]}");
            }
        }
    }
}

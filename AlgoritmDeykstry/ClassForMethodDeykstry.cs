using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmDeykstry
{
    internal class ClassForMethodDeykstry
    {
        public class InvalidInputException : Exception
        {
            public InvalidInputException(string message) : base(message) { }
        }

        public class OutOfBoundsException : Exception
        {
            public OutOfBoundsException(string message) : base(message) { }
        }
        public void MethodDeykstry(int[,] graph)
        {
            try
            {
                int start = ReadStartPoint();
                int nodeCount = graph.GetLength(0);
                int[] distances = InitializeDistances(nodeCount, start);
                bool[] visitedNodes = new bool[nodeCount];

                for (int i = 0; i < nodeCount - 1; i++)
                {
                    int minIndex = GetMinDistanceIndex(distances, visitedNodes);
                    visitedNodes[minIndex] = true;
                    UpdateDistances(graph, distances, visitedNodes, minIndex);
                }

                PrintDistances(start, distances);
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}");
            }
            catch (OutOfBoundsException ex)
            {
                Console.WriteLine($"Ошибка диапазона: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
            }
        }
        private int ReadStartPoint()
        {
            Console.Write("\nВведите начальную точку: ");
            if (!int.TryParse(Console.ReadLine(), out int result))
            {
                throw new InvalidInputException("Некорректный ввод числа.");
            }
            return result;
        }
       
        private int[] InitializeDistances(int size, int start)
        {
            if (start < 0 || start >= size)
            {
                throw new OutOfBoundsException("Начальная точка выходит за пределы массива.");
            }
            int[] distances = new int[size];
            for (int i = 0; i < size; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[start] = 0;

            return distances;
        }

        private void PrintDistances(int start, int[] distances)
        {
            Console.WriteLine();
            for (int i = 0; i < distances.Length; i++)
            {
                Console.WriteLine($"{start} -> {i}: {distances[i]}");
            }
        }

        private int GetMinDistanceIndex(int[] distances, bool[] visitedNodes)
        {
            int minDistance = int.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < distances.Length; i++)
            {
                if (!visitedNodes[i] && distances[i] < minDistance)
                {
                    minDistance = distances[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public void UpdateDistances(int[,] graph, int[] distances, bool[] visitedNodes, int currentNode)
        {
            for (int j = 0; j < distances.Length; j++)
            {
                if (!visitedNodes[j] && graph[currentNode, j] != 0 && distances[currentNode] != int.MaxValue && distances[currentNode] + graph[currentNode, j] < distances[j])
                {
                    distances[j] = distances[currentNode] + graph[currentNode, j];
                }
            }
        }
    }
}

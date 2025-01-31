using System.IO;
using static AlgoritmDeykstry.ClassForMethodDeykstry;

namespace AlgoritmDeykstry
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }

    public class FileReadException : Exception
    {
        public FileReadException(string message) : base(message) { }
        public FileReadException(string message, Exception inner) : base(message, inner) { }
    }

    internal class Program
    {        
        private static void Main(string[] args)
        {
            try
            {
                ClassForMethodDeykstry algorithm = new ClassForMethodDeykstry();

                int destinations = ReadInteger("Введите количество пунктов назначения: ");
                int departures = ReadInteger("Введите количество пунктов отправления: ");

                int[,] graph = new int[destinations, departures];
                int[] destinationPoints = InitializeArray(destinations);
                int[] departurePoints = InitializeArray(departures);

                ReadGraphFromFile("Deyk.csv", graph);

                PrintGraph(graph, destinationPoints, departurePoints);

                algorithm.MethodDeykstry(graph);
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}");
            }
            catch (FileReadException ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
            }

        }

        private static int ReadInteger(string message)
        {
            Console.Write(message);
            if (!int.TryParse(Console.ReadLine(), out int result))
            {
                throw new InvalidInputException("Некорректный ввод числа.");
            }
            return result;
        }

        private static int[] InitializeArray(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = i;
            }
            return array;
        }

        private static void ReadGraphFromFile(string filePath, int[,] graph)
        {
            try
            {
                using StreamReader reader = new StreamReader(filePath);
                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    string? line = reader.ReadLine();
                    if (line == null)
                    {
                        throw new FileReadException("Неожиданный конец файла.");
                    }

                    string[] values = line.Split(';');
                    if (values.Length != graph.GetLength(1))
                    {
                        throw new FileReadException("Некорректное количество значений в строке.");
                    }

                    for (int j = 0; j < graph.GetLength(1); j++)
                    {
                        if (!int.TryParse(values[j], out graph[i, j]))
                        {
                            throw new FileReadException($"Ошибка преобразования данных в строке {i + 1} столбце {j + 1}.");
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                throw new FileReadException("Ошибка доступа к файлу.", ex);
            }
        }

        private static void PrintGraph(int[,] graph, int[] destinationPoints, int[] departurePoints)
        {
            Console.WriteLine("\nМатрица с исходными данными\n");

            Console.Write("\t");
            foreach (int point in destinationPoints)
            {
                Console.Write(point + "\t");
            }
            Console.WriteLine();

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                Console.Write(departurePoints[i] + "\t");
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    Console.Write(graph[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
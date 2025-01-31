namespace AlgoritmDeykstry
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ClassForMethodDeykstry algorithm = new ClassForMethodDeykstry();
            Console.Write("Введите количество пунктов назначения: ");
            int destin = int.Parse(Console.ReadLine());
            Console.Write("Введите количество пунктов отправления: ");
            int depar = int.Parse(Console.ReadLine());            
            int[,] graph = new int[destin, depar];
            int[] Pdestin = new int[destin];
            int[] Pdepar = new int[depar];
            for (int i = 0; i < Pdestin.Length; i++)
            {
                Pdestin[i] = i;
            }
            for (int j = 0; j < Pdepar.Length; j++)
            {
                Pdepar[j] = j;
            }
            using (StreamReader read = new StreamReader("Deyk.csv"))
            {
                while (!read.EndOfStream)
                {
                    for (int i = 0; i < destin; i++)
                    {
                        string line = read.ReadLine();
                        string[] str = line.Split(';');
                        for (int j = 0; j < depar; j++)
                        {
                            graph[i, j] = int.Parse(str[j]);
                        }
                    }
                }
            }            
            Console.WriteLine("\nМатрица с исходными данными\n");
            for (int i = 0; i < 1; i++)
            {                
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    Console.Write("\t");
                    Console.Write(Pdestin[j]);                    
                }
                Console.WriteLine();
            }
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                Console.Write(Pdepar[i] + "\t");
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    Console.Write(graph[i, j] + "\t");                    
                }
                Console.WriteLine();
            }
            algorithm.MethodDeykstry(graph);
        }
    }
}
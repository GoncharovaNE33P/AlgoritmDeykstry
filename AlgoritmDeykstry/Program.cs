namespace AlgoritmDeykstry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MDeyk mD = new MDeyk();
            //Console.Write("Введите количество пунктов назначения: ");
            int destin = 6/*int.Parse(Console.ReadLine())*/;
            //Console.Write("Введите количество пунктов отправления: ");
            int depar = 6/*int.Parse(Console.ReadLine())*/;            
            int[,] distance = new int[destin, depar];
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
                            distance[i, j] = int.Parse(str[j]);
                        }
                    }
                }
            }
            Console.WriteLine("\nМатрица с исходными данными\n");            
            for (int i = 0; i < distance.GetLength(0); i++)
            {                
                for (int j = 0; j < distance.GetLength(1); j++)
                {                    
                    Console.Write(distance[i, j] + "\t");                    
                }
                Console.WriteLine();
            }
            mD.Deyk(distance, Pdestin, Pdepar);
        }
    }
}
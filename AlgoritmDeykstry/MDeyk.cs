using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmDeykstry
{
    internal class MDeyk
    {
        public void Deyk(int[,] distance, int[] Pdestin, int[] Pdepar)
        {
            //Console.Write("Введите начальная точка: ");
            int start = 1;/*int.Parse(Console.ReadLine());*/
            int[] ves = new int[Pdepar.Length];

            for (int i = 0; i < ves.Length;)
            {
                for (int disI = 0; disI < distance.GetLength(0); disI++)
                {                    
                    for (int disJ = 0; disJ < distance.GetLength(1);)
                    {   
                        if (distance[disI, disJ] != 0) 
                        {
                            if (i == start)
                            {
                                i++;
                                ves[Pdestin[i]] = distance[disI, disJ];
                                continue;
                            }
                        }  
                    }
                }
            }
            for (int j = 0; j < ves.GetLength(1); j++)
            {
                Console.Write(ves[j] + "\t");
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_486_AnonMeth3
{
    delegate int CountIt(int end);
    class Program
    {
        static void Main(string[] args)
        {
            int result;
            CountIt count = delegate (int end)
            {
                int sum = 0;
                for (int i = 0; i <= end; i++)
                {
                    Console.WriteLine(i);
                    sum += i;
                }
                return sum;
            };
            result = count(3);
            Console.WriteLine("Сумма 3 равна " + result);
            Console.WriteLine();
            result = count(5);
            Console.WriteLine("Сумма 5 равна " + result);
            Console.WriteLine();
        }
    }
}

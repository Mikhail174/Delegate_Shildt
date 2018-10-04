using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_484_AnonMeth
{
    delegate void CountIt();

    class AnonMethDemo
    {
        static void Main(string[] args)
        {
            // далее следует код для подсчета чисел,передаваемый делегату в кач-ве анонимного метода
            CountIt count = delegate
            {
                //этот кодовый блок передается делегату
                for (int i = 0; i <= 5; i++)
                    Console.WriteLine(i);
            };
            count();
        }
    }
}

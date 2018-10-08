using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_487_VarCapture
{
    delegate int CountIt(int end); //этот делегат возвращает значение типа int и принимает аргумент типа int
    class VarCapture
    {
        CountIt Counter()
        {
            int sum=0;
            //здесь подсчитанная сумма сохраняется в переменной sum

            CountIt ctObj = delegate (int end)
           {
               for (int i = 0; i <= end; i++)
               {
                   Console.WriteLine(i);
                   sum += i;
               }
               return sum;
           };
            return ctObj;
        }

        static void Main(string[] args)
        {
            //получить результат подсчёта

            VarCapture varCapture = new VarCapture();
            CountIt count = varCapture.Counter();
            int result;
            result = count(3);
            Console.WriteLine("Сумма 3 равна " + result);
            Console.WriteLine();
            result = count(5);
            Console.WriteLine("Сумма 5 равна " + result);
        }
    }
}

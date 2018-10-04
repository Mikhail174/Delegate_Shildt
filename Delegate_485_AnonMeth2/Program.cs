using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_485_AnonMeth2
{
    delegate void CountIt(int end);

    class AnonMethDemo2
    {
        static void Main(string[] args)
        {
            CountIt count = delegate (int end)
            {
                //этот кодовый блок передается делегату
                for (int i = 0; i <= end; i++)
                    Console.WriteLine(i);
            };
            count(3);
            Console.WriteLine();
            count(5);
        }
    }
}

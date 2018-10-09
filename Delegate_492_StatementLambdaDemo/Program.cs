using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//продемонстрировать применение блочного лямбда выражения
namespace Delegate_492_StatementLambdaDemo
{
    delegate int IntOp(int end);
    class StatementLambdaDemo
    {
        static void Main(string[] args)
        {
            //блочное лямбда-выражение возвращает факториал передаваемого ему значения
            IntOp fact = n =>
            {
                int r = 1;
                for (int i = 1; i <= n; i++)
                    r = i * r;
                return r;
            };
            Console.WriteLine("Факториал 3 равен " + fact(3));
            Console.WriteLine("Факториал 5 равен " + fact(5));

        }

    }
}

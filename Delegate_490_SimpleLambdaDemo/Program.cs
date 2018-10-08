using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*параметр => выражение
 (список_параметров) => выражение 
 count => count+2; count это параметр, count+2 это выражение, в итоге значение параметра count увелич. на 2
 n => n%2 == 0; выражение возвращает true если числовое значение параметра n оказывается четным, иначе false

 Лямбда выражение применяется в два этапа. Сначала объявляется тип делегата, совместимый с лямбда-выражением,
 а затем экземпляр делегата,которому присваивается лямбда-выражение. После этого лямбда выражение вычисляется
 при обращении к экземпляру делегата. Результатом его вычилсения становится возвращаемое значение*/

//применить два одиночных лямбда-выражения

namespace Delegate_490_SimpleLambdaDemo
{ //объявить делегат, принимающий аргумент типа int и возвращающий результат типа int
    delegate int Incr(int v);
    //объявить делегат, принимающий аргумент типа int и возвращающий результат типа bool
    delegate bool IsEven(int v);
    //объявить делегат, принимающий три аргумента типа int и возвращающий результат типа bool
    delegate bool InRange(int lower, int upper, int v);

    class SimpleLambdaDemo
    {
        static void Main(string[] args)
        {
            //создать делегат Incr,ссылающийся на лямбда-выражение,увеличивающее свой параметр на 2
            Incr incr = count => count + 2;
            //Incr incr = (int count) => count + 2; альтернативный способ объявления делегата
            //использование лямбда-выражение incr
            Console.WriteLine("Использование лямбда-выражения incr: ");
            int x = -10;
            while (x <= 0)
            {
                Console.Write(x + " ");
                x = incr(x); //увеличить значение x на 2
            }
            Console.WriteLine();
            //создать экземпляр делегата IsEven,ссылающийся на лямбда-выражение,возвращающее результат типа bool
            IsEven isEven = n => n % 2 == 0;
            //использование лямбда-выражение isEven
            Console.WriteLine("Использование лямбда-выражения isEven: ");
            for (int i = 1; i <= 10; i++)
            {
                if (isEven(i)) Console.WriteLine(i + " чётное"); 
            }
            //создать экземпляр делегата InRange,ссылающийся на лямбда-выражение,возвращающее результат типа bool
            InRange rangeOK = (low, high, val) => val >= low && val <= high;
            //использование лямбда-выражение rangeOK
            if (rangeOK(1, 5, 3)) Console.WriteLine("Число 3 находится в пределах от 1 до 5");

        }
    }
}

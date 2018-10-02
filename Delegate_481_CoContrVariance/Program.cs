using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_481_CoContrVariance
{
    class X
    {
        public int val;
    }
    class Y:X { }

    delegate X ChangeIt(Y obj); //этот делегат возвращает объект класса X и принимает Y в качестве аргумента

    class CoContrVariance
    {
        static X IncrA (X obj) //этот метод возвращает объект класса X и имеет объект класса X в качесвте параметра
        {
            X temp = new X();
            temp.val = obj.val + 1;
            return temp;
        }
        static Y IncrB (Y obj) //этот метод возвращает объект класса Y и имеет объект класса Y в качестве параметра
        {
            Y temp = new Y ();
            temp.val = obj.val + 1;
            return temp;
        }
        static void Main(string[] args)
        {
            Y Yob = new Y();
            /* в данном случае параметром метода IncrA является объект класса X, а параметром делегата ChangeIt - объект класса Y. Но благодаря контравариантности 
             * следующая строка кода вполне допустима*/
            ChangeIt change = IncrA;
            X Xob = change(Yob);
            Console.WriteLine("Xob: " + Xob.val);

            /* В этом случае вовзращаемым типом метода IncrB служит объект класса Y, а возвращаемым типом делегата ChangeIt - объект класса X. Но благодаря ковариантности
             * следующая строка кода оказывается вполне допустимой*/
            change = IncrB;
            Yob= (Y)change(Yob);  
            Console.WriteLine("Yob: " + Yob.val);

            /* приведение типов на 43 строке нужно для того, чтобы соответствовать сигнатуре делегата */
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_479
{
    delegate void StrMod(ref string str);
    class MulticastDemo {

        static void ReplaceSpaces(ref string s)
        {
            Console.WriteLine("Замена пробелов дефисами");
            s= s.Replace(' ', '-');
        }
        static void RemoveSpaces(ref string s)
        {
            string temp = "";
            int i;
            Console.WriteLine("Удаление пробелов");
            for (i = 0; i < s.Length; i++)
                if (s[i] != ' ')
                    temp += s[i];
            s= temp;
        }
        static void Reverse(ref string s)
        {
            string temp = "";
            int i;
            Console.WriteLine("Обращение строки");
            for (i = s.Length - 1; i >= 0; i--)
                temp += s[i];
            s= temp;
        }
        static void Main(string[] args)
        {
            //Сконструировать делегаты
            StrMod strOp;
            StrMod replaceSp = ReplaceSpaces;
            StrMod removeSp = RemoveSpaces;
            StrMod reverseStr = Reverse;
            string str = "Это простой тест";

            //организовать групповую переадресацию
            strOp = replaceSp;
            strOp += reverseStr;
            

            //Обратиться к делегату с групповой адресацией
            strOp(ref str);
            Console.WriteLine("Результирующая строка: " + str);
            Console.WriteLine();

            //Удалить метод замены пробелов и добавить метод удаления пробелов
            strOp -= replaceSp;
            strOp += removeSp;
            str = "Это простой тест"; //восстановить исходную строку

            //Обратиться к делегату с групповой адресацией
            strOp(ref str);
            Console.WriteLine("Результирующая строка: " + str);
            Console.WriteLine(); 

        }
    }

}
             /*В данном примере рассматривается принцип вызова цепочки методов делегата. на 51-ой строке вызывается делегат с методами на 46,47 строке.
              на 61-ой строке вызывается делегат с методами на 46,47 и 56,57 строке. При этом между 46,47 и 56,57 подается на вход исходная строка 
              "Это простой тест", потому что если этого не сделать, то на вход подается строка "тсет-йотсорп-отЭ", в которой ни разу не выполнится
              метод замены пробелов на дефисы, поэтому на 56 строке дефисы не откатятся*/
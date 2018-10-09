using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//пример Delegate_477 переделанный, с использованием блочных лямбда-выражений
namespace Delegate_493_UseStatementLambdas { 
delegate string StrMod(string s);
    class Program
    {
        static void Main(string[] args)
        {
            //создать делегаты, ссылающиеся на лямбда выражения, выполняющие различные операции с символьными строками

            //заменить пробелы дефисами
            StrMod ReplaceSpaces = s =>
            {
                Console.WriteLine("Замена пробелов дефисами");
                return s.Replace(' ', '-');
            };

            //удалить пробелы
            StrMod RemoveSpaces = s =>
            {
                string temp = "";
                int i;
                Console.WriteLine("Удаление пробелов");
                for (i = 0; i < s.Length; i++)
                    if (s[i] != ' ')
                        temp += s[i];
                return temp;
            };

            //обратить строку
            StrMod Reverse = s => {
                string temp = "";
                int i;
                Console.WriteLine("Обращение строки");
                for (i = s.Length - 1; i >= 0; i--)
                    temp += s[i];
                return temp;
            };

            string str;

            //обратиться к лямбда-выражениям с помощью делегатов
            StrMod strOp = ReplaceSpaces;
            str = strOp("Это простой тест");
            Console.WriteLine("Результирующая строка: " + str);
            Console.WriteLine();

            strOp = RemoveSpaces;
            str = strOp("Это простой тест");
            Console.WriteLine("Результирующая строка: " + str);
            Console.WriteLine();

            strOp = Reverse;
            str = strOp("Это простой тест");
            Console.WriteLine("Результирующая строка: " + str);
            Console.WriteLine();

        }
    }
}

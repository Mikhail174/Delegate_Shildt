using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_477
{
    delegate string StrMod(string str);

    class StringOps
    {
        //Заменить пробелы дефисами
        public string ReplaceSpaces(string s)
        {
            Console.WriteLine("Замена пробелов дефисами");
            return s.Replace(' ', '-');
        }
        //удалить пробелы
        public string RemoveSpaces(string s)
        {
            string temp = "";
            int i;
            Console.WriteLine("Удаление пробелов");
            for (i = 0; i < s.Length; i++)
                if (s[i] != ' ')
                    temp += s[i];
            return temp;
        }
        //обратить строку
        public string Reverse(string s)
        {
            string temp = "";
            int i;
            Console.WriteLine("Обращение строки");
            for (i = s.Length - 1; i >= 0; i--)
                temp += s[i];
            return temp;
        }
    }

    class DelegateTest
    {
        static void Main(string[] args)
        {
            StringOps so = new StringOps(); //создаём экземпляр
            StrMod strOp = so.ReplaceSpaces; // инициализируем делегат
            String str = strOp("Это простой тест"); //вызываем методы с помощью делегата
            Console.WriteLine("Результирующая строка: " + str);
            Console.WriteLine();

            strOp = so.RemoveSpaces;
            str = strOp("Это простой тест");
            Console.WriteLine("Результирующая строка: " + str);
            Console.WriteLine();

            strOp = so.Reverse;
            str = strOp("Это простой тест");
            Console.WriteLine("Результирующая строка: " + str);
            Console.WriteLine();
        }
    }
}

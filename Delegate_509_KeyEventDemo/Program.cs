using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//пример обработки событий,связанных с нажатием клавиш на клавиатуре
namespace Delegate_509_KeyEventDemo
{//создать класс, производный от класса EventArgs и хранящий символ нажатой клавиши
    class KeyEventArgs : EventArgs
    {
        public char ch;
    }
    //объявить класс события,связанного с нажатием клавиш на клавиатуре
    class KeyEvent
    {
        public event EventHandler<KeyEventArgs> KeyPress; //обобщенный делегат
        //этот метод вызывается при нажатии клавиши
        public void OnKeyPress (char key)
        {
            KeyEventArgs k = new KeyEventArgs();
            if (KeyPress != null)
            {
                k.ch = key;
                KeyPress(this, k);
            }
        }
    }
    //продемонстрировать обработку события типа KeyEvent
    class KeyEventDemo
    {
        static void Main(string[] args)
        {
            KeyEvent kevt = new KeyEvent();
            ConsoleKeyInfo key;
            int count = 0;

            // использовать лямбда-выражение для отображения факта нажатия клавиши
            kevt.KeyPress += (sender, e) => Console.WriteLine("Получено сообщение о нажатии клавиши: " + e.ch);

            //использовать лямбда-выражение для подсчёта нажатых клавиш
            kevt.KeyPress += (sender, e) => count++; //count - внешнаяя переменная

            Console.WriteLine("ВВедите несколько символов, по завершении введите точку");
            do
            {
                key = Console.ReadKey();
                kevt.OnKeyPress(key.KeyChar);
            } while (key.KeyChar != '.');
            Console.WriteLine("Было нажато " + count + " клавиш");
        }
    }
}

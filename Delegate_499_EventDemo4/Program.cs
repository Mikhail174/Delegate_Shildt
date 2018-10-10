using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*уведомление о событи получает класс, когда статический метод используется в качестве обработчика событий*/
namespace Delegate_499_EventDemo4
{
    delegate void MyEventHandler();
    class MyEvent
    {
        public event MyEventHandler SomeEvent;//тип делегата события определяет возвращаемый тип и сигнатуру для события
        //этот метод вызывается для запуска события
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent();
        }
    }
    class X
    {
        //этот статический метод предназначен в качестве обработчика событий
        public static void Xhandler()
        {
            Console.WriteLine("Событие получено классом");
        }
    }
    class EventDemo4
    {
        static void Main(string[] args)
        {
            MyEvent evt = new MyEvent();
            evt.SomeEvent += X.Xhandler;
            //запустить событие
            evt.OnSomeEvent();
        }
    }
}

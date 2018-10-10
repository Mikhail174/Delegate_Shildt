using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Уведомления о событиях получают отдельные объекты, когда метод экземпляра используется в качестве обработчика событий*/
namespace Delegate_498_EventDemo3
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
        int id;
        public X(int x) { id = x;  }
        //этот метод предназначен в качестве обработчика событий
        public void Xhandler()
        {
            Console.WriteLine("Событие получено объектом "+id);
        }
    }
    class EventDemo3
    {
        static void Main(string[] args)
        {
            MyEvent evt = new MyEvent();
            X o1 = new X(1);
            X o2 = new X(2);
            X o3 = new X(3);
            evt.SomeEvent += o1.Xhandler;
            evt.SomeEvent += o2.Xhandler;
            evt.SomeEvent += o3.Xhandler;
            //запустить событие
            evt.OnSomeEvent();
        }
    }
}

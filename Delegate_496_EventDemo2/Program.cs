using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//продемонстрировать групповую адресацию события
namespace Delegate_496_EventDemo2
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
        public void Xhandler()
        {
            Console.WriteLine("Событие получено объектом класса Х ");
        }
    }
    class Y
    {
        public void Yhandler()
        {
            Console.WriteLine("Событие получено объектом класса Y ");
        }
    }
    class Eventdemo2
    {
        static void Handler()
        {
            Console.WriteLine("Событие получено объектом класса EventDemo");
        }
        static void Main(string[] args)
        {
            MyEvent evt = new MyEvent();
            X xOb = new X();
            Y yOb = new Y();

            //добавить обработчики в списки событий
            evt.SomeEvent += Handler;
            evt.SomeEvent += xOb.Xhandler;
            evt.SomeEvent += yOb.Yhandler;

            //запустить событие
            evt.OnSomeEvent();

            Console.WriteLine();

            //удалить обработчик
            evt.SomeEvent -= xOb.Xhandler;
            evt.OnSomeEvent();
        }
    }
}

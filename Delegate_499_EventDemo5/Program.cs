using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//создать специальные средства для управления списками вызова обработчиков событий
namespace Delegate_499_EventDemo5
{
    delegate void MyEventHandler();
    //объявить класс для хранения максимум трех событий
    class MyEvent
    {
        MyEventHandler[] evnt = new MyEventHandler[3];
        public event MyEventHandler SomeEvent 
        {
                //добавить событие в список
                add
            {
                    int i;
                    for (i = 0; i < 3; i++)
                        if (evnt[i] == null)
                        {
                            evnt[i] = value;
                            break;
                        }
                if (i == 3) Console.WriteLine("Список событий заполнен");
            }
            //удалить событие из списка
            remove
            {
                int i;
                for (i = 0; i < 3; i++)
                {
                    if (evnt[i] == value)
                    {
                        evnt[i] = null;
                        break;
                    }
                    
                }
                if (i == 3) Console.WriteLine("Обработчик событий не найден");
            }
            
        }
        public void OnSomeEvent()
        {
            for (int i = 0; i < 3; i++)
            {
                if (evnt[i] != null) evnt[i]();
            }
        }

    }
    //создать ряд классов, использующих делегат MyEventHandler
    class W
    {
        public void Whandler()
        {
            Console.WriteLine("Событие получено объектом W");
        }
    }
    class X
    {
        public void Xhandler()
        {
            Console.WriteLine("Событие получено объектом X");
        }
    }
    class Y
    {
        public void Yhandler()
        {
            Console.WriteLine("Событие получено объектом Y");
        }
    }
    class Z
    {
        public void Zhandler()
        {
            Console.WriteLine("Событие получено объектом Z");
        }
    }
    class EventDemo5
    {
        static void Main(string[] args)
        {
            MyEvent evt = new MyEvent();
            W wOb = new W();
            X xOb = new X();
            Y yOb = new Y();
            Z zOb = new Z();
            //добавить обработчики в цепочку событий
            Console.WriteLine("Добавление событий");
            evt.SomeEvent += wOb.Whandler;
            evt.SomeEvent += xOb.Xhandler;
            evt.SomeEvent += yOb.Yhandler;
            //сохранить нельзя - список заполнен
            evt.SomeEvent += zOb.Zhandler;
            Console.WriteLine();

            //запустить события
            evt.OnSomeEvent();
            Console.WriteLine();

            //удалить обработчик
            Console.WriteLine("Удаление обработчика xOb.Xhandler");
            evt.SomeEvent-= xOb.Xhandler;
            evt.OnSomeEvent();
            Console.WriteLine();

            //попробовать удалить обработчик ещё раз
            Console.WriteLine("Попытка удалить обработчик xOb.Xhandler ещё раз");
            evt.SomeEvent -= xOb.Xhandler;
            evt.OnSomeEvent();
            Console.WriteLine();

            //а теперь добавить обработчик Zhandler
            Console.WriteLine("Добавление обработчика zOb.Zhandler");
            evt.SomeEvent += zOb.Zhandler;
            evt.OnSomeEvent();
        }
    }
}

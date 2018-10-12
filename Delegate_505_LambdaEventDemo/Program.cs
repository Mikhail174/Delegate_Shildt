using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//использовать лямбда-выражение в качестве обработчика событий

namespace Delegate_505_LambdaEventDemo
{//объявить тип делегата для события
    delegate void MyEventHandler(int n);

    //объявить класс, содержащий событие
    class MyEvent
    {
        public event MyEventHandler SomeEvent;
        //этот метод вызывается для запуска события
        public void OneSomeEvent(int n)
        {
            if (SomeEvent != null)
                SomeEvent(n);
        }
    }

    class LambdaEventDemo
    {
        static void Main(string[] args)
        {
            MyEvent evt = new MyEvent();
            //использовать лямбда-выражение в качестве обработчика событий
            evt.SomeEvent += (n) => Console.WriteLine("Событие получено. Обработчик: лямбда-выражение. Значение равно " + n);
            //запустить событие
            evt.OneSomeEvent(1);
            evt.OneSomeEvent(2);

            //использовать анонимный метод в качестве обработчика событий
            evt.SomeEvent += delegate (int n)
              {
                  Console.WriteLine("Событие получено. Обработчик: анонимный метод. Значение равно " + n);
  
              };
            evt.OneSomeEvent(3);
            evt.OneSomeEvent(4);

        }
    }
}

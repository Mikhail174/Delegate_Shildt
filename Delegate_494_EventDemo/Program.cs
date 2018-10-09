using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*События действуют по следующему принципу:объект, проявляющий интерес к событию,регистрирует обработчик этого события.
Когда же событие происходит,вызываются все зарегистрированные обработчики этого события. Обработчики событий обычно представлены делегатами.*/
// event делегат_события имя_события
//все события активизируются с помощью делегатов
namespace Delegate_494_EventDemo
{   //объявить тип делегата для события
    delegate void MyEventHandler();
    //Объявить класс,содержащий событие
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
    class EventDemo
    {
        //обработчик события
        static void Handler()
        {
            Console.WriteLine("Произошло событие");
        }
        static void Main(string[] args)
        {
            MyEvent evt = new MyEvent();
            //добавить метод Handler() в список событий
            evt.SomeEvent += Handler;
            //запустить событие 
            evt.OnSomeEvent();
        }
    }


    

    
}

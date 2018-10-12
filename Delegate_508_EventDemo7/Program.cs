using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//использовать встроенный делегат EventHandler

namespace Delegate_508_EventDemo7
{//объявить класс, содержащий событие
    class MyEvent
    {
        public event EventHandler SomeEvent; //использовать делегат EventHandler
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent(this, EventArgs.Empty);
        } 
    }
    class EventDemo7
    {
        static void Handler (object source, EventArgs arg)
        {
            Console.WriteLine("Произошло событие");
            Console.WriteLine( "Источник: "+source);
        }
        static void Main(string[] args)
        {
            MyEvent evt = new MyEvent();
            //Добавить обработчик Handler() в цепочку событий
            evt.SomeEvent += Handler;
            //Запустить событие
            evt.OnSomeEvent();
        }
    }
}

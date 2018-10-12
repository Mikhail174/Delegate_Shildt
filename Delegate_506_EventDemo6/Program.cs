using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*у обработчика событий должно быть 2 параметра, 1-ый: ссылка на объект,формирующий событие, второй-параметр типа EventArgs,содержащий любую дополнительную информацию
 о событии,которая требуется обработчику

 void обработчик (object отправитель, EventArgs e){
 // ...
 }

отправитель - это параметр, передаваемый вызывающим кодом с помощью ключевого слова this. А параметр e типа EventArgs содержит дополнит. информацию о событии и может
быть проигнорирован
 */

    //пример формирования .Net-совместимого события
namespace Delegate_506_EventDemo6
{//объявить класс, производный от класса EventArgs
    class MyEventArgs : EventArgs
    {
        public int EventNum;
    }
    //объявить тип делегата для события 
    delegate void MyEventHandler(object source, MyEventArgs arg);

    //объявить класс, содержащий событие
    class MyEvent
    {
        static int count = 0;
        public event MyEventHandler SomeEvent;
        //этот метод запускает событие SomeEvent
        public void OneSomeEvent()
        {
            MyEventArgs arg = new MyEventArgs();
            if (SomeEvent != null)
            {
                arg.EventNum = count++;
                SomeEvent(this, arg);
            }
        }
    }
    class X
    {
        public void Handler (object source,MyEventArgs arg)
        {
            Console.WriteLine("Событие " + arg.EventNum + " полчуено объектом класса X");
            Console.WriteLine("источник " + source);
            Console.WriteLine();
        }
    }
    class Y
    {
        public void Handler(object source, MyEventArgs arg)
        {
            Console.WriteLine("Событие " + arg.EventNum + " полчуено объектом класса Y");
            Console.WriteLine("источник " + source);
            Console.WriteLine();
        }
    }


    class EventDemo6
    {
        static void Main(string[] args)
        {
            X ob1 = new X();
            Y ob2 = new Y();
            MyEvent evt = new MyEvent();
            //добавить обработчик Handler() в цепочку событий
            evt.SomeEvent += ob1.Handler;
            evt.SomeEvent += ob2.Handler;
            //запустить событие
            evt.OneSomeEvent();
            evt.OneSomeEvent();

        }
    }
}

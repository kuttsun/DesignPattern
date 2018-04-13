using System;
using System.Collections.Generic;
using System.Text;

namespace Observer2
{
    class Observer
    {
        int _id;
        Observable _observable;

        public Observer(int id, Observable observable)
        {
            _id = id;
            _observable = observable;
        }

        public void Subscribe()
        {
            _observable.Listener += OnRecieved;
        }

        public void UnSubscribe()
        {
            _observable.Listener -= OnRecieved;
        }

        void OnRecieved(string msg)
        {
            Console.WriteLine($"Observer{_id} メッセージ受信: {msg}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Observer2
{
    public class Observable
    {
        public event Action<string> Listener;

        public void Execute(string msg)
        {
            Console.WriteLine($"{msg} の実行");
            // 通知
            Listener(msg);
        }
    }
}

using System;

namespace Observer2
{
    class Program
    {
        // see. http://ufcpp.net/study/csharp/sp_event.html
        static void Main(string[] args)
        {
            var observable = new Observable();
            var observer1 = new Observer(1, observable);
            var observer2 = new Observer(2, observable);

            observer1.Subscribe();
            observer2.Subscribe();

            // 何か処理を実行(observer1 と observer2 に通知される)
            observable.Execute("処理1");

            observer1.UnSubscribe();

            // 何か処理を実行(observer2 だけに通知される)
            observable.Execute("処理2");

            Console.ReadKey();
        }
    }
}

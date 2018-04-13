using System;

namespace Observer
{
    // IOberser と IObservable を使用した古典的な実装
    class Program
    {
        // see. http://nanoappli.com/blog/archives/6885
        static void Main(string[] args)
        {
            // 作業者（被監視者）
            var observable = new Observable();

            // 監視者
            var observer = new Observer();

            Console.WriteLine("----- パターン1 -----");
            // 作業者に監視者を割り当てる
            observable.Subscribe(observer);
            // エラー
            observable.Execute(-1);
            // エラーが発生しているので通知は来ない
            observable.Execute(1);
            observable.Execute(2);
            observable.Execute(3);

            Console.WriteLine("----- パターン2 -----");
            // 作業者に監視者を割り当てる
            observable.Subscribe(observer);
            observable.Execute(1);
            observable.Execute(2);
            observable.Execute(3);
            observable.Execute(10);// 完了
            // 完了しているので通知は来ない
            observable.Execute(1);
            observable.Execute(2);
            observable.Execute(3);

            Console.WriteLine("----- パターン3 -----");
            // 作業者に監視者を割り当てる
            IDisposable disporser = observable.Subscribe(observer);
            observable.Execute(1);
            observable.Execute(2);
            observable.Execute(3);
            // 監視者の主導で Unsubscribe する
            disporser.Dispose();
            // Unsubscribe しているので通知は来ない
            observable.Execute(1);
            observable.Execute(2);
            observable.Execute(3);

            Console.ReadKey();
        }
    }
}

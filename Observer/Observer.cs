using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    // 監視する側（監視者、通知を受ける側）
    public class Observer : IObserver<int>
    {
        // 監視対象が処理を完了したとき
        // 例えば通信が切断されるときなど、監視対象からこれ以上イベントが来なくなる事を通知するハンドラ
        public void OnCompleted()
        {
            Console.WriteLine("監視者が完了通知を受信");
        }

        // 監視対象がエラーを出した時
        public void OnError(Exception error)
        {
            Console.WriteLine($"監視者がエラー通知を受信 {error.Message}");
        }

        // 監視対象から通知が来た時
        public void OnNext(int value)
        {
            Console.WriteLine($"監視者が {value} を受信");
        }
    }
}

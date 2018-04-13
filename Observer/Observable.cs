using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    // 監視される側（被監視者、通知する側）
    public class Observable : IObservable<int>
    {
        // 自分を監視する人
        List<IObserver<int>> _observers = new List<IObserver<int>>();

        // 監視される仕事を実行
        public void Execute(int value)
        {
            // IObservable インターフェースを実装するものは、
            // エラーが起きた時は OnError()、イベントの終了は OnCompleted() を呼ぶのが決まり

            // また、IObserver では OnError() および OnCompleted() をコールした後は、
            // OnNext() をコールしてはいけないという決まりのため、_observer をクリアしている

            // エラー判定
            if (value < 0)
            {
                foreach (var observer in _observers)
                {
                    observer.OnError(new Exception("Invalid value:" + value));
                }
                _observers.Clear();

                return;
            }

            // 完了の判定
            if (value >= 10)
            {
                foreach (var observer in _observers)
                {
                    observer.OnCompleted();
                }
                _observers.Clear();
                return;
            }

            Console.WriteLine($"作業{value}をしました");
            // 監視者に通知
            foreach (var observer in _observers)
            {
                observer.OnNext(value);
            }

        }

        // 監視者を割り当てて監視開始
        public IDisposable Subscribe(IObserver<int> observer)
        {
            _observers.Add(observer);
            return new Disposer(_observers);
        }

        // Observer の削除管理クラス
        class Disposer : IDisposable
        {
           List<IObserver<int>> _observers = null;

            // コンストラクタ
            public Disposer(List<IObserver<int>> observers)
            {
                _observers = observers;
            }

            // 削除処理
            public void Dispose()
            {
                // 既に削除が終わっていたら何もしない
                if (_observers != null)
                {
                    _observers.Clear();
                    _observers = null;
                }
            }
        }
    }
}

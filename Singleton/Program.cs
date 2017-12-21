using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            // 以下はビルドエラー
            //var singleton = new Hoge();

            Hoge.Instance.DoSomething();

            Console.ReadKey();
        }
    }

    // シングルトンクラス
    public class Hoge
    {
        public static Hoge Instance { get; } = new Hoge();

        // private コンストラクタにすることで、new を抑制する
        private Hoge() { }

        public void DoSomething()
        {
            Console.WriteLine("Hello World!");
        }
    }
}

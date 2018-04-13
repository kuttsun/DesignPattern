using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctxt = new Context()
            {
                Strategy = new StrategyA()
            };

            // 初期のアルゴリズム（戦略）で実行
            ctxt.Execute();

            // アルゴリズム（戦略）を切り替えて実行
            ctxt.Strategy = new StrategyB();
            ctxt.Execute();

            Console.ReadKey();
        }
    }

    // 利用するアルゴリズム共通のインターフェース。
    interface IStrategy
    {
        void DoSomething();
    }

    // アルゴリズム（戦略）　その１
    class StrategyA : IStrategy
    {
        public void DoSomething()
        {
            Console.WriteLine("Strategy A.");
        }
    }

    // アルゴリズム（戦略）　その２
    class StrategyB : IStrategy
    {
        public void DoSomething()
        {
            Console.WriteLine("Strategy B.");
        }
    }

    // アルゴリズムや振る舞いを委譲する。
    class Context
    {
        public IStrategy Strategy { set; private get; }

        public void Execute()
        {
            Strategy.DoSomething();
        }
    }
}

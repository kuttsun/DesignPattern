using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            // 初期状態Aで作成
            Context c = new Context(new ConcreteStateA());

            // 状態に応じた処理を実行（コールする度に状態が遷移する）
            c.Request();
            c.Request();
            c.Request();
            c.Request();

            Console.ReadKey();
        }
    }

    abstract class State
    {
        public abstract void Handle(Context context);
    }

    // 状態A
    class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            // 状態に応じた処理を実行

            // 実行後、次の状態に遷移する
            context.State = new ConcreteStateB();
        }
    }

    // 状態B
    class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            // 状態に応じた処理を実行

            // 実行後、次の状態に遷移する
            context.State = new ConcreteStateA();
        }
    }


    class Context
    {
        // Constructor
        public Context(State state)
        {
            State = state;
        }
        
        // Gets or sets the state
        private State _state;
        public State State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("State: " + _state.GetType().Name);
            }
        }

        // 状態に応じた処理を実行
        public void Request()
        {
            _state.Handle(this);
        }
    }
}

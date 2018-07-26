using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            // new ではなく Factory というインスタンス生成を担うクラスでインスタンス生成を行う
            // Factory で生成されるインスタンスは、通常は派生クラスとなる
            // 使用する側は何の派生クラスかを意識せず処理が書ける
            // インスタンス生成箇所を集約することにより、派生クラスの種類が増えた場合の影響範囲を抑える
            var factory = new Factory();
            var car1 = factory.Create(2000000);
            var car2 = factory.Create(4000000);

            car1.Drive();
            car2.Drive();

            Console.ReadKey();


        }

        // ここでは静的クラスとして実装しているが必須ではない
        class Factory
        {
            // 引き渡された金額に相当する車の派生クラスのインスタンスを生成・返却
            public ACar Create(int price)
            {
                if (price <= 1000000)
                {
                    throw new ArgumentException();
                }
                else if (price <= 3000000)
                {
                    return new CompactCar();
                }
                // 途中で派生クラスが増えても Create メソッドを修正するだけでよい
                //else if (price <= 3500000)
                //{
                //    return new EcoCar();
                //}
                else
                {
                    return new MiddleCar();
                }
            }
        }

        abstract class ACar
        {
            public abstract void Drive();
        }

        class CompactCar : ACar
        {
            public override void Drive() => Console.WriteLine("CompactCar!");
        }

        class MiddleCar : ACar
        {
            public override void Drive() => Console.WriteLine("MiddleCar!");
        }

        // 将来的に以下の派生クラスが増えるかもしれない
        //class EcoCar : ACar
        //{
        //    public override void Drive() { }
        //}
    }
}

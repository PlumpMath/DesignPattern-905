using System;

namespace StrategyPattern
{
    class Program
    {
        // 參考: https://dotblogs.com.tw/h091237557/2014/05/29/145301
        static void Main(string[] args)
        {
            //實體化博派第一台測試機。
            AutobotTransformer Test1 = new AutobotTransformer();
            Test1.Heart();
            Test1.performFly();


            //實體化狂派第二台測試機。
            DecepticonTransformer Test2 = new DecepticonTransformer();
            Test2.Heart();
            Test2.performFly();

            Console.ReadKey();
        }
    }

    abstract class Transformer
    {
        //宣告為介面型態的變數。
        //每個變數會利用多型的方式在執行期取用到正確的動作。
        public IFly FlyBehavior;

        //建立速度欄位。
        private int speed;

        //建立能量欄位。
        private int power;


        //建立速度屬性
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        //建立能量屬性
        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public void Run()
        {
            Console.WriteLine("我很會跑喔");
        }


        //不親自處理飛行行為，而是委由FlyBehavior物件幫忙處理。
        public void performFly()
        {
            FlyBehavior.Fly();
        }
    }

    //博派
    class AutobotTransformer : Transformer
    {
        public AutobotTransformer()
        {
            FlyBehavior = new FlyNoWay();
        }

        public void Heart()
        {
            Console.WriteLine("我是博派我是好人");
        }
    }

    //狂派
    class DecepticonTransformer : Transformer
    {

        public DecepticonTransformer()
        {
            FlyBehavior = new FlyWithRocket();
        }

        public void Heart()
        {
            Console.WriteLine("我是狂派，我是壞人~ 呼呼~");
        }
        
    }

    class FlyWithRocket : IFly
    {
        public void Fly()
        {
            Console.WriteLine("我用火箭推進飛行");
        }
    }

    class FlyNoWay : IFly
    {
        public void Fly()
        {
            Console.WriteLine("對不起我還很菜不會飛");
        }

    }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryPattern
{
    // 參考1 : http://xyz.cinc.biz/2013/05/simple-factory-pattern.html
    // 參考2 : https://dotblogs.com.tw/joysdw12/archive/2013/06/23/design-pattern-simple-factory-pattern.aspx
    class Program
    {
        static void Main(string[] args)
        {
            #region Toy
            Toy aa;
            aa = ToyFactory.CreateToy("car");
            aa.MakeToy();//製造了 玩具車
            aa = ToyFactory.CreateToy("dog");
            aa.MakeToy();//製造了 玩具狗
            #endregion

            #region Beverage
            BeverageStores store = new BeverageStores(new SimpleBeverageFactory());
            Console.WriteLine("A 客人點了綠茶");
            store.BeverageOrders("GreenTea");
            Console.WriteLine("B 客人點了紅茶");
            store.BeverageOrders("BlackTea");
            #endregion

            Console.ReadLine();

        }
    }

    #region Toy
    abstract class Toy
    {
        public abstract void MakeToy();
    }

    class ToyCar : Toy
    {
        public override void MakeToy()
        {
            Console.WriteLine("製造了 玩具車");
        }
    }

    class ToyDog : Toy
    {
        public override void MakeToy()
        {
            Console.WriteLine("製造了 玩具狗");
        }
    }

    class ToyFactory
    {
        public static Toy CreateToy(String cc)
        {
            Toy obj = null;
            switch (cc)
            {
                case "car":
                    obj = new ToyCar();
                    break;
                case "dog":
                    obj = new ToyDog();
                    break;
                default:
                    throw new Exception("沒有這個類別");

            }
            return obj;
        }
    }
    #endregion

    #region Beverage
    public interface IBeverageProvide
    {
        void AddMaterial();
        void Brew();
        void PouredCup();
    }
    public class GreenTea : IBeverageProvide
    {
        public void AddMaterial()
        {
            Console.WriteLine("綠茶 加入調味!");
        }
        public void Brew()
        {
            Console.WriteLine("綠茶 煮!");
        }
        public void PouredCup()
        {
            Console.WriteLine("綠茶 倒入杯子!");
        }
    }

    public class BlackTea : IBeverageProvide
    {
        public void AddMaterial()
        {
            Console.WriteLine("紅茶 加入調味!");
        }
        public void Brew()
        {
            Console.WriteLine("紅茶 煮!");
        }
        public void PouredCup()
        {
            Console.WriteLine("紅茶 倒入杯子!");
        }
    }

    public class SimpleBeverageFactory
    {
        public IBeverageProvide CreateBeverage(string pBeverageType)
        {
            IBeverageProvide beverage;
            if (pBeverageType == "GreenTea")
                return beverage = new GreenTea();
            if (pBeverageType == "BlackTea")
                return beverage = new BlackTea();
            else
                return null;
        }
    }

    public class BeverageStores
    {
        private SimpleBeverageFactory _factory;

        public BeverageStores(SimpleBeverageFactory pFactory)
        {
            _factory = pFactory;
        }

        public IBeverageProvide BeverageOrders(string pBeverageType)
        {
            IBeverageProvide beverage;
            beverage = _factory.CreateBeverage(pBeverageType);

            beverage.AddMaterial(); // 加料
            beverage.Brew(); // 沖泡
            beverage.PouredCup(); // 裝杯

            return beverage;
        }
    }
    #endregion
}

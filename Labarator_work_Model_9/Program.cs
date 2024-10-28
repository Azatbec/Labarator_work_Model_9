using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labarator_work_Model_9
{
    public interface IBeverage
    {
        double GetCost();
        string GetDescription();
    }

    public class Coffee : IBeverage
    {
        public double GetCost()
        {
            return 25.5;
        }

        public string GetDescription()
        {
            return "Coffee";
        }
    }

    public abstract class BeverageDecorator : IBeverage
    {
        protected IBeverage _beverage;

        public BeverageDecorator(IBeverage beverage)
        {
            _beverage = beverage;
        }

        public virtual double GetCost()
        {
            return _beverage.GetCost();
        }

        public virtual string GetDescription()
        {
            return _beverage.GetDescription();
        }
    }

    // Декораторы для добавок

    public class MilkDecorator : BeverageDecorator
    {
        public MilkDecorator(IBeverage beverage) : base(beverage) { }

        public override double GetCost()
        {
            return base.GetCost() + 20.15;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Milk";
        }
    }

    public class SugarDecorator : BeverageDecorator
    {
        public SugarDecorator(IBeverage beverage) : base(beverage) { }

        public override double GetCost()
        {
            return base.GetCost() + 6.0;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Sugar";
        }
    }

    public class ChocolateDecorator : BeverageDecorator
    {
        public ChocolateDecorator(IBeverage beverage) : base(beverage) { }

        public override double GetCost()
        {
            return base.GetCost() + 16.2;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Chocolate";
        }
    }

    // Дополнительные декораторы для новых добавок

    public class VanillaDecorator : BeverageDecorator
    {
        public VanillaDecorator(IBeverage beverage) : base(beverage) { }

        public override double GetCost()
        {
            return base.GetCost() + 10.5;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Vanilla";
        }
    }

    public class CinnamonDecorator : BeverageDecorator
    {
        public CinnamonDecorator(IBeverage beverage) : base(beverage) { }

        public override double GetCost()
        {
            return base.GetCost() + 8.0;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", Cinnamon";
        }
    }

    // Клиентский код для тестирования

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем базовый напиток
            IBeverage beverage = new Coffee();
            Console.WriteLine($"{beverage.GetDescription()}: {beverage.GetCost()}");

            // Добавляем различные добавки
            beverage = new MilkDecorator(beverage);
            Console.WriteLine($"{beverage.GetDescription()}: {beverage.GetCost()}");

            beverage = new SugarDecorator(beverage);
            Console.WriteLine($"{beverage.GetDescription()}: {beverage.GetCost()}");

            beverage = new ChocolateDecorator(beverage);
            Console.WriteLine($"{beverage.GetDescription()}: {beverage.GetCost()}");

            beverage = new VanillaDecorator(beverage);
            Console.WriteLine($"{beverage.GetDescription()}: {beverage.GetCost()}");

            beverage = new CinnamonDecorator(beverage);
            Console.WriteLine($"{beverage.GetDescription()}: {beverage.GetCost()}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labarator_work_Model_9_2
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
        void RefundPayment(double amount);
    }

    public class InternalPaymentProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing payment of {amount} via internal system.");
        }

        public void RefundPayment(double amount)
        {
            Console.WriteLine($"Refunding payment of {amount} via internal system.");
        }
    }

    public class ExternalPaymentSystemA
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"Making payment of {amount} via External Payment System A.");
        }

        public void MakeRefund(double amount)
        {
            Console.WriteLine($"Making refund of {amount} via External Payment System A.");
        }
    }

    public class ExternalPaymentSystemB
    {
        public void SendPayment(double amount)
        {
            Console.WriteLine($"Sending payment of {amount} via External Payment System B.");
        }

        public void ProcessRefund(double amount)
        {
            Console.WriteLine($"Processing refund of {amount} via External Payment System B.");
        }
    }

    public class PaymentAdapterA : IPaymentProcessor
    {
        private ExternalPaymentSystemA _externalSystemA;

        public PaymentAdapterA(ExternalPaymentSystemA externalSystemA)
        {
            _externalSystemA = externalSystemA;
        }

        public void ProcessPayment(double amount)
        {
            _externalSystemA.MakePayment(amount);
        }

        public void RefundPayment(double amount)
        {
            _externalSystemA.MakeRefund(amount);
        }
    }

    public class PaymentAdapterB : IPaymentProcessor
    {
        private ExternalPaymentSystemB _externalSystemB;

        public PaymentAdapterB(ExternalPaymentSystemB externalSystemB)
        {
            _externalSystemB = externalSystemB;
        }

        public void ProcessPayment(double amount)
        {
            _externalSystemB.SendPayment(amount);
        }

        public void RefundPayment(double amount)
        {
            _externalSystemB.ProcessRefund(amount);
        }
    }

    // Класс для выбора подходящего платежного процессора
    public class PaymentProcessorFactory
    {
        public static IPaymentProcessor GetPaymentProcessor(string currency)
        {
            if (currency == "USD")
            {
                return new InternalPaymentProcessor();
            }
            else if (currency == "EUR")
            {
                return new PaymentAdapterA(new ExternalPaymentSystemA());
            }
            else
            {
                return new PaymentAdapterB(new ExternalPaymentSystemB());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Пример использования фабрики для выбора платежной системы в зависимости от валюты
            TestPayment("USD", 100.0, 50.0);
            TestPayment("EUR", 200.0, 100.0);
            TestPayment("JPY", 300.0, 150.0);

            Console.ReadKey();
        }

        static void TestPayment(string currency, double paymentAmount, double refundAmount)
        {
            Console.WriteLine($"\nTesting payment with currency: {currency}");
            IPaymentProcessor processor = PaymentProcessorFactory.GetPaymentProcessor(currency);
            processor.ProcessPayment(paymentAmount);
            processor.RefundPayment(refundAmount);
        }
    }

}

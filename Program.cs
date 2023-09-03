using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTestingPatterns
{
    // Общий интерфейс всех стратегий.
    public interface IAbstractStrategyArithmeticOperation
    {
        double SimpleOperation(double value1, double value2);
    }

    // Каждая конкретная стратегия реализует общий интерфейс своим способом.
    public class ConcreteStrategyPlus : IAbstractStrategyArithmeticOperation
    {
        public double SimpleOperation(double value1, double value2)
        {
            double result = value1 + value2;
            Console.WriteLine(result);
            return result;
        }
    }

    public class ConcreteStrategyMinus : IAbstractStrategyArithmeticOperation
    {
        public double SimpleOperation(double value1, double value2)
        {
            double result = value1 - value2;
            Console.WriteLine(result);
            return result;
        }
    }

    public class ConcreteStrategyDevide : IAbstractStrategyArithmeticOperation
    {
        public double SimpleOperation(double value1, double value2)
        {
            double result = value1 / value2;
            Console.WriteLine(result);
            return result;
        }
    }

    // Контекст всегда работает со стратегиями через общий интерфейс.
    // Он не знает, какая именно стратегия ему подана.
    public class Context
    {
        private IAbstractStrategyArithmeticOperation operation;
        public Context(IAbstractStrategyArithmeticOperation operation)
        {            
            this.operation = operation;
        }
        public void SetStrategy(IAbstractStrategyArithmeticOperation operation)
        {
            this.operation = operation;
        }
        public void SimpleOperation(double value1, double value2)
        {
            this.operation.SimpleOperation(value1, value2);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            double firstValue = 100;
            double secondValue = 10;

            Context newArithmeticOperation = new Context(new ConcreteStrategyPlus());
            newArithmeticOperation.SimpleOperation(firstValue, secondValue); // 110

            newArithmeticOperation.SetStrategy(new ConcreteStrategyMinus());
            newArithmeticOperation.SimpleOperation(firstValue, secondValue); // 90

            newArithmeticOperation.SetStrategy(new ConcreteStrategyDevide());
            newArithmeticOperation.SimpleOperation(firstValue, secondValue); // 10
        }
    }
}

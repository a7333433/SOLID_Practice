using homework1.Calculators.OperationCalculator;
using homework1.Decorators;
using homework1.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Calculators
{
    public class Calculator : ICalculator
    {
        private readonly IOperationCalculatorFactory calculatorFactory;
        private readonly ILogger logger;

        public Calculator(IOperationCalculatorFactory calculatorFactory, ILogger logger = null) {
            this.calculatorFactory = calculatorFactory;
            this.logger = logger;
        }
        public double Abs(double x)
        {
            return new UnaryOperationDecorator(calculatorFactory.CreateUnary(OperationConst.Abs), logger).Calculate(x);
        }

        public double Add(double x, double y)
        {
            return new BinaryOperationDecorator(calculatorFactory.CreateBinary(OperationConst.Add), logger).Calculate(x,y);
        }

        public double Divide(double x, double y)
        {
            return new BinaryOperationDecorator(calculatorFactory.CreateBinary(OperationConst.Divide), logger).Calculate(x, y);
        }

        public double Multiply(double x, double y)
        {
            return new BinaryOperationDecorator(calculatorFactory.CreateBinary(OperationConst.Multiply), logger).Calculate(x, y);
        }

        public double Subtract(double x, double y)
        {
            return new BinaryOperationDecorator(calculatorFactory.CreateBinary(OperationConst.Subtract), logger).Calculate(x, y);
        }
    }
}

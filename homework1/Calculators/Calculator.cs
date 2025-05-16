using homework1.Calculators.OperationCalculator;
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

        public Calculator(IOperationCalculatorFactory calculatorFactory) {
            this.calculatorFactory = calculatorFactory;
        }
        public double Abs(double x)
        {
            return (calculatorFactory.Create(OperationConst.Abs) as IOneParameterOperationCalculator).Calculate(x);
        }

        public double Add(double x, double y)
        {
            return (calculatorFactory.Create(OperationConst.Add) as ITwoParameterOperationCalculator).Calculate(x,y);
        }

        public double Divide(double x, double y)
        {
            return (calculatorFactory.Create(OperationConst.Divide) as ITwoParameterOperationCalculator).Calculate(x,y);
        }

        public double Multiply(double x, double y)
        {
            return (calculatorFactory.Create(OperationConst.Multiply) as ITwoParameterOperationCalculator).Calculate(x,y);
        }

        public double Subtract(double x, double y)
        {
            return (calculatorFactory.Create(OperationConst.Subtract) as ITwoParameterOperationCalculator).Calculate(x,y);
        }
    }
}

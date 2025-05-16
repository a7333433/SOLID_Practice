using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Calculators.OperationCalculator
{
    internal class DefaultOperationFactory : IOperationCalculatorFactory
    {
        private static Dictionary<string, Func<IOperationCalculator>> registry = new(); 
        private readonly ILogger logger;

        public DefaultOperationFactory(ILogger logger) {
            this.logger = logger;
        }

        public void Register(string operation, Func<IOperationCalculator> calculator)
        {
            registry[operation] = calculator;
        }

        public IOperationCalculator Create(string operation)
        {
            if(registry.TryGetValue(operation,out var calculator))
                return calculator();

            throw new ArgumentException("不支援的運算子");
        }
    }
}

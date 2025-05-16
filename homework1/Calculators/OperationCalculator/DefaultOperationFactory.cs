using homework1.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Calculators.OperationCalculator
{
    internal class DefaultOperationFactory : IOperationCalculatorFactory
    {
        private static Dictionary<string, Func<IUnaryOperationCalculator>> unaryRegistry = new(); 
        private static Dictionary<string, Func<IBinaryOperationCalculator>> binaryRegistry = new(); 
        private readonly ILogger logger;

        public DefaultOperationFactory(ILogger logger) {
            this.logger = logger;
        }

        public void RegisterUnary(string operation, Func<IUnaryOperationCalculator> calculator)
        {
            unaryRegistry[operation] = calculator;
        }

        public void RegisterBinary(string operation, Func<IBinaryOperationCalculator> calculator)
        {
            binaryRegistry[operation] = calculator;
        }

        public IUnaryOperationCalculator CreateUnary(string operation)
        {
            if(unaryRegistry.TryGetValue(operation,out var calculator))
                return calculator();

            throw new ArgumentException("不支援的運算子");
        }

        public IBinaryOperationCalculator CreateBinary(string operation)
        {
            if(binaryRegistry.TryGetValue(operation,out var calculator))
                return calculator();

            throw new ArgumentException("不支援的運算子");
        }
    }
}

using homework1.Calculators.OperationCalculator;
using homework1.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Decorators
{
    public class UnaryOperationDecorator : IUnaryOperationCalculator
    {
        private readonly IUnaryOperationCalculator innerOperationCalculator;
        private readonly ILogger logger;

        public UnaryOperationDecorator(IUnaryOperationCalculator innerOperationCalculator, ILogger logger = null) {
            this.innerOperationCalculator = innerOperationCalculator;
            this.logger = logger;
        }
        public double Calculate(double x)
        {
            try
            {
                return innerOperationCalculator.Calculate(x);
            }
            catch (Exception ex) {
                logger?.Error(ex.Message);
                return 0;
            }
        }
    }
}

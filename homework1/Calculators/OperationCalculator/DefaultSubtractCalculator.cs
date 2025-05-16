using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Calculators.OperationCalculator
{
    public class DefaultSubtractCalculator : IOperationCalculator
    {
        private readonly ILogger logger;

        public DefaultSubtractCalculator(ILogger logger) {
            this.logger = logger;
        }

        public double Subtract(double a, double b)
        {
            logger.Info($@"Subtracting...");
            return a - b;
        }
    }
}

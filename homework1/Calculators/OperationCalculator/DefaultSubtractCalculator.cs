using homework1.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Calculators.OperationCalculator
{
    public class DefaultSubtractCalculator : IBinaryOperationCalculator
    {
        private readonly ILogger logger;

        public DefaultSubtractCalculator(ILogger logger) {
            this.logger = logger;
        }

        public double Calculate(double a, double b)
        {
            logger.Info($@"Subtracting...");
            return a - b;
        }
    }
}

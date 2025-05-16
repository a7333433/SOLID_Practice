using homework1.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Calculators.OperationCalculator
{
    public class DefaultMultiplyCalculator : IBinaryOperationCalculator
    {
        private readonly ILogger logger;

        public DefaultMultiplyCalculator(ILogger logger) {
            this.logger = logger;
        }

        public double Calculate(double a, double b)
        {
            logger.Info($@"Multiplying...");
            return a * b;
        }
    }
}

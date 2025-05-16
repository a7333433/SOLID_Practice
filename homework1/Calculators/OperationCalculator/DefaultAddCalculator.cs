using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Calculators.OperationCalculator
{
    public class DefaultAddCalculator : ITwoParameterOperationCalculator
    {
        private readonly ILogger logger;

        public DefaultAddCalculator(ILogger logger) {
            this.logger = logger;
        }

        public double Calculate(double x, double y)
        {
            logger.Info($@"Adding...");
            return x + y;
        }
    }
}

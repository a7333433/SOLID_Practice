using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Calculators.OperationCalculator
{
    public class DefaultAbsCalculator : IOneParameterOperationCalculator
    {
        private readonly ILogger logger;

        public DefaultAbsCalculator(ILogger logger) {
            this.logger = logger;
        }

        public double Calculate(double x)
        {
            logger.Info($@"Absing...");
            if (x > 0)
                return x;
            else
                return x * -1;
        }
    }
}

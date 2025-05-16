using homework1.Calculators.OperationCalculator;
using homework1.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Stubs
{
    public class StubAddCalculator : IBinaryOperationCalculator
    {
        private readonly ILogger logger;

        public StubAddCalculator(ILogger logger) {
            this.logger = logger;
        }

        public double Calculate(double x, double y)
        {
            logger.Info($@"Adding...");
            return 10000;
        }
    }
}

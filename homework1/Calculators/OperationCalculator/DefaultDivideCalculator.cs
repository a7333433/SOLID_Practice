using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Calculators.OperationCalculator
{
    public class DefaultDivideCalculator : ITwoParameterOperationCalculator
    {
        
        private readonly ILogger logger;

        public DefaultDivideCalculator(ILogger logger) {
            this.logger = logger;
        }

        public double Calculate(double a, double b)
        {
            if (b == 0)
            {
                logger.Info("Cannot divide by zero");
                return 0;
            }

            return a / b;
        }
    }
}

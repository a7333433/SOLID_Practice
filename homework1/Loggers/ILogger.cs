using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Loggers
{
    public interface ILogger
    {
        void Info(string message);
        void Error(string message);
    }
}

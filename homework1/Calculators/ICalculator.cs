﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1.Calculators
{
    public interface ICalculator
    {
        double Add(double x, double y);
        double Subtract(double x, double y);
        double Multiply(double x, double y);
        double Divide(double x, double y);
        double Abs(double x);
    }
}

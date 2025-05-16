namespace homework1.Calculators.OperationCalculator
{
    public interface ITwoParameterOperationCalculator: IOperationCalculator
    {
        double Calculate(double x, double y);
    }
}
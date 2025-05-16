namespace homework1.Calculators.OperationCalculator
{
    public interface IOneParameterOperationCalculator:IOperationCalculator
    {
        double Calculate(double x);
    }
}
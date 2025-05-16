namespace homework1.Calculators.OperationCalculator
{
    public interface IOperationCalculatorFactory
    {
        IOperationCalculator Create(string operation);
    }
}
namespace homework1.Calculators.OperationCalculator
{
    public interface IOperationCalculatorFactory
    {
        public IUnaryOperationCalculator CreateUnary(string operation);
        public IBinaryOperationCalculator CreateBinary(string operation);
    }
}
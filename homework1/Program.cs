using homework1;
using homework1.Calculators;
using homework1.Calculators.OperationCalculator;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<ILogger, ConsoleLogger>()
    .AddSingleton<IOperationCalculatorFactory>(s => {
        var logger = s.GetRequiredService<ILogger>();

        var factory = new DefaultOperationFactory(logger);

        factory.Register(OperationConst.Abs, () => new DefaultAbsCalculator(logger));
        factory.Register(OperationConst.Add, () => new DefaultAddCalculator(logger));
        factory.Register(OperationConst.Subtract, () => new DefaultSubtractCalculator(logger));
        factory.Register(OperationConst.Multiply, () => new DefaultMultiplyCalculator(logger));
        factory.Register(OperationConst.Divide, () => new DefaultDivideCalculator(logger));

        return factory;
    })
    .AddSingleton<ICalculator,Calculator>()
    .BuildServiceProvider();

var calculator = serviceProvider.GetRequiredService<ICalculator>();

Console.WriteLine(calculator.Add(2, 5));
Console.WriteLine(calculator.Divide(10, 0));
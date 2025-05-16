using homework1.Calculators;
using homework1.Calculators.OperationCalculator;
using homework1.Loggers;
using homework1.Stubs;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<ILogger, ConsoleLogger>()
    .AddSingleton<IOperationCalculatorFactory>(s => {
        var logger = s.GetRequiredService<ILogger>();

        var factory = new DefaultOperationFactory(logger);

        factory.RegisterUnary(OperationConst.Abs, () => new DefaultAbsCalculator(logger));

        //模擬拆分任一運算為獨立服務（透過 stub 或 interface）
        factory.RegisterBinary(OperationConst.Add, () => new StubAddCalculator(logger));

        factory.RegisterBinary(OperationConst.Subtract, () => new DefaultSubtractCalculator(logger));
        factory.RegisterBinary(OperationConst.Multiply, () => new DefaultMultiplyCalculator(logger));
        factory.RegisterBinary(OperationConst.Divide, () => new DefaultDivideCalculator(logger));

        return factory;
    })
    .AddSingleton<ICalculator,Calculator>()
    .BuildServiceProvider();

var calculator = serviceProvider.GetRequiredService<ICalculator>();

//模擬服務，固定回傳10000
Console.WriteLine(calculator.Add(1, 1));

//錯誤捕捉器
Console.WriteLine(calculator.Divide(2, 0));

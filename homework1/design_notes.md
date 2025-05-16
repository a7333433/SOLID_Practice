### 實踐方式
* 單一職責原則
>將各個運算方式各自建立類別 Add、Subtract、Multiply、Divide、Abs..。

* 依賴反轉原則
> 各運算方式的建構子提供ILogger介面參數，
由外部決定實際的記錄方式，要新增新的紀錄方式(例如Console、NLog、Database)
只需建立類別實作此介面並帶入即可。
```
public DefaultAbsCalculator(ILogger logger) {
    this.logger = logger;
}
```

* 介面隔離原則
> 將加減乘除類實作雙參數介面，絕對值、平方根類實作單參數介面。
```
public class DefaultAbsCalculator : IUnaryOperationCalculator
```

* 開放封閉原則。
> 使用工廠模式，建立工廠 DefaultOperationCalculator 類統一管理註冊及產生運算方式類別的方式，
工廠會依註冊方式分為單參數及雙參數的運算，未來需要擴充新的運算方式只需進行對應的註冊即可使用。
```
factory.RegisterUnary(OperationConst.Abs, () => new DefaultAbsCalculator(logger));
```

* 里氏替換原則
> 在主運算器Calculator中，工廠會回傳介面物件而非實際類別，並使用介面定義的方法作呼叫運算，
這樣未來就算抽換實體類別時也不用異動邏輯。
```
public IUnaryOperationCalculator CreateUnary(string operation)
{
    if(unaryRegistry.TryGetValue(operation,out var calculator))
        return calculator();

    throw new ArgumentException("不支援的運算子");
}
```
```
public double Abs(double x)
{
    return new UnaryOperationDecorator(calculatorFactory.CreateUnary(OperationConst.Abs), logger).Calculate(x);
}
```


* 實作模組註冊機制（註冊運算模組後自動可用）
> 在主邏輯使用相依注入容器物件進行工廠注入前先註冊想要的運算方式與對應的實體類即可使用。
```
factory.RegisterUnary(OperationConst.Abs, () => new DefaultAbsCalculator(logger));
```

* 支援單參數操作（如平方根、絕對值等）
> 拆分出單參數(IUnaryOperationCalculator)與雙參數(IBinaryOperationCalculator)介面，
各運算方式實作對應的介面，工廠會根據傳入值產生對應的介面作後續運算。
```
public double Abs(double x)
{
    return new UnaryOperationDecorator(calculatorFactory.CreateUnary(OperationConst.Abs), logger).Calculate(x);
}
```

* 模擬拆分服務
> 可以建立一Stub類，並在工廠註冊時註冊至對應的運算方式以方便測試。
```
factory.RegisterBinary(OperationConst.Add, () => new StubAddCalculator(logger));
```

* 加入簡單策略，例如 fallback 或異常捕捉裝飾器
> 建立單參數與雙參數的裝飾器，將工廠產生的對像作為參數傳入。
```
public double Abs(double x)
{
    return new UnaryOperationDecorator(calculatorFactory.CreateUnary(OperationConst.Abs), logger).Calculate(x);
}
```







using FruitSalesCalculator.Pricing;

namespace FruitSalesCalculator.Models;

public class FruitWithStrategy : Fruit
{
    private readonly IPricingStrategy _pricingStrategy;

    public FruitWithStrategy(string name, decimal basePrice, IPricingStrategy pricingStrategy)
        : base(name, basePrice)
    {
        _pricingStrategy = pricingStrategy;
    }

    public override decimal CalculatePrice(decimal quantity)
    {
        return _pricingStrategy.Calculate(BasePrice, quantity);
    }
}
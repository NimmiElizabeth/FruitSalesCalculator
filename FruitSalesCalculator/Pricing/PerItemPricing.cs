namespace FruitSalesCalculator.Pricing;

public class PerItemPricing : IPricingStrategy
{
    public decimal Calculate(decimal basePrice, decimal quantity)
    {
        return basePrice * Math.Floor(quantity);
    }
}
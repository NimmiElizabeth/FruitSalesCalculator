using FruitSalesCalculator.Pricing;

namespace FruitSalesCalculator.Pricing;
public class PerKgPricing : IPricingStrategy
{
    public decimal Calculate(decimal basePrice, decimal quantity)
    {
        return basePrice * quantity;
    }
}
namespace FruitSalesCalculator.Pricing;

public interface IPricingStrategy
{
    decimal Calculate(decimal basePrice, decimal quantity);
}
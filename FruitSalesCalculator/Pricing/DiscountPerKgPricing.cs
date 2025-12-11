namespace FruitSalesCalculator.Pricing;

public class DiscountPerKgPricing : IPricingStrategy
{
    private readonly decimal _discountThreshold;
    private readonly decimal _discountRate;

    public DiscountPerKgPricing(decimal discountThreshold, decimal discountRate)
    {
        _discountThreshold = discountThreshold;
        _discountRate = discountRate;
    }

    public decimal Calculate(decimal basePrice, decimal quantity)
    {
        var total = basePrice * quantity;
        if (quantity > _discountThreshold)
        {
            total *= (1 - _discountRate);
        }
        return total;
    }
}

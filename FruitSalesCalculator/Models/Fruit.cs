namespace FruitSalesCalculator.Models;

public abstract class Fruit
{
    public string Name { get; }
    public decimal BasePrice { get; }

    protected Fruit(string name, decimal basePrice)
    {
        Name = name;
        BasePrice = basePrice;
    }

    public abstract decimal CalculatePrice(decimal quantity);
}

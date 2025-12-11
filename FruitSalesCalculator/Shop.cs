using FruitSalesCalculator.Models;

namespace FruitSalesCalculator;

public class Shop
{
    private readonly Dictionary<string, Fruit> _fruits = new();

    public void RegisterFruit(Fruit fruit)
    {
        _fruits[fruit.Name] = fruit;
    }

    public decimal CalculateTotal(Order order)
    {
        decimal total = 0;
        foreach (var item in order.Items)
        {
            if (_fruits.TryGetValue(item.Key, out var fruit))
            {
                total += fruit.CalculatePrice(item.Value);
            }
        }
        return total;
    }
}

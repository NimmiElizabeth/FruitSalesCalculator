namespace FruitSalesCalculator.Models;

public class Order
{
    private readonly Dictionary<string, decimal> _items = new();

    public void AddItem(string fruitName, decimal quantity)
    {
        if (_items.ContainsKey(fruitName))
            _items[fruitName] += quantity;
        else
            _items[fruitName] = quantity;
    }

    public IReadOnlyDictionary<string, decimal> Items => _items;
}

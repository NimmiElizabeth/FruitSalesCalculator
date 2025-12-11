using System;
using FruitSalesCalculator;
using FruitSalesCalculator.Models;

var shop = new Shop();
var order = new Order();

while (true)
{
    Console.WriteLine("Enter fruit name (or 'done' to finish):");
    var fruitName = Console.ReadLine();
    if (string.Equals(fruitName, "done", StringComparison.OrdinalIgnoreCase))
        break;

    if (!string.IsNullOrWhiteSpace(fruitName))
    {
        Console.WriteLine("Enter base price:");
        if (!decimal.TryParse(Console.ReadLine(), out var basePrice) || basePrice <= 0)
        {
            Console.WriteLine("Invalid price. Try again.");
            continue;
        }

        Console.WriteLine("Select pricing strategy: 1) Per Kg  2) Per Item  3) Discount Per Kg");
        var strategyInput = Console.ReadLine();
        FruitSalesCalculator.Pricing.IPricingStrategy strategy;
        if (strategyInput == "1")
        {
            strategy = new FruitSalesCalculator.Pricing.PerKgPricing();
        }
        else if (strategyInput == "2")
        {
            strategy = new FruitSalesCalculator.Pricing.PerItemPricing();
        }
        else if (strategyInput == "3")
        {
            Console.WriteLine("Enter discount threshold (kg):");
            if (!decimal.TryParse(Console.ReadLine(), out var threshold) || threshold <= 0)
            {
                Console.WriteLine("Invalid threshold. Try again.");
                continue;
            }
            Console.WriteLine("Enter discount rate (e.g. 0.10 for 10%):");
            if (!decimal.TryParse(Console.ReadLine(), out var rate) || rate <= 0 || rate >= 1)
            {
                Console.WriteLine("Invalid rate. Try again.");
                continue;
            }
            strategy = new FruitSalesCalculator.Pricing.DiscountPerKgPricing(threshold, rate);
        }
        else
        {
            Console.WriteLine("Unknown strategy. Try again.");
            continue;
        }
        var newFruit = new FruitSalesCalculator.Models.FruitWithStrategy(fruitName!, basePrice, strategy);
        shop.RegisterFruit(newFruit);
    }
    Console.WriteLine("Enter quantity (kg or count):");
    if (!decimal.TryParse(Console.ReadLine(), out var quantity) || quantity <= 0)
    {
        Console.WriteLine("Invalid quantity. Try again.");
        continue;
    }
    order.AddItem(fruitName!, quantity);
}

var total = shop.CalculateTotal(order);
Console.WriteLine($"Total: ${total:F2}");

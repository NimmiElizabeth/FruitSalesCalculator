using Xunit;
using FruitSalesCalculator;
using FruitSalesCalculator.Models;
using FruitSalesCalculator.Pricing;

namespace FruitSalesCalculator.Tests
{
    public class ShopTests
    {
        [Fact]
        public void RegisterFruit_ShouldAddFruitToShop()
        {
            // Arrange
            var shop = new Shop();
            var fruit = new FruitWithStrategy("Apple", 2.0m, new PerKgPricing());

            // Act
            shop.RegisterFruit(fruit);

            // Assert
            Assert.True(shop.FruitExists("Apple"));
        }

        [Fact]
        public void FruitExists_ShouldReturnFalseIfNotRegistered()
        {
            // Arrange
            var shop = new Shop();

            // Act
            var exists = shop.FruitExists("Banana");

            // Assert
            Assert.False(exists);
        }

        [Fact]
        public void CalculateTotal_ShouldReturnCorrectTotalForOrder()
        {
            // Arrange
            var shop = new Shop();
            var apple = new FruitWithStrategy("Apple", 2.0m, new PerKgPricing());
            var banana = new FruitWithStrategy("Banana", 1.0m, new PerItemPricing());
            shop.RegisterFruit(apple);
            shop.RegisterFruit(banana);
            var order = new Order();
            order.AddItem("Apple", 3); // 2.0 * 3 = 6.0
            order.AddItem("Banana", 2); // 1.0 * 2 = 2.0

            // Act
            var total = shop.CalculateTotal(order);

            // Assert
            Assert.Equal(8.0m, total);
        }
    }

    public class OrderTests
    {
        [Fact]
        public void AddItem_ShouldAddNewItem()
        {
            // Arrange
            var order = new Order();

            // Act
            order.AddItem("Apple", 2);

            // Assert
            Assert.True(order.Items.ContainsKey("Apple"));
            Assert.Equal(2, order.Items["Apple"]);
        }

        [Fact]
        public void AddItem_ShouldAccumulateQuantity()
        {
            // Arrange
            var order = new Order();
            order.AddItem("Apple", 2);

            // Act
            order.AddItem("Apple", 3);

            // Assert
            Assert.Equal(5, order.Items["Apple"]);
        }
    }

    public class FruitWithStrategyTests
    {
        [Fact]
        public void CalculatePrice_PerKgPricing_ReturnsCorrectValue()
        {
            // Arrange
            var fruit = new FruitWithStrategy("Apple", 2.0m, new PerKgPricing());

            // Act
            var price = fruit.CalculatePrice(3);

            // Assert
            Assert.Equal(6.0m, price);
        }

        [Fact]
        public void CalculatePrice_PerItemPricing_ReturnsCorrectValue()
        {
            // Arrange
            var fruit = new FruitWithStrategy("Banana", 1.5m, new PerItemPricing());

            // Act
            var price = fruit.CalculatePrice(2.7m);

            // Assert
            Assert.Equal(1.5m * 2, price);
        }

        [Fact]
        public void CalculatePrice_DiscountPerKgPricing_AppliesDiscount()
        {
            // Arrange
            var fruit = new FruitWithStrategy("Cherry", 5.0m, new DiscountPerKgPricing(2, 0.1m));

            // Act
            var priceNoDiscount = fruit.CalculatePrice(2);
            var priceWithDiscount = fruit.CalculatePrice(3);

            // Assert
            Assert.Equal(10.0m, priceNoDiscount); // No discount
            Assert.Equal(13.5m, priceWithDiscount); // 5*3*0.9 = 13.5
        }
    }
}

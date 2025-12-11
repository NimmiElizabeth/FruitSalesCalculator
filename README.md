# Fruit Sales Calculator

A simple C# console application to register fruits with different pricing strategies and calculate the total cost of an order.

## Features

- Register fruits with a name, base price, and pricing strategy:
  - Per Kg
  - Per Item
  - Discount Per Kg (with threshold and discount rate)
- Add fruits and quantities to an order
- Calculate and display the total cost

## Usage

1. Run the application.
2. Enter the fruit name (or 'done' to finish registration).
3. Enter the base price for the fruit.
4. Select a pricing strategy:
   - 1: Per Kg
   - 2: Per Item
   - 3: Discount Per Kg (requires threshold and discount rate)
5. Enter the quantity (kg or count) for the fruit.
6. Repeat for additional fruits or type 'done' to finish.
7. The total cost will be displayed.

## Project Structure

- `Program.cs`: Main entry point and user interaction logic
- `Models/`: Contains models for Fruit, FruitWithStrategy, and Order
- `Pricing/`: Contains pricing strategy interfaces and implementations
- `Shop.cs`: Handles fruit registration and total calculation
- `FruitSalesCalculator.Tests/`: Unit tests for the application

## Build and Run

1. Open the solution in Visual Studio or use the .NET CLI.
2. To build:
   ```powershell
   dotnet build
   ```
3. To run:
   ```powershell
   dotnet run --project FruitSalesCalculator/FruitSalesCalculator.csproj
   ```

## Testing

To run unit tests:

```powershell
dotnet test
```

## Requirements

- .NET 8.0 SDK or later

## License

MIT License

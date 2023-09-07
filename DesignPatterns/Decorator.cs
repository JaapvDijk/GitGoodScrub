//"Merging" the properties together horizontally (unlike vertically like partial classes)

//The result of an "price" prop is the result icecream.price + fries.price.
//fries.price is the result of potato.price + mayo.price.

//Only the props from the shared interfaces can be merged.

public interface ICoffee
{
    string GetDescription();
    double GetCost();
}

public class SimpleCoffee : ICoffee
{
    public string GetDescription()
    {
        return "Simple Coffee";
    }

    public double GetCost()
    {
        return 1.0;
    }
}

public class CoffeeWithMilk : ICoffee
{
    private readonly ICoffee _coffee;

    public CoffeeWithMilk(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public string GetDescription()
    {
        return _coffee.GetDescription() + ", with milk";
    }

    public double GetCost()
    {
        return _coffee.GetCost() + 0.5;
    }
}
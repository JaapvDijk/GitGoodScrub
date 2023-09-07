using System;

//Bridges between two incompatble interface
//Example: calling legacy code

public interface IDoTheNewThing
{
    void PrintNumber(int number);
}

public class Adaptee
{
    public void OutdatedNumberPrinter(string number)
    {
        Console.WriteLine(number);
    }
}

//The bridge
public class Adapter : IDoTheNewThing
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public void PrintNumber(int number)
    {
        _adaptee.OutdatedNumberPrinter(number.ToString());
    }
}
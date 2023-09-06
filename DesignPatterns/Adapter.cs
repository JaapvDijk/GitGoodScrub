using System;

//Bridges between two incompatble interface
//Example: reusing legacy code

//The new interface
public interface ITarget
{
    void PrintNumber(int number);
}

//The old interface
public class Adaptee
{
    public void OutdatedNumberPrinter(string number)
    {
        Console.WriteLine(number);
    }
}

//The bridge
public class Adapter : ITarget
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
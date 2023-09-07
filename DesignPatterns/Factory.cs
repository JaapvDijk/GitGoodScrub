using System;
using System.Collections.Generic;

//Concept: Shipping the logic of creating new instances to a sub class. 
//Goal: Prevent complex instance creation across the code. ~Reusable instance creation


public interface IGreet
{
    void Greet();
}

public class GreetingBirthDayCousin : IGreet
{
    public void Greet()
    {
        Console.WriteLine("Dis bday be bussin 100% no cap fam fr fr"); //<-- Dispose and terminate
    }
}

public class GreetingBirthDayOldFriend : IGreet
{
    public void Greet()
    {
        Console.WriteLine("Happy birthday, ever heard about extended car insurances?");
    }
}

public class GreetingCasual : IGreet
{
    public void Greet()
    {
        Console.WriteLine("Mogh");
    }
}


public abstract class Greetings
    {
        public List<IGreet> greets {get; protected set; } = new();
        public Greetings()
        {
            CreateGreetings();
        }

        // Factory Method
        public abstract void CreateGreetings();
    }

public sealed class BirthDayGreetFactory : Greetings
{
    public override void CreateGreetings()
    {
        greets.Add(new GreetingBirthDayCousin());
        greets.Add(new GreetingBirthDayOldFriend());
    }
}

public sealed class CasualGreetFactory : Greetings
{
    public override void CreateGreetings()
    {
        greets.Add(new GreetingCasual());
    }
}

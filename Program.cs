namespace GitGoodScrub
{
    class Program
    {
        static void Main()
        {
            // Sample.InterfacesAndVariance();
            // Sample.ExtensionMethods();
            // Sample.AsyncTesting();
            // Sample.Delegate();
            // Sample.FluentValidation();

            new Adapter(new Adaptee()).PrintNumber(42);
            //https://medium.com/@gustavorestani/the-most-used-design-patterns-in-net-development-80d76f9fb6b
        }
    }
}

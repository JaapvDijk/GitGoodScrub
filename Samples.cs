using System;
using System.Threading;
using System.Threading.Tasks;

namespace GitGoodScrub
{
    public static class Sample
    {
        public static void InterfacesAndVariance()
        {
            //Toy extends present: Toy => Present = ok
            Toy toy = new();
            Present present = new();
            present = toy;

            //Generic interfaces..
            IBag<Present> bagPresent = new BagOfPresents();
            IBag<Toy> bagToy = new BagOfToys();

            //Toy => Present = not ok by default.
            IBagRead<Present> covariance = bagToy;
            IBagWrite<Toy> contraviarance = bagPresent;
        }

        public static void ExtensionMethods()
        {
            //The Display extension method works for all IPresent implementations
            Present present = new();
            present.Name = "I'm the base of all presents";
            present.Display();

            Toy toy = new();
            toy.Name = "Toothpick";
            toy.Display();
        }

        public static void Continuation()
        {
            Console.WriteLine($"Getting messages async...");
            
            var msg1 = Async.GetMessageAsyncChain();

            Console.WriteLine($"Message: {msg1}");

            Console.WriteLine($"Getting more...");

            //cToken here since class is static//
            bool cancellationTokenSourceExists = false;
            CancellationTokenSource cTokenSource = new();

            if (cancellationTokenSourceExists) 
            {   
                cTokenSource.Cancel();
                cTokenSource = null;
                
                return;
            }

            cTokenSource = new();

            var msg2 = Async.GetMessageAsyncAwaitCancellable(cTokenSource.Token).Result;

            Console.WriteLine($"Messages: {msg2}");
        }
    }
}

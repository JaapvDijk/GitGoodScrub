using System;

namespace GitGoodScrub
{
    public static class BagExtensionMethods 
    {
        public static void Display(this IPresent present) 
        {
            Console.WriteLine("Displaying present name from extension: " + present.Name);
        }
    }
}
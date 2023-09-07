//Always max a single instance of the type

public sealed class Singleton
{
    private static Singleton instance = null;
    private static readonly object lockObject = new();

    private Singleton() {}

    public static Singleton Instance
    {
        get
        {
            lock(lockObject)
            {
                instance ??= new Singleton();
            }

            return instance;
        }
    }
}
using System.Collections.Generic;

namespace GitGoodScrub
{
    public interface IBagRead<out T>
    {
        IEnumerable<T> Get();
    }

    public interface IBagWrite<in T>
    {
        void Add(T item);
    }

    public interface IBag<T> : IBagRead<T>, IBagWrite<T> where T : IPresent
    {

    }
}

using System.Collections.Generic;

namespace GitGoodScrub
{   
    public class Present : IPresent{}
    public class Toy : Present {}

    public class BagOfPresents : IBag<Present>
    {
        public List<Present> Contents { get; set; } = new();

        public IEnumerable<Present> Get()
        {   
            return (IEnumerable<Present>)Contents;
        }

        public void Add(Present item)
        {
            Contents.Add(item);
        }

        public void IAmPresent() {}
    }

    public class BagOfToys : IBag<Toy>
    {
        public List<Toy> Contents { get; set; } = new();

        public IEnumerable<Toy> Get()
        {
           return (IEnumerable<Toy>)Contents;
        }

        public void Add(Toy item)
        {
            Contents.Add(item);
        }

        public void IAmToy() {}
    }
}

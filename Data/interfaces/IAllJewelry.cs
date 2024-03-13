using jewellery.Data.Models;

namespace jewellery.Data.interfaces
{
    public interface IAllJewelry
    {
        public IEnumerable<Jewelry> jewelries { get; }
        public IEnumerable<Jewelry> getFavJewelry { get; }
        Jewelry getObjectJewelry(int jId);
    }
}

using jewellery.Data.Models;

namespace jewellery.Data.interfaces
{
    public interface ICategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}

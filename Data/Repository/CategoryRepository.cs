using jewellery.Data.interfaces;
using jewellery.Data.Models;

namespace jewellery.Data.Repository
{
    public class CategoryRepository: ICategory
    {
        private readonly AppDBContent appDBContent;
        public CategoryRepository(AppDBContent addDBContent)
        {
            this.appDBContent = addDBContent;
        }

        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}

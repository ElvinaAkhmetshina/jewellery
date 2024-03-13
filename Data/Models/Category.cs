namespace jewellery.Data.Models
{
    public class Category
    {
        public int Id { set; get; }
        public string categoryName { set; get; }
        public string desc { set; get; }


        //у каждой категории есть список товаров которые входят в определенную категорию
        public List<Jewelry> jewelries { set; get; }
    }
}

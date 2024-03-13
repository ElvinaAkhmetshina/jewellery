using jewellery.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;


namespace jewellery.Data
{
    public class AppDBContent: DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }

       
 

        //принимаем в качестве параметра какую либо модель
        //Получаем и устанавливаем данные

        public DbSet<Jewelry> Jewelry { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopItem> ShopItem { get; set; }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }



      
    }
}

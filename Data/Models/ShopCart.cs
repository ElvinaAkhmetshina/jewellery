using Microsoft.EntityFrameworkCore;

namespace jewellery.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;
        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;

        }
        public string ShopCartId { get; set; }
        public List<ShopItem> listShopItems { get; set; }


        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartId = session.GetString("jewelryId") ?? Guid.NewGuid().ToString();
            session.SetString("jewelryId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };

        }


        public void AddToCart(Jewelry jewelry)
        {
            appDBContent.ShopItem.Add(new ShopItem
            {
                ShopJewelryId = ShopCartId,
                jewelry = jewelry,
                price = jewelry.price
            });

            appDBContent.SaveChanges();
        }


        public List<ShopItem> getShopItems()
        {
            return appDBContent.ShopItem.Where(c => c.ShopJewelryId == ShopCartId).Include(s => s.jewelry).ToList();
        }
    }
}

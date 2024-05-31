using jewellery.Data.interfaces;
using jewellery.Data.Models;

namespace jewellery.Data.Repository
{
    public class OrdersRepository: IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
           
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
           
            appDBContent.SaveChanges();
            var items = shopCart.listShopItems;

            foreach (var el in items)
            {

                var orderDetail = new OrderDetail()
                {
                    jewelryId = el.jewelry.id,
                    orderId = order.id,
                    price = el.jewelry.price
                };
                appDBContent.OrderDetail.Add(orderDetail);


            }

            appDBContent.SaveChanges();
        }
    }
}

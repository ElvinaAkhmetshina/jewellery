using jewellery.Data.Models;

namespace jewellery.Data.interfaces
{
    public interface IAllOrders
    {
        //создание заказа
        void CreateOrder(Order order);
    }
}

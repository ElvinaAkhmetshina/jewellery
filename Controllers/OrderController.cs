using jewellery.Data.interfaces;
using jewellery.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace jewellery.Controllers
{
    public class OrderController: Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;


        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }


        //возвращает штмл шаблон в котором будет форма в которую пользователь будет записывать свои данные
        public IActionResult Checkout()
        {
            ModelState.AddModelError("", "У вас должны быть товары для заказа!");
            return View();
        }





        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.listShopItems = shopCart.getShopItems();
           
            if (shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары для заказа!");
                return RedirectToAction("Home");
            }
            
            allOrders.CreateOrder(order);
            return RedirectToAction("Complete");
          

        }



        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }


    }
}

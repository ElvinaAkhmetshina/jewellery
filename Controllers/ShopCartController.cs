using jewellery.Data.interfaces;
using jewellery.Data.Models;
using jewellery.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace jewellery.Controllers
{
    public class ShopCartController: Controller
    {
        private readonly IAllJewelry _jewelryRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllJewelry jewelryRep, ShopCart shopCart)
        {
            _jewelryRep = jewelryRep;
            _shopCart = shopCart;
        }
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };
            return View(obj);
        }




        public RedirectToActionResult addToCart(int id)
        {
            var item = _jewelryRep.jewelries.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}

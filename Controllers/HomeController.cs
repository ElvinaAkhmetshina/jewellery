using jewellery.Data.interfaces;
using jewellery.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace jewellery.Controllers
{
    public class HomeController: Controller
    {
        private readonly IAllJewelry _jewelryRep;


        //

        public HomeController(IAllJewelry jewelryRep)
        {
            _jewelryRep = jewelryRep;
        }


        public ViewResult Index()
        {
            var homeJewelry = new HomeViewModel
            {
                favJewelry = _jewelryRep.getFavJewelry
            };
            return View(homeJewelry);
        }
    }
}

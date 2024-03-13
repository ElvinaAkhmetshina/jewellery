//using jewellery.Data.interfaces;
//using jewellery.Data.Models;
//using jewellery.ViewModels;
//using Microsoft.AspNetCore.Mvc;
//using System.Web.Mvc;
//using Controller = System.Web.Mvc.Controller;
//using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
//using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;
using jewellery.Data.interfaces;
using jewellery.Data.Models;
using jewellery.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace jewellery.Controllers
{
    public class JewelryController: Controller
    {
        private readonly IAllJewelry _allJewelry;
        private readonly ICategory _allCategories;



        //получаем и устанавливаем данные из интерфейсов 
        public JewelryController(IAllJewelry iAllJewelry, ICategory iCat)
        {
            _allJewelry = iAllJewelry;
            _allCategories = iCat;
        }



        ////юрл адрес
        [Route("Jewelry/List")]
        [Route("Jewelry/List/{category}")]

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Jewelry> jewelries = null;

            string currCategory = "";
            //значит мы выводим все автомобили, без категории
            if (string.IsNullOrEmpty(category))
            {
                jewelries = _allJewelry.jewelries.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("Silver", category, StringComparison.OrdinalIgnoreCase))
                {
                    jewelries = _allJewelry.jewelries.Where(i => i.Category.categoryName.Equals("Silver")).OrderBy(i => i.id);
                    currCategory = "Серебро";
                }
                else if (string.Equals("Gold", category, StringComparison.OrdinalIgnoreCase))
                {
                    jewelries = _allJewelry.jewelries.Where(i => i.Category.categoryName.Equals("Gold")).OrderBy(i => i.id);
                    currCategory = "Золото";
                }


            }




            //создаем объект , олл карс значение карс и задаем категорию
            var jewlryObj = new JewelryListViewModel
            {
                allJewelry = jewelries,
                currCategory = currCategory
            };


            ViewBag.Title = "Ювелирные украшения";



            //возвращаем страницу штмл
            return View(jewlryObj);
        }
    }
}

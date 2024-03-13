using jewellery.Data.Models;

namespace jewellery.ViewModels
{
    public class JewelryListViewModel
    {
        //получаем все данные из класса кар для передачи в штмл шаблон
        public IEnumerable<Jewelry> allJewelry { get; set; }
        public string currCategory { get; set; }
    }
}

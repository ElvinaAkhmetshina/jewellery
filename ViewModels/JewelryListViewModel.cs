using jewellery.Data.Models;

namespace jewellery.ViewModels
{
    public class JewelryListViewModel
    {
        
        public IEnumerable<Jewelry> allJewelry { get; set; }
        public string currCategory { get; set; }
    }
}

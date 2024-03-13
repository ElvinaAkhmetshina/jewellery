namespace jewellery.Data.Models
{
    public class ShopItem
    {
        public int id { get; set; }
        public Jewelry jewelry { get; set; }
        public int price { get; set; }
        public string ShopJewelryId { get; set; }
    }
}

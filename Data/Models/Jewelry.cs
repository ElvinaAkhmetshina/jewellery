namespace jewellery.Data.Models
{
    public class Jewelry
    {
        public int id { set; get; }
        public string name { set; get; }
        public string shortDesc { set; get; }
        public string longDesc { set; get; }
        public string img { set; get; }
        public ushort price { set; get; }
        public bool isFavorite { set; get; }
        public bool available { set; get; }
        public int categoryId { set; get; }



        //создаем объект с теми свойствами которые есть в классе категории
        public virtual Category Category { set; get; }
    }
}

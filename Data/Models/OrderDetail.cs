namespace jewellery.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderId { get; set; }


        public int jewelryId { get; set; }

        public uint price { get; set; }
        public virtual Jewelry jewelry { get; set; }


        public virtual Order order { get; set; }
    }
}

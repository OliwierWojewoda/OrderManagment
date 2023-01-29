namespace OrderManagment.Models
{
    public class OrderProducts
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double NettoPrice { get; set; }
        public double BruttoPrice { get; set; }
        public int OrderId { get; set; }
    }
}

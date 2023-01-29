using OrderManagment.Models;

namespace OrderManagment.Dto
{
    public class AddOrderProduct
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
    }
}

using OrderManagment.Models;
using System.Text.Json.Serialization;

namespace OrderManagment.Dto
{
    public class ViewOrderProducts
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double NettoPrice { get; set; }
        public double BruttoPrice { get; set; }
    }
}

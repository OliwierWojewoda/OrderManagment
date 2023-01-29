using System.Reflection.Metadata.Ecma335;

namespace OrderManagment.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double NettoPrice { get; set; }
        public double Vat { get; set; }
        public double BruttoPrice { get; set; }
    }
}

namespace OrderManagment.Dto
{
    public class AddProduct
    {
        public string Name { get; set; } = "ProdcutName";
        public double NettoPrice { get; set; }
        public double Vat { get; set; }
    }
}

namespace OrderManagment.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<OrderProducts> OrderedProducts { get; set; }
        public Contractor Contractor { get; set; }
        public double OverallNetto { get; set; }
        public double OverallBrutto { get; set; }

        public double CalculateNetto(List<OrderProducts> OrderedProducts)
        {
            double netto = 0; 
            foreach(var product in OrderedProducts)
            {
                netto += product.NettoPrice;
            }
            return netto;
        }
        public double CalculateBrutto(List<OrderProducts> OrderedProducts)
        {
            double brutto = 0;
            foreach (var product in OrderedProducts)
            {
                brutto += product.BruttoPrice;
            }
            return brutto;
        }
    }
}

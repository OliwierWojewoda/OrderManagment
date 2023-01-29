using OrderManagment.Models;

namespace OrderManagment.Dto
{
    public class ViewOrder
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Contractor Contractor { get; set; }
        public double OverallNetto { get; set; }
        public double OverallBrutto { get; set; }
        public List<OrderProducts> OrderedProducts { get; set; }
    }
}

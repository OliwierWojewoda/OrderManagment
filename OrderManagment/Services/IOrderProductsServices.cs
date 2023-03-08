using OrderManagment.Dto;

namespace OrderManagment.Services
{
    public interface IOrderProductsServices
    {
        Task<ViewOrderProducts> GetOrderProductsById(int Id);
        Task<List<ViewOrderProducts>> GetAllOrderProducts();
        Task<List<ViewOrderProducts>> DeleteOrderProducts(int Id);
        Task<List<ViewOrderProducts>> AddOrderProducts(AddOrderProduct newOrderProducts);
        Task<List<ViewOrderProducts>> UpdateOrderProducts(int Id, AddOrderProduct newOrderProducts);
    }
}

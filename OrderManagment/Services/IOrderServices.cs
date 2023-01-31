using OrderManagment.Dto;

namespace OrderManagment.Services
{
    public interface IOrderServices
    {
      Task<List<ViewOrder>> GetAllOrders();
      Task<List<ViewProduct>> GetAllProducts();
      Task<List<ViewProduct>> AddProduct(AddProduct newProduct);
      Task<ViewProduct> GetProductById(int Id);
        Task<List<ViewProduct>> UpdateProduct(int Id, AddProduct newProduct);
        Task<List<ViewProduct>> DeleteProduct(int Id);
        Task<ViewOrderProducts> GetOrderProductsById(int Id);
        Task<List<ViewOrderProducts>> GetAllOrderProducts();
        Task<List<ViewOrderProducts>> DeleteOrderProducts(int Id);
        Task<List<ViewOrderProducts>> AddOrderProducts(AddOrderProduct newOrderProducts);
        Task<List<ViewOrderProducts>> UpdateOrderProducts(int Id, AddOrderProduct newOrderProducts);
        Task<List<ViewOrder>> AddOrder(AddOrder newOrder);
        Task<List<ViewOrder>> DeleteOrder(int Id);
        Task<ViewOrder> GetOrderById(int Id);
        Task<List<ViewOrder>> UpdateOrder(int Id, AddOrder newOrder);
        Task<ViewContractor> GetContractorById(int Id);
        Task<List<ViewContractor>> GetAllContractors();
        Task<List<ViewContractor>> DeleteContractor(int Id);
        Task<List<ViewContractor>> AddContractor(AddContractor newContractor);
        Task<List<ViewContractor>> UpdateContractor(int Id, AddContractor newContractor);
        Task<List<ViewContractor>> SearchContractors(string searchWord);
        Task<List<ViewProduct>> SearchProducts(string searchWord);
    }
}

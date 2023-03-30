using OrderManagment.Dto;

namespace OrderManagment.Services
{
    public interface IProductServices
    {
        Task<List<ViewProduct>> GetAllProducts();
        Task<List<ViewProduct>> AddProduct(AddProduct newProduct);
        Task<ViewProduct> GetProductById(int Id);
        Task<List<ViewProduct>> UpdateProduct(int Id, AddProduct newProduct);
        Task<List<ViewProduct>> DeleteProduct(int Id);
        Task<List<ViewProduct>> SearchProducts(string searchWord);
        Task<List<ProductWithStats>> GetTopSaledProducts();
    }
}

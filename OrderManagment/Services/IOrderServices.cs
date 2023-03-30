using OrderManagment.Dto;

namespace OrderManagment.Services
{
    public interface IOrderServices
    {
        Task<List<ViewOrder>> GetAllOrders();
        Task<List<ViewOrder>> AddOrder(AddOrder newOrder);
        Task<List<ViewOrder>> DeleteOrder(int Id);
        Task<ViewOrder> GetOrderById(int Id);
        Task<List<ViewOrder>> UpdateOrder(int Id, AddOrder newOrder);
        Task<List<OrderWithStats>> GetTopOrdersByMoneySpent();
    }
}

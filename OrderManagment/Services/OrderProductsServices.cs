using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderManagment.Data;
using OrderManagment.Dto;
using OrderManagment.Models;

namespace OrderManagment.Services
{
    public class OrderProductsServices : IOrderProductsServices
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public OrderProductsServices(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ViewOrderProducts> GetOrderProductsById(int Id)
        {
            var orderproduct = await _context.OrderProducts.Include(c => c.Product).FirstOrDefaultAsync(c => c.Id == Id);
            var result = _mapper.Map<ViewOrderProducts>(orderproduct);
            return result;
        }
        public async Task<List<ViewOrderProducts>> GetAllOrderProducts()
        {
            return await _context.OrderProducts.Include(c => c.Product).Select(c => _mapper.Map<ViewOrderProducts>(c)).ToListAsync();
        }
        public async Task<List<ViewOrderProducts>> DeleteOrderProducts(int Id)
        {
            OrderProducts orderProducts = _context.OrderProducts.First(c => c.Id == Id);
            _context.OrderProducts.Remove(orderProducts);
            await _context.SaveChangesAsync();
            return await _context.OrderProducts.Select(c => _mapper.Map<ViewOrderProducts>(c)).ToListAsync();
        }
        public async Task<List<ViewOrderProducts>> AddOrderProducts(AddOrderProduct newOrderProducts)
        {
            OrderProducts orderProducts = _mapper.Map<OrderProducts>(newOrderProducts);
            orderProducts.Product = _context.Products.FirstOrDefault(c => c.Id == newOrderProducts.ProductId);
            orderProducts.NettoPrice = orderProducts.Product.NettoPrice * orderProducts.Quantity;
            orderProducts.BruttoPrice = orderProducts.Product.BruttoPrice * orderProducts.Quantity;
            await _context.OrderProducts.AddAsync(orderProducts);
            await _context.SaveChangesAsync();
            return await _context.OrderProducts.Include(c => c.Product).Select(c => _mapper.Map<ViewOrderProducts>(c)).ToListAsync();
        }
        public async Task<List<ViewOrderProducts>> UpdateOrderProducts(int Id, AddOrderProduct newOrderProducts)
        {
            var orderProducts = _context.OrderProducts.Find(Id);
            _mapper.Map(newOrderProducts, orderProducts);
            orderProducts.Product = _context.Products.Find(newOrderProducts.ProductId);
            orderProducts.NettoPrice = orderProducts.Product.NettoPrice * orderProducts.Quantity;
            orderProducts.BruttoPrice = orderProducts.Product.BruttoPrice * orderProducts.Quantity;
            await _context.SaveChangesAsync();
            return await _context.OrderProducts.Include(c => c.Product).Select(c => _mapper.Map<ViewOrderProducts>(c)).ToListAsync();
        }
    }
}

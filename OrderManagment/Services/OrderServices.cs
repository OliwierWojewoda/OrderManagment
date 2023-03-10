using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderManagment.Data;
using OrderManagment.Dto;
using OrderManagment.Models;

namespace OrderManagment.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public OrderServices(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ViewOrder>> GetAllOrders()
        {
            var orders = await _context.Orders.Include(c => c.OrderedProducts).ThenInclude(t => t.Product).Include(c => c.Contractor).ToListAsync();
            foreach (var order in orders)
            {
                order.OverallBrutto = order.CalculateBrutto(order.OrderedProducts);
                order.OverallNetto = order.CalculateNetto(order.OrderedProducts);
            }
            return await _context.Orders.Include(c => c.OrderedProducts).ThenInclude(t => t.Product).Include(c => c.Contractor).Select(c => _mapper.Map<ViewOrder>(c)).ToListAsync();
        }
        public async Task<ViewOrder> GetOrderById(int Id)
        {
            var order = await _context.Orders.Include(c => c.OrderedProducts).ThenInclude(t => t.Product).Include(c => c.Contractor).FirstOrDefaultAsync(c => c.Id == Id);
            order.OverallBrutto = order.CalculateBrutto(order.OrderedProducts);
            order.OverallNetto = order.CalculateNetto(order.OrderedProducts);
            var result = _mapper.Map<ViewOrder>(order);
            return result;
        }
        public async Task<List<ViewOrder>> DeleteOrder(int Id)
        {
            Order order = _context.Orders.First(c => c.Id == Id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return await _context.Orders.Include(c => c.OrderedProducts).ThenInclude(t => t.Product).Include(c => c.Contractor).Select(c => _mapper.Map<ViewOrder>(c)).ToListAsync();
        }
        public async Task<List<ViewOrder>> AddOrder(AddOrder newOrder)
        {
            Order order = _mapper.Map<Order>(newOrder);
            order.Contractor = _context.Contractors.First(c => c.Id == newOrder.ContractorId);
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return await _context.Orders.Include(c => c.OrderedProducts).ThenInclude(t => t.Product).Include(c => c.Contractor).Select(c => _mapper.Map<ViewOrder>(c)).ToListAsync();
        }
        public async Task<List<ViewOrder>> UpdateOrder(int Id, AddOrder newOrder)
        {
            var order = _context.Orders.Find(Id);
            order.Contractor = _context.Contractors.First(c => c.Id == newOrder.ContractorId);
            await _context.SaveChangesAsync();
            return await _context.Orders.Include(c => c.OrderedProducts).ThenInclude(t => t.Product).Include(c => c.Contractor).Select(c => _mapper.Map<ViewOrder>(c)).ToListAsync();
        } 
         
      
    }
}

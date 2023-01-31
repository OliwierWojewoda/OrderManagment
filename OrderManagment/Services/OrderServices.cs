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

        public async Task<ViewProduct> GetProductById(int Id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == Id);
            var result = _mapper.Map<ViewProduct>(product);
            return result;
        }
        public async Task<List<ViewProduct>> GetAllProducts()
        {
            return await _context.Products.Select(c => _mapper.Map<ViewProduct>(c)).ToListAsync();
        }
        public async Task<List<ViewProduct>> DeleteProduct(int Id)
        {
            Product product = _context.Products.First(c => c.Id == Id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return await _context.Products.Select(c => _mapper.Map<ViewProduct>(c)).ToListAsync();
        }
        public async Task<List<ViewProduct>> AddProduct(AddProduct newProduct)
        {
            Product product = _mapper.Map<Product>(newProduct);
            product.BruttoPrice = product.NettoPrice + (product.NettoPrice * product.Vat);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return await _context.Products.Select(c => _mapper.Map<ViewProduct>(c)).ToListAsync();
        }
        public async Task<List<ViewProduct>> UpdateProduct(int Id, AddProduct newProduct)
        {
            var product = _context.Products.Find(Id);
            product.BruttoPrice = newProduct.NettoPrice + (newProduct.NettoPrice * newProduct.Vat);
            _mapper.Map(newProduct, product);
            await _context.SaveChangesAsync();
            return await _context.Products.Select(c => _mapper.Map<ViewProduct>(c)).ToListAsync();
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
        public async Task<ViewContractor> GetContractorById(int Id)
        {
            var contractor = await _context.Contractors.FirstOrDefaultAsync(c => c.Id == Id);
            var result = _mapper.Map<ViewContractor>(contractor);
            return result;
        }
        public async Task<List<ViewContractor>> GetAllContractors()
        {
            return await _context.Contractors.Select(c => _mapper.Map<ViewContractor>(c)).ToListAsync();
        }      
        public async Task<List<ViewContractor>> DeleteContractor(int Id)
        {
            Contractor contractor = _context.Contractors.First(c => c.Id == Id);
            _context.Contractors.Remove(contractor);
            await _context.SaveChangesAsync();
            return await _context.Contractors.Select(c => _mapper.Map<ViewContractor>(c)).ToListAsync();
        }
        public async Task<List<ViewContractor>> AddContractor(AddContractor newContractor)
        {
            Contractor contractor = _mapper.Map<Contractor>(newContractor);
            await _context.Contractors.AddAsync(contractor);
            await _context.SaveChangesAsync();
            return await _context.Contractors.Select(c => _mapper.Map<ViewContractor>(c)).ToListAsync();
        }
        public async Task<List<ViewContractor>> UpdateContractor(int Id, AddContractor newContractor)
        {
            var contractor = _context.Contractors.Find(Id);
            _mapper.Map(newContractor, contractor);
            await _context.SaveChangesAsync();
            return await _context.Contractors.Select(c => _mapper.Map<ViewContractor>(c)).ToListAsync();
        }
    }
}

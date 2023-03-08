using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderManagment.Data;
using OrderManagment.Dto;
using OrderManagment.Models;

namespace OrderManagment.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public ProductServices(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
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
        public async Task<List<ViewProduct>> SearchProducts(string searchWord)
        {
            searchWord.ToLower();
            var products = await _context.Products.Select(c => _mapper.Map<ViewProduct>(c)).ToListAsync();
            var result = new List<ViewProduct>();
            foreach (var product in products)
            {
                if (product.Id.ToString().Contains(searchWord) || product.Name.ToLower().Contains(searchWord))
                {
                    result.Add(product);
                }
            }
            return result;
        }
    }
}

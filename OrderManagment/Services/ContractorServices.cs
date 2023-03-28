using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderManagment.Data;
using OrderManagment.Dto;
using OrderManagment.Models;

namespace OrderManagment.Services
{
    public class ContractorServices : IContractorServices
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public ContractorServices(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
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
        public async Task<List<ViewContractor>> SearchContractors(string searchWord)
        {
            searchWord.ToLower();
            var contractors = await _context.Contractors.Select(c => _mapper.Map<ViewContractor>(c)).ToListAsync();
            var result = new List<ViewContractor>();
            foreach (var contractor in contractors)
            {
                if (contractor.Id.ToString().Contains(searchWord) || contractor.Name.ToLower().Contains(searchWord))
                {
                    result.Add(contractor);
                }
            }
            return result;
        }
        public async Task<List<ContractorWithStats>> TopContractors()
        {
            var result = await _context.Contractors.FromSqlRaw("select Contractors.Id,Max(Contractors.Name) as Name,Max(Contractors.City) as City,Max(Contractors.Address) as Address,Max(Contractors.PostalCode) as PostalCode,Sum(OrderProducts.Quantity*OrderProducts.NettoPrice) as MoneySpent from Contractors join Orders on Orders.ContractorId = Contractors.Id join OrderProducts on OrderProducts.OrderId = Orders.Id join Products on Products.Id = OrderProducts.ProductId group by Contractors.Id").Select(c => _mapper.Map<ContractorWithStats>(c)).ToListAsync();
            return result;
        }
    }
}

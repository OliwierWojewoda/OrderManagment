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
    }
}

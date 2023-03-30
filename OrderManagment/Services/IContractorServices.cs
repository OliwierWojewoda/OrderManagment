using OrderManagment.Dto;

namespace OrderManagment.Services
{
    public interface IContractorServices
    {
        Task<ViewContractor> GetContractorById(int Id);
        Task<List<ViewContractor>> GetAllContractors();
        Task<List<ViewContractor>> DeleteContractor(int Id);
        Task<List<ViewContractor>> AddContractor(AddContractor newContractor);
        Task<List<ViewContractor>> UpdateContractor(int Id, AddContractor newContractor);
        Task<List<ViewContractor>> SearchContractors(string searchWord);
        Task<List<ContractorWithStats>> TopContractorsByMoneySpent();
    }
}

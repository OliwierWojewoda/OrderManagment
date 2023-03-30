using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagment.Dto;
using OrderManagment.Services;

namespace OrderManagment.Controllers
{
    [Route("api")]
    [ApiController]
    public class ContractorsController : ControllerBase
    {
        private readonly IContractorServices _contracorservice;

        public ContractorsController(IContractorServices contracorservice)
        {
            _contracorservice = contracorservice;
        }
        [HttpGet("Contractors/GetBy{id}")]
        public async Task<ActionResult<ViewContractor>> GetContractorById(int id)
        {
            return Ok(await _contracorservice.GetContractorById(id));

        }
        [HttpGet("Contractors/GetAll")]
        public async Task<ActionResult<List<ViewContractor>>> GetAllContractors()
        {
            return Ok(await _contracorservice.GetAllContractors());

        }
        [HttpPost("Contractors/Add")]
        public async Task<ActionResult<List<ViewContractor>>> AddContractor(AddContractor newContractor)
        {
            return Ok(await _contracorservice.AddContractor(newContractor));
        }
        [HttpPut("Contractors/Update{id}")]
        public async Task<ActionResult<List<ViewContractor>>> UpdateContractor(int id, AddContractor newContractor)
        {
            return Ok(await _contracorservice.UpdateContractor(id, newContractor));
        }
        [HttpDelete("Contractors/Delete{id}")]
        public async Task<ActionResult<List<ViewContractor>>> DeleteContractor(int id)
        {
            return Ok(await _contracorservice.DeleteContractor(id));
        }
        [HttpGet("Contractors/Search{searchWord}")]
        public async Task<ActionResult<List<ViewContractor>>> SearchContractors(string searchWord)
        {
            return Ok(await _contracorservice.SearchContractors(searchWord));
        }
        [HttpGet("Contractors/TopContractorsByMoneySpent")]
        public async Task<ActionResult<List<ContractorWithStats>>> TopContractorsByMoneySpent()
        {
            return Ok(await _contracorservice.TopContractorsByMoneySpent());
        }
    }
}

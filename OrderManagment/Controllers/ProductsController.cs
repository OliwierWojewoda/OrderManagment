using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagment.Dto;
using OrderManagment.Services;

namespace OrderManagment.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        [HttpGet("Products/GetBy{id}")]
        public async Task<ActionResult<ViewProduct>> GetProductById(int id)
        {
            return Ok(await _productServices.GetProductById(id));

        }
        [HttpGet("Products/GetAll")]
        public async Task<ActionResult<List<ViewProduct>>> GetAllProducts()
        {
            return Ok(await _productServices.GetAllProducts());

        }
        [HttpPost("Products/Add")]
        public async Task<ActionResult<List<ViewProduct>>> AddProduct(AddProduct newProduct)
        {
            return Ok(await _productServices.AddProduct(newProduct));

        }
        [HttpPut("Products/Update{id}")]
        public async Task<ActionResult<List<ViewProduct>>> UpdateProduct(int id, AddProduct newProduct)
        {
            return Ok(await _productServices.UpdateProduct(id, newProduct));
        }
        [HttpDelete("Products/Delete{id}")]
        public async Task<ActionResult<List<ViewProduct>>> DeleteProduct(int id)
        {
            return Ok(await _productServices.DeleteProduct(id));
        }
        [HttpGet("Products/Search{searchWord}")]
        public async Task<ActionResult<List<ViewContractor>>> SearchProducts(string searchWord)
        {
            return Ok(await _productServices.SearchProducts(searchWord));
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagment.Dto;
using OrderManagment.Services;

namespace OrderManagment.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderservice;

        public OrdersController(IOrderServices orderservice)
        {
            _orderservice = orderservice;
        }
        [HttpGet("Orders/GetBy{id}")]
        public async Task<ActionResult<ViewOrder>> GetOrderById(int id)
        {
            return Ok(await _orderservice.GetOrderById(id));

        }
        [HttpGet("Orders/GetAll")]
        public async Task<ActionResult<List<ViewOrder>>> GetAllOrders()
        {
            return Ok(await _orderservice.GetAllOrders());

        }
        [HttpPost("Orders/Add")]
        public async Task<ActionResult<List<ViewOrder>>> AddOrder(AddOrder newOrder)
        {
            return Ok(await _orderservice.AddOrder(newOrder));

        }
        [HttpPut("Orders/Update{id}")]
        public async Task<ActionResult<List<ViewProduct>>> UpdateOrder(int id, AddOrder newOrder)
        {
            return Ok(await _orderservice.UpdateOrder(id, newOrder));
        }
        [HttpDelete("Orders/Delete{id}")]
        public async Task<ActionResult<List<ViewOrder>>> DeleteOrder(int id)
        {
            return Ok(await _orderservice.DeleteOrder(id));
        }
        [HttpGet("Products/GetBy{id}")]
        public async Task<ActionResult<ViewProduct>> GetProductById(int id)
        {
            return Ok(await _orderservice.GetProductById(id));

        }
        [HttpGet("Products/GetAll")]
        public async Task<ActionResult<List<ViewProduct>>> GetAllProducts()
        {
            return Ok(await _orderservice.GetAllProducts());

        }     
        [HttpPost("Products/Add")]
        public async Task<ActionResult<List<ViewProduct>>> AddProduct(AddProduct newProduct)
        {
            return Ok(await _orderservice.AddProduct(newProduct));
            
        }
        [HttpPut("Products/Update{id}")]
        public async Task<ActionResult<List<ViewProduct>>> UpdateProduct(int id,AddProduct newProduct)
        {
            return Ok(await _orderservice.UpdateProduct(id,newProduct));
        }
        [HttpDelete("Products/Delete{id}")]
        public async Task<ActionResult<List<ViewProduct>>> DeleteProduct(int id)
        {
            return Ok(await _orderservice.DeleteProduct(id));
        }
        [HttpGet("OrderedProducts/GetBy{id}")]
        public async Task<ActionResult<ViewOrderProducts>> GetOrderProductById(int id)
        {
            return Ok(await _orderservice.GetOrderProductsById(id));

        }
        [HttpGet("OrderedProducts/GetAll")]
        public async Task<ActionResult<List<ViewOrderProducts>>> GetAllOrderProducts()
        {
            return Ok(await _orderservice.GetAllOrderProducts());

        }      
        [HttpPost("OrderedProducts/Add")]
        public async Task<ActionResult<List<ViewOrderProducts>>> AddOrderProducts(AddOrderProduct newOrderProduct)
        {
            return Ok(await _orderservice.AddOrderProducts(newOrderProduct));

        }
        [HttpPut("OrderedProducts/Update{id}")]
        public async Task<ActionResult<List<ViewOrderProducts>>> UpdateOrderProducts(int id, AddOrderProduct newOrderProduct)
        {
            return Ok(await _orderservice.UpdateOrderProducts(id, newOrderProduct));
        }
        [HttpDelete("OrderedProducts/Delete{id}")]
        public async Task<ActionResult<List<ViewOrderProducts>>> DeleteOrderProducts(int id)
        {
            return Ok(await _orderservice.DeleteOrderProducts(id));
        }
        [HttpGet("Contractors/GetBy{id}")]
        public async Task<ActionResult<ViewContractor>> GetContractorById(int id)
        {
            return Ok(await _orderservice.GetContractorById(id));

        }
        [HttpGet("Contractors/GetAll")]
        public async Task<ActionResult<List<ViewContractor>>> GetAllContractors()
        {
            return Ok(await _orderservice.GetAllContractors());

        }
        [HttpPost("Contractors/Add")]
        public async Task<ActionResult<List<ViewContractor>>> AddContractor(AddContractor newContractor)
        {
            return Ok(await _orderservice.AddContractor(newContractor));
        }
        [HttpPut("Contractors/Update{id}")]
        public async Task<ActionResult<List<ViewContractor>>> UpdateContractor(int id, AddContractor newContractor)
        {
            return Ok(await _orderservice.UpdateContractor(id, newContractor));
        }
        [HttpDelete("Contractors/Delete{id}")]
        public async Task<ActionResult<List<ViewContractor>>> DeleteContractor(int id)
        {
            return Ok(await _orderservice.DeleteContractor(id));
        }
        [HttpGet("Contractors/Search{searchWord}")]
        public async Task<ActionResult<List<ViewContractor>>> SearchContractors(string searchWord)
        {
            return Ok(await _orderservice.SearchContractors(searchWord));
        }
        [HttpGet("Products/Search{searchWord}")]
        public async Task<ActionResult<List<ViewContractor>>> SearchProducts(string searchWord)
        {
            return Ok(await _orderservice.SearchProducts(searchWord));
        }
    }
}

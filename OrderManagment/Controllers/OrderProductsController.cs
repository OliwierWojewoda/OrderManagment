using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagment.Dto;
using OrderManagment.Services;

namespace OrderManagment.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrderProductsController : ControllerBase
    {
        private readonly IOrderProductsServices _orderProductsService;

        public OrderProductsController(IOrderProductsServices orderProductsService)
        {
            _orderProductsService = orderProductsService;
        }
        [HttpGet("OrderedProducts/GetBy{id}")]
        public async Task<ActionResult<ViewOrderProducts>> GetOrderProductById(int id)
        {
            return Ok(await _orderProductsService.GetOrderProductsById(id));

        }
        [HttpGet("OrderedProducts/GetAll")]
        public async Task<ActionResult<List<ViewOrderProducts>>> GetAllOrderProducts()
        {
            return Ok(await _orderProductsService.GetAllOrderProducts());

        }
        [HttpPost("OrderedProducts/Add")]
        public async Task<ActionResult<List<ViewOrderProducts>>> AddOrderProducts(AddOrderProduct newOrderProduct)
        {
            return Ok(await _orderProductsService.AddOrderProducts(newOrderProduct));

        }
        [HttpPut("OrderedProducts/Update{id}")]
        public async Task<ActionResult<List<ViewOrderProducts>>> UpdateOrderProducts(int id, AddOrderProduct newOrderProduct)
        {
            return Ok(await _orderProductsService.UpdateOrderProducts(id, newOrderProduct));
        }
        [HttpDelete("OrderedProducts/Delete{id}")]
        public async Task<ActionResult<List<ViewOrderProducts>>> DeleteOrderProducts(int id)
        {
            return Ok(await _orderProductsService.DeleteOrderProducts(id));
        }
    }
}

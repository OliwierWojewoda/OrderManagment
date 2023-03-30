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
        [HttpGet("Orders/GetTopOrdersByIncome")]
        public async Task<ActionResult<List<OrderWithStats>>> GetTopOrdersByIncome()
        {
            return Ok(await _orderservice.GetTopOrdersByIncome());

        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldWideGadgetShop.Core.IServices;
using WorldWideGadgetShop.Core.Models;

namespace WorldWideGadgetShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        
        public OrderController(IOrderService  orderService)
        {
            _orderService = orderService;
        }
        // Create
        [HttpPost]
        public ActionResult<Order> Create([FromBody] Order order)
        {
            try
            {
                return Ok(_orderService.CreateOrder(order));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Read
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAll()
        {
            return _orderService.GetAllOrders();
        }

        [HttpGet ("{id}")]
        public ActionResult<Order> Get(int id)
        {
            return _orderService.GetOrderById(id);
        }
        
        // Update
        [HttpPut("{id}")]
        public ActionResult<Order> Update(int id, [FromBody] Order order)
        {
            try
            {
                if (id != order.Id)
                {
                    return BadRequest("Parameter ID and Order ID has to match.");
                }

                return Ok(_orderService.UpdateOrder(order));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        
        // Delete
        [HttpDelete("{id}")]
        public ActionResult<Order> Delete(int id)
        {
            try
            {
                return Ok(_orderService.DeleteOrderById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
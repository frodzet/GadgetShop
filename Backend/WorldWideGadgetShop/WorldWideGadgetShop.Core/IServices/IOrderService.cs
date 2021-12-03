using System.Collections.Generic;
using WorldWideGadgetShop.Core.Models;

namespace WorldWideGadgetShop.Core.IServices
{
    public interface IOrderService
    {
        // Create
        Order CreateOrder(Order order);
        
        // Read
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        
        // Update
        Order UpdateOrder(Order order);
        
        // Delete
        Order DeleteOrderById(int id);
    }
}
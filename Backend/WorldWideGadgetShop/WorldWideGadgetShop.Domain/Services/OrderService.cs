
using System.Collections.Generic;
using WorldWideGadgetShop.Core.IServices;
using WorldWideGadgetShop.Core.Models;
using WorldWideGadgetShop.Domain.IRepositories;

namespace WorldWideGadgetShop.Domain.Services
{
    public class OrderService : IOrderService
    {
        
        private readonly IOrderRepository _orderRepo;
        
        public OrderService(IOrderRepository  orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public Order CreateOrder(Order order)
        {
            var o = _orderRepo.CreateOrder(order);
            return o;
        }
        
        public Order GetOrderById(int id)
        {
            var o = _orderRepo.GetOrderById(id);
            return o;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepo.GetAllOrders();
        }

        public Order UpdateOrder(Order order)
        {
            var o = _orderRepo.UpdateOrder(order);
            return o;
        }

        public Order DeleteOrderById(int id)
        {
            var o = _orderRepo.DeleteOrderById(id);
            return o;
        }


    }
}
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WorldWideGadgetShop.Core.Models;
using WorldWideGadgetShop.Domain.IRepositories;

namespace WorldWideGadgetShop.SQL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DBContext _ctx;

        public OrderRepository(DBContext ctx)
        {
            _ctx = ctx;
        }

        public Order CreateOrder(Order order)
        {
            _ctx.Attach(order).State = EntityState.Added;
            _ctx.SaveChanges();
            return order;
        }
        
        public Order GetOrderById(int id)
        {
            var o = _ctx.Orders.FirstOrDefault(o => o.Id == id);
            return o;
        }

        public Order UpdateOrder(Order order)
        {
            _ctx.Orders.Attach(order).State = EntityState.Modified;
            _ctx.SaveChanges();
            return order;
        }

        public List<Order> GetAllOrders()
        {
            return _ctx.Orders.ToList();
        }

        public Order DeleteOrderById(int id)
        {
            var o = _ctx.Orders.FirstOrDefault(o => o.Id == id);
            _ctx.Orders.Attach(o).State = EntityState.Deleted;
            _ctx.SaveChanges();
            return o;
        }
    }
}
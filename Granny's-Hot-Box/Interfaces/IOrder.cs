using Granny_s_Hot_Box.Models;
using Microsoft.AspNetCore.Mvc;

namespace Granny_s_Hot_Box.Interfaces
{
    public interface IOrder
    {
        public List<Order> GetAllOrders();
        public Order? GetOrderById(int id);
        public Order CreateOrder(Order order);
        public void UpdateOrder(Order order);
    }
}

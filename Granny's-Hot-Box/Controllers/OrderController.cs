using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Granny_s_Hot_Box.Models;
using Granny_s_Hot_Box.Interfaces;
using Granny_s_Hot_Box.Repositories;

namespace Granny_s_Hot_Box.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrder _orderRepo;


        public OrderController(
            IOrder orderRepository)

        {
            _orderRepo = orderRepository;

        }

        //GET: OrderController
        [HttpGet]
        public ActionResult GetAllOrders()
        {

            var orders = _orderRepo.GetAllOrders();
            return Ok(orders);

        }

        ////GET: User/Details/5
        [HttpGet("{id}")]
        public ActionResult GetOrderById(int id)
        {
            var user = _orderRepo.GetOrderById(id);
            return Ok(user);
        }

        ////POST api/Create
        [HttpPost]
        public ActionResult CreateUser(Order order)
        {
            var newOrder = _orderRepo.CreateOrder(order);
            return Ok(newOrder);
        }

        ////PUT: UserController/Edit/5
        [HttpPut("{id}")]
        public void Put(Order order)
        {
            _orderRepo.UpdateOrder(order);
        }

    }
}

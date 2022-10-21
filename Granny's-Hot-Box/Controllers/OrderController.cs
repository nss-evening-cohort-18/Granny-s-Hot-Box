using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Granny_s_Hot_Box.Controllers
{
    public class OrderController : Controller
    {
        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}



//using DogGo.Models;
//using DogGo.Models.ViewModels;
//using DogGo.Repositories;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;

//namespace DogGo.Controllers
//{
//    public class ordersController : Controller
//    {
//        private readonly IOrderRepository _orderRepo;
//        private readonly IDogRepository _dogRepo;
//        private readonly IWalkerRepository _walkerRepo;
//        private readonly INeighborhoodRepository _neighborhoodRepo;

//        public OrdersController(
//            IOrderRepository orderRepository,
//            IDogRepository dogRepository,
//            IWalkerRepository walkerRepository,
//            INeighborhoodRepository neighborhoodRepository)
//        {
//            _orderRepo = orderRepository;
//            _dogRepo = dogRepository;
//            _walkerRepo = walkerRepository;
//            _neighborhoodRepo = neighborhoodRepository;
//        }



//        GET: OrdersController
//        public ActionResult Index()
//        {
//            var orders = _orderRepo.GetAllOrders();
//            return View(orders);
//        }

//        GET: Orders/Details/5
//        public ActionResult Details(int id)
//        {
//            Order order = _orderRepo.GetOrderById(id);
//            List<Dog> dogs = _dogRepo.GetDogsByOrderId(order.Id);
//            List<Walker> walkers = _walkerRepo.GetWalkersInNeighborhood(order.NeighborhoodId);

//            ProfileViewModel vm = new ProfileViewModel()
//            {
//                Order = order,
//                Dogs = dogs,
//                Walkers = walkers
//            };

//            return View(vm);
//        }

//        GET: OrdersController/Create
//        public ActionResult Create()
//        {
//            List<Neighborhood> neighborhoods = _neighborhoodRepo.GetAll();

//            OrderFormViewModel vm = new OrderFormViewModel()
//            {
//                Order = new Order(),
//                Neighborhoods = neighborhoods
//            };

//            return View(vm);
//        }

//        POST: OrdersController/Create
//       [HttpPost]
//       [ValidateAntiForgeryToken]
//        public ActionResult Create(Order newOrder)
//        {
//            try
//            {
//                _orderRepo.AddOrder(newOrder);
//                return RedirectToAction(nameof(Index));
//            }
//            catch (Exception ex)
//            {
//                return View(newOrder);
//            }
//        }

//        GET: OrdersController/Edit/5
//        public ActionResult Edit(int id)
//        {
//            Order? order = _orderRepo.GetOrderById(id);

//            if (order == null)
//            {
//                return NotFound();
//            }

//            return View(order);
//        }

//        POST: OrdersController/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, Order order)
//        {
//            try
//            {
//                _orderRepo.UpdateOrder(order);

//                return RedirectToAction(nameof(Index));
//            }
//            catch (Exception ex)
//            {
//                return View(order);
//            }
//        }

//        GET: OrdersController/Delete/5
//        public ActionResult Delete(int id)
//        {
//            Order? order = _orderRepo.GetOrderById(id);

//            return View(order);
//        }

//        POST: Orders/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, Order order)
//        {
//            try
//            {
//                _orderRepo.DeleteOrder(id);

//                return RedirectToAction("Index");
//            }
//            catch (Exception ex)
//            {
//                return View(order);
//            }
//        }
//        LOGIN GET
//        public ActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<ActionResult> Login(LoginViewModel viewModel)
//        {
//            Order order = _orderRepo.GetOrderByEmail(viewModel.Email);

//            if (order == null)
//            {
//                return Unauthorized();
//            }

//            List<Claim> claims = new List<Claim>
//    {
//        new Claim(ClaimTypes.NameIdentifier, order.Id.ToString()),
//        new Claim(ClaimTypes.Email, order.Email),
//        new Claim(ClaimTypes.Role, "DogOrder"),
//    };

//            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
//                claims, CookieAuthenticationDefaults.AuthenticationScheme);

//            await HttpContext.SignInAsync(
//                CookieAuthenticationDefaults.AuthenticationScheme,
//                new ClaimsPrincipal(claimsIdentity));

//            return RedirectToAction("Index", "Dogs");
//        }

//        public async Task<ActionResult> Logout()
//        {
//            await HttpContext.SignOutAsync();
//            return RedirectToAction("Index", "Home");
//        }



//    }
//}
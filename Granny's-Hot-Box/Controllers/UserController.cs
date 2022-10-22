using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Granny_s_Hot_Box.Repositories;
using Granny_s_Hot_Box.Models;
using Granny_s_Hot_Box.Interfaces;


namespace Granny_s_Hot_Box.Controllers
{
    public class userController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly IUserPaymentsRepository _userPaymentsRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IMealProductRepository _mealProductRepo;

        public UserController(
            IUserRepository userRepository,
            IUserPaymentsRepository userPaymentsRepository,
            IOrderRepository orderRepository,
            IMealProductRepository mealProductRepository)
        {
            _userRepo = userRepository;
            _userPaymentsRepo = userPaymentsRepository;
            _orderRepo = orderRepository;
            _mealProductRepo = mealProductRepository;
        }



        //GET: UserController
        public ActionResult Index()
        {
            var user = _userRepo.GetAllUser();
            
        }

        //GET: User/Details/5
        public ActionResult Details(int id)
        {
            User user = _userRepo.GetUserById(id);
            
        }

        //GET: UserController/Create
        public ActionResult Create()
        {
            List<User> users = _userRepo.GetAll();

        }

        //POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User newUser)
        {
                _userRepo.AddUser(newUser);
                return RedirectToAction(nameof(Index));
           
        }

        //GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            User? user = _userRepo.GetuserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        //POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
           
            {
                _userRepo.UpdateUser(user);

                return RedirectToAction(nameof(Index));
            }
            
        }

        //GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            User? user = _userRepo.GetUserById(id);

            return user;
        }

        //POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User User)
        {
          
            {
                _UserRepo.DeleteUser(id);

                return RedirectToAction("Index");
            }
           
        }
        //LOGIN GET
        public ActionResult Login()
        {
            
        }

        [HttpPost]
        public async Task<ActionResult> Login()
        {
            User user = _userRepo.GetUserByEmail();

            if (user == null)
            {
                return Unauthorized();
            }

            List<Claim> claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Role, "DogUser"),
    };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Dogs");
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



    }
}



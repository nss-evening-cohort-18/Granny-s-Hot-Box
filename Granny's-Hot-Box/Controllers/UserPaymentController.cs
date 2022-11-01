using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Granny_s_Hot_Box.Interfaces;

namespace Granny_s_Hot_Box.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UserPaymentController : Controller
    {
        private readonly IUserPayment _userPaymentRepo;


        public UserPaymentController(
            IUserPayment userPaymentRepository)

        {
            _userPaymentRepo = userPaymentRepository;

        }
        // GET: UserPaymentController
        public IActionResult Index()
        {
            return View();
        }

        // GET: UserPaymentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: UserPaymentController/Create
        [HttpPost]
        public ActionResult Create()
        {
            return View();
        }
        // PUT: UserPaymentController/Edit/5
        [HttpPut]
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
    }
}


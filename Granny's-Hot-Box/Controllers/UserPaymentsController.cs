using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Granny_s_Hot_Box.Controllers
{
    public class UserPaymentsController : Controller
    {
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


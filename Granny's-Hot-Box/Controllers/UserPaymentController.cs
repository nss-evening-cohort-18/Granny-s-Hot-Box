using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Granny_s_Hot_Box.Controllers
{
    public class UserPaymentController : Controller
    {
        // GET: UserPaymentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserPaymentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserPaymentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserPaymentController/Create
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

        // GET: UserPaymentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserPaymentController/Edit/5
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

        // GET: UserPaymentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserPaymentController/Delete/5
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

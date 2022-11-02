using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Granny_s_Hot_Box.Interfaces;
using Granny_s_Hot_Box.Repositories;
using Granny_s_Hot_Box.Models;

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

        ////POST api/Create
        [HttpPost]
        public ActionResult CreateUserPayment(UserPayment userPayment)
        {
            var newUserPayment = _userPaymentRepo.CreateUserPayment(userPayment);
            return Ok(newUserPayment);
        }

    }
}




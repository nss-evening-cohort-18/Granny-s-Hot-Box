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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUser _userRepo;


        public UserController(
            IUser userRepository)

        {
            _userRepo = userRepository;

        }

        //GET: UserController
        [HttpGet]
        public List<User>? Get()
        {
            return _userRepo.GetAllUsers();


        }

        //GET: User/Details/5
        [HttpGet("{id}")]
        public User Details(int id)
        {
            return _userRepo.GetUserById(id);
        }

        //POST api/Create
        [HttpPost]
        public void PostUser(User user)
        {
            _userRepo.CreateUser(user);
        }

        //PUT: UserController/Edit/5
        [HttpPut("{id}")]
        public void Put(User user)
        {
            _userRepo.UpdateUser(user);
        }

        //POST: UserController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete()
        //{
        //   
        //}
        //




    }
}


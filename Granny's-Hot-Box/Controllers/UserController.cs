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
        public ActionResult Get()
        {

            var users = _userRepo.GetAllUsers();
            return Ok(users);
         
        }

        //GET: User/Details/5
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var user2 = User;
            var user = _userRepo.GetUserById(id);
            return Ok(user);
        }

        //POST api/Create
        [HttpPost]
        public ActionResult PostUser(User user)
        {
           var newUser =  _userRepo.CreateUser(user);
           return Ok(newUser);
        }

        //PUT: UserController/Edit/5
        [HttpPut("{id}")]
        public void Put(User user)
        {
            _userRepo.UpdateUser(user);
        }






    }
}


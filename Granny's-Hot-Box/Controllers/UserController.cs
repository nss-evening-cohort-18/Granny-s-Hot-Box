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
        //public ActionResult Details(int id)
        //{
        //    User user = _userRepo.GetUserById(id);


        //}

        //GET: UserController/Create
        //public ActionResult Create()
        //{
  
        //};

       
    }

        //POST: UserController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create()
        //{
        //   
        //}

        //GET: UserController/Edit/5
        //public ActionResult Edit()
        //{
        //    
        //}

        //POST: UserController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit()
        //{
        //    
        //}

        //GET: UserController/Delete/5
        //public ActionResult Delete()
        //{
        //    
        //}

        //POST: User/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete()
        //{
        //   
        //}
        //
    



    }


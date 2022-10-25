using Granny_s_Hot_Box.Interfaces;
using Granny_s_Hot_Box.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Granny_s_Hot_Box.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealProductController : ControllerBase
    {
        private readonly IMealProduct _mealProductRepo;
            

        public MealProductController(IMealProduct mealProductRepository)
        {
            _mealProductRepo = mealProductRepository;
        }



        // GET: api/<MealProductController>
        [HttpGet]
        public List<MealProduct> GetAll()
        {
            return _mealProductRepo.GetAllMealProducts() ;
        }

        // GET api/<MealProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MealProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MealProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MealProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

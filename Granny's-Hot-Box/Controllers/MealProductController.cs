using Granny_s_Hot_Box.Interfaces;
using Granny_s_Hot_Box.Models;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Granny_s_Hot_Box.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealProductController
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
            return _mealProductRepo.GetAllMealProducts();
        }

        // GET api/<MealProductController>/5
        [HttpGet("{id}")]
        public MealProduct GetMealProductById(int id)
        {
            return _mealProductRepo.GetMealProductById(id);

        }

        // POST api/<MealProductController>
        [HttpPost]
        public MealProduct CreateMealProduct(MealProduct product)
        {
            var newProduct = _mealProductRepo.CreateMealProduct(product);

            return newProduct;
        }

        // PUT api/<MealProductController>/5
        [HttpPut("{id}")]
        public void UpdateMealProduct(MealProduct product)
        {
            _mealProductRepo.UpdateMealProduct(product);
        }

        // DELETE api/<MealProductController>/5
        [HttpDelete("{id}")]
        public void DeleteMealProduct(int id)

        {
            
            _mealProductRepo.DeleteMealProduct(id);
        }  
         
    }
}

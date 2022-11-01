using Granny_s_Hot_Box.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Granny_s_Hot_Box.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderMealsController : ControllerBase
    {
        private readonly IOrderMeals _OMRepo;


        public OrderMealsController(
            IOrderMeals orderMealsRepo)
        {
            _OMRepo = orderMealsRepo;
        }



        // GET: api/<OrderMealsController>
        [HttpGet]
        public ActionResult GetAllOrderMeals()
        {
            var om = _OMRepo.GetAllOrderMeals();
            return Ok(om);
        }

        // GET api/<OrderMealsController>/5
       /*
        [HttpGet("GetOrderMealsByOrderId/{id}")]
        public ActionResult GetOrderMealsByOrderId(int id)
        {
            var om = _OMRepo.GetOrderMealsByOrderId(id);
            return Ok(om);
        }

        // GET api/<OrderMealsController>/5

        [HttpGet("GetOrderMealsByMealProductId/{id}")]
        public ActionResult GetOrderMealsByMealProductId(int id)
        {
            var om = _OMRepo.GetOrderMealsByMealProductId(id);
            return Ok(om);
        }
       */
      
    }
}

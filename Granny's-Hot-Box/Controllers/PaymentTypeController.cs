using Granny_s_Hot_Box.Interfaces;
using Granny_s_Hot_Box.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Granny_s_Hot_Box.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentType _paymentTypeRepo;

        public PaymentTypeController(IPaymentType ptRepo)
        {
            _paymentTypeRepo = ptRepo;
        }


            // GET: api/<PaymentTypeController>
            [HttpGet]
            public List<PaymentType> GetAllPaymentTypes()
            {

                    return _paymentTypeRepo.GetAllPaymentTypes();
                               
            }


        }
    }

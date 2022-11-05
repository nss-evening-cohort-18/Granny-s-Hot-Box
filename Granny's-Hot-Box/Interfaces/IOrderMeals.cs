using Granny_s_Hot_Box.Models;

namespace Granny_s_Hot_Box.Interfaces
{
    public interface IOrderMeals
    {
        public List <OrderMeals> GetAllOrderMeals();
        public List <OrderMealsViewModel> GetOrderMealsByOrderId(int id);

    
    }
}

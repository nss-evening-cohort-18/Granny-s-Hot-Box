using Granny_s_Hot_Box.Models;

namespace Granny_s_Hot_Box.Interfaces
{
    public interface IOrderMeals
    {
        public List <OrderMeals> GetAllOrderMeals();
       // public OrderMeals GetOrderMealsByOrderId(int id);

      //  public OrderMeals GetOrderMealsByMealProductId(int id);
    }
}

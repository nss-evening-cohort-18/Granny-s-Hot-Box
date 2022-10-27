using Granny_s_Hot_Box.Models;
using Microsoft.AspNetCore.Mvc;

namespace Granny_s_Hot_Box.Interfaces
{
    public interface IMealProduct
    {
        public List<MealProduct> GetAllMealProducts();
        public MealProduct CreateMealProduct(MealProduct product);
        public MealProduct GetMealProductById(int id);
        public void UpdateMealProduct(MealProduct mealProduct);


    }
}

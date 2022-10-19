namespace Granny_s_Hot_Box.Models
{
    public class MealObject
    {

        public int Id { get; set; }
        public string mealName { get; set; }
        public double price { get; set; }
        public int userId { get; set; }
        public string image {get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public bool isForSale { get; set; }

        public bool doItFortheVine { get; set; }
    }
}

namespace Granny_s_Hot_Box.Models
{
    public class MealProduct
    {

        public int Id { get; set; }
        public string MealName { get; set; }
        public double Price { get; set; }
        public int UserId { get; set; }
        public string Image {get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public bool IsForSale { get; set; }

    }
}

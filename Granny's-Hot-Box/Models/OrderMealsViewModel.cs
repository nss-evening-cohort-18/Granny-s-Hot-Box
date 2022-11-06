using System;

namespace Granny_s_Hot_Box.Models
{
    public class OrderMealsViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MealProductId { get; set; }
        public int OrderUserId { get; set; }
        public string? RecipientName { get; set; }
        public string? ShippingAddress { get; set; }
        public int UserPaymentId { get; set; }
        public decimal Total { get; set; }
        public Boolean IsComplete { get; set; }
        public DateTime DateOrdered { get; set; }
        public DateTime DateCompleted { get; set; }
        public string? Message { get; set; }
        public string? MealName { get; set; }
        public decimal Price { get; set; }
        public int SellerId { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public Boolean IsForSale { get; set; }
        public Boolean IsDessert { get; set; }

    }
}

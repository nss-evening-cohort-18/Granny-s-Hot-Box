using Microsoft.VisualBasic;

namespace Granny_s_Hot_Box.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public string? RecipientName { get; set; }
        public string? ShippingAddress { get; set; }
        public bool IsComplete { get; set; }
        public int UserPaymentId { get; set; }
        public DateTime DateOrdered { get; set; }
        public DateTime DateCompleted { get; set; }
        public string? Message { get; set; }

    }
}

namespace Granny_s_Hot_Box.Models
{
    public class OrdersModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Total { get; set; }
        public string RecipientName { get; set; }
        public string ShippingAddress { get; set; }
        public bool isComplete { get; set; }
        public string dateOrdered { get; set; }
        public string dateCompleted { get; set; }
    }
}

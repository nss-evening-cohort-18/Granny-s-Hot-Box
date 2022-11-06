namespace Granny_s_Hot_Box.Models
{
    public class UserPayment
    {

        public int Id { get; set; }
        public string? CardName { get; set; }
        public string BillingAddress { get; set; }
        public string? AccountNum { get; set; }
        public DateTime Expiration { get; set; }
        public string CVV { get; set; }
        public int UserId { get; set; }
        public int PaymentTypeId { get; set; }

    }
}

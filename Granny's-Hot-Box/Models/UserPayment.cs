namespace Granny_s_Hot_Box.Models
{
    public class UserPayment
    {

        public int Id { get; set; }
        public string? CardName { get; set; }
        public string? AccountNum { get; set; }
        public int UserId { get; set; }
        public int PaymentTypeId { get; set; }

    }
}

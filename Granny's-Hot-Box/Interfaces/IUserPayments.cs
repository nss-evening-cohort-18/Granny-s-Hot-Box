using Granny_s_Hot_Box.Models;

namespace Granny_s_Hot_Box.Interfaces
{
    public interface IUserPayment
    {
        public List<UserPayments> GetAllUserPayments();
        public User GetUserPaymentById(int id);
        public void UpdateUserPayment(UserPayments userPayments);
        public void CreateUserPayment(UserPayments userPayments);
    }
}

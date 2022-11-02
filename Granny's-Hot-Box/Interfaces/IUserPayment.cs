using Granny_s_Hot_Box.Models;

namespace Granny_s_Hot_Box.Interfaces
{
    public interface IUserPayments
    {
        public List<UserPayment> GetAllUserPayments();

        public UserPayment CreateUserPayment(UserPayment userPayment);
        
        public UserPayment GetUserPaymentById(int id);
        

        public void UpdateUserPayments(UserPayment userPayment);
        
    }
}

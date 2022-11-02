using Granny_s_Hot_Box.Models;

namespace Granny_s_Hot_Box.Interfaces
{
    public interface IUserPayments
    {
        public List<UserPayment> GetAllUserPayments();
        public void UpdateUserPayments(UserPayment userPayment);
        
    }
}

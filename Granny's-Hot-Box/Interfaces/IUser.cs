using Granny_s_Hot_Box.Models;

namespace Granny_s_Hot_Box.Interfaces
{
    public interface IUser
    {
        public List<User> GetAllUsers();
        public void CreateUser(User user);
    }
}

using Granny_s_Hot_Box.Models;
using Microsoft.AspNetCore.Mvc;

namespace Granny_s_Hot_Box.Interfaces
{
    public interface IUser
    {
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        public User CreateUser(User user);

    }
}

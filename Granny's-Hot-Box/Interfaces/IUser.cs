using Granny_s_Hot_Box.Models;

namespace Granny_s_Hot_Box.Interfaces
{
    public interface IUser
    {
        public List<User> GetAllUsers();
        public User GetUserById(int id);
        //public void AddUser(User user);
        public void UpdateUser(User user);
        //public void DeleteUser(string firebaseId);
        //public User GetByFirebaseId(string firebaseId);

        public void CreateUser(User user);
    }
}

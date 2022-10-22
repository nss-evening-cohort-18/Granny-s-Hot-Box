using Granny_s_Hot_Box.Models;

namespace Granny_s_Hot_Box.Interfaces
{
    public interface UserInterface
    {
        public List<Users> GetAllUsers();
        public void AddUser(Users user);
        public void UpdateUser(Users user);
        public void DeleteUser(string FirebaseId);
        public Users GetByFirebaseId(string FirebaseId);
    }
}

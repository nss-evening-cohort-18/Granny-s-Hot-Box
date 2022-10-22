namespace Granny_s_Hot_Box.Interfaces
{
    public interface IUser
    {
        public List<Users> GetAllUsers();
        public void AddUser(Users user);
        public void UpdateUser(Users user);
        public void DeleteUser(string firebaseId);
        public Users GetByFirebaseId(string firebaseId);
    }
}

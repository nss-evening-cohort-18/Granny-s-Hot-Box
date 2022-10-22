namespace Granny_s_Hot_Box.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string FirebaseId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public bool IsSeller { get; set; }
        public string Bio { get; set; }


        public List <User> UsersList { get; set; }

    }
}

namespace Granny_s_Hot_Box.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string firebaseId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string image { get; set; }
        public bool isSeller { get; set; }
        public string bio { get; set; }

        public List <User> UsersList { get; set; }

    }
}

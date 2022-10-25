using Microsoft.Data.SqlClient;
using Granny_s_Hot_Box.Models;
using Granny_s_Hot_Box.Interfaces;

namespace Granny_s_Hot_Box.Repositories
{
    public class UserRepository : BaseRepository, IUser
    {
        private readonly string _baseSqlSelect = @"SELECT Id,
                                                    FirebaseUserId,
                                                    UserName,
                                                    Email,
                                                    Address,
                                                    Image,
                                                    IsSeller,
                                                    Bio
                                                   FROM [User]";

        public UserRepository(IConfiguration config) : base(config) { }

        public List<User> GetAllUsers()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = _baseSqlSelect;

                    using (var reader = cmd.ExecuteReader())
                    {
                        var results = new List<User>();
                        while (reader.Read())
                        {
                            var user = LoadFromData(reader);

                            results.Add(user);
                        }

                        return results;
                    }
                }
            }
        }

        public void CreateUser(User user)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO [User] (FirebaseUserId, UserName, Email, Address, Image, IsSeller, Bio)
                    OUTPUT INSERTED.ID
                    VALUES (@firebaseId, @userName, @email, @address, @image, @isSeller, @bio);
                ";
                    cmd.Parameters.AddWithValue("@firebaseId", user.FirebaseId);
                    cmd.Parameters.AddWithValue("@userName", user.UserName);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@address", user.Address);
                    cmd.Parameters.AddWithValue("@image", user.Image);
                    cmd.Parameters.AddWithValue("@isSeller", user.IsSeller);
                    cmd.Parameters.AddWithValue("@bio", user.Bio);

                    int id = (int)cmd.ExecuteScalar();

                    user.Id = id;
                }
            }
        }

        private User LoadFromData(SqlDataReader reader)
        {
            return new User
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                FirebaseId = reader.GetString(reader.GetOrdinal("FirebaseUserId")),
                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                Address = reader.GetString(reader.GetOrdinal("Address")),
                Image = reader.GetString(reader.GetOrdinal("Image")),
                IsSeller = reader.GetBoolean(reader.GetOrdinal("IsSeller")),
                Bio = reader.GetString(reader.GetOrdinal("Bio"))
            };
        }

        public void UpdateUser(User user)
        {
            using(SqlConnection conn = Connection)
            {
                conn.Open();

                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            UPDATE User
                            SET
                                UserName = @userName,
                                Email = @email,
                                Address = @address,
                                Image = @image,
                                IsSeller = @isSeller,
                                WHERE FirebaseId = @firebaseId";

                    cmd.Parameters.AddWithValue("@userName", user.UserName);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@address", user.Address);
                    cmd.Parameters.AddWithValue("@image", user.Image);
                    cmd.Parameters.AddWithValue("@isSeller", user.IsSeller);

                    cmd.ExecuteNonQuery();
                }
            }
            
        }
    }
}

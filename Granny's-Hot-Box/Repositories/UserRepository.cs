using Microsoft.Data.SqlClient;
using Granny_s_Hot_Box.Models;

namespace Granny_s_Hot_Box.Repositories
{
    public class UserRepository : BaseRepository
    {
        private readonly string _baseSqlSelect = @"SELECT Id,
                                                    FirebaseId,
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

        private User LoadFromData(SqlDataReader reader)
        {
            return new User
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                FirebaseId = reader.GetString(reader.GetOrdinal("FirebaseId")),
                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                Address = reader.GetString(reader.GetOrdinal("Address")),
                Image = reader.GetString(reader.GetOrdinal("Image")),
                IsSeller = reader.GetBoolean(reader.GetOrdinal("IsSeller")),
                Bio = reader.GetString(reader.GetOrdinal("Bio"))
            };
        }
    }
}

using Granny_s_Hot_Box.Interfaces;
using Granny_s_Hot_Box.Models;
using Microsoft.Data.SqlClient;

namespace Granny_s_Hot_Box.Repositories
{
    public class OrderRepository : BaseRepository, IOrder
    {
        private readonly string _baseSqlSelect = @"SELECT Id,
                                                    UserId,
                                                    Total,
                                                    RecipientName,
                                                    ShippingAddress,
                                                    IsComplete,
                                                    UserPaymentId,
                                                    DateOrdered,
                                                    DateCompleted
                                                   FROM [Order]";

        public OrderRepository(IConfiguration config) : base(config) { }

        public List<Order> GetAllOrders()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = _baseSqlSelect;

                    using (var reader = cmd.ExecuteReader())
                    {
                        var results = new List<Order>();
                        while (reader.Read())
                        {
                            var order = LoadFromData(reader);

                            results.Add(order);
                        }

                        return results;
                    }
                }
            }
        }



        //public User CreateUser(User user)
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //            INSERT INTO [User] (FirebaseUserId, UserName, Email, Address, Image, IsSeller, Bio)
        //            OUTPUT INSERTED.ID
        //            VALUES (@firebaseId, @userName, @email, @address, @image, @isSeller, @bio);
        //        ";
        //            cmd.Parameters.AddWithValue("@firebaseId", user.FirebaseId);
        //            cmd.Parameters.AddWithValue("@userName", user.UserName);
        //            cmd.Parameters.AddWithValue("@email", user.Email);
        //            cmd.Parameters.AddWithValue("@address", user.Address);
        //            cmd.Parameters.AddWithValue("@image", user.Image);
        //            cmd.Parameters.AddWithValue("@isSeller", user.IsSeller);
        //            cmd.Parameters.AddWithValue("@bio", user.Bio);

        //            int id = (int)cmd.ExecuteScalar();

        //            user.Id = id;
        //            return user;
        //        }
        //    }
        //}


        //public User? GetUserById(int id)
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = $"{_baseSqlSelect} WHERE Id" +
        //                $" = @id";

        //            cmd.Parameters.AddWithValue("@id", id);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                User? result = null;
        //                if (reader.Read())
        //                {
        //                    return LoadFromData(reader);
        //                }

        //                return result;

        //            }
        //        }
        //    }
        //}

        //public void UpdateUser(User user)
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //                    UPDATE [User]
        //                    SET
        //                        UserName = @userName,
        //                        Email = @email,
        //                        Address = @address,
        //                        Image = @image,
        //                        IsSeller = @isSeller
        //                    WHERE Id = @id";

        //            cmd.Parameters.AddWithValue("@userName", user.UserName);
        //            cmd.Parameters.AddWithValue("@email", user.Email);
        //            cmd.Parameters.AddWithValue("@address", user.Address);
        //            cmd.Parameters.AddWithValue("@image", user.Image);
        //            cmd.Parameters.AddWithValue("@isSeller", user.IsSeller);
        //            cmd.Parameters.AddWithValue("@id", user.Id);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }

        //}

        private Order LoadFromData(SqlDataReader reader)
        {
            return new Order
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                RecipientName = reader.GetString(reader.GetOrdinal("RecipientName")),
                ShippingAddress = reader.GetString(reader.GetOrdinal("ShippingAddress")),
                IsComplete = reader.GetBoolean(reader.GetOrdinal("IsComplete")),
                UserPaymentId = reader.GetInt32(reader.GetOrdinal("UserPaymentId")),
                DateOrdered = reader.GetDateTime(reader.GetOrdinal("DateOrdered")),
                DateCompleted = reader.GetDateTime(reader.GetOrdinal("DateCompleted"))

            };
        }


    }
}

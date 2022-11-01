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



        public Order CreateOrder(Order order)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO [Order]             (UserId,
                                                    Total,
                                                    RecipientName,
                                                    ShippingAddress,
                                                    IsComplete,
                                                    UserPaymentId,
                                                    DateOrdered,
                                                    DateCompleted)
                    OUTPUT INSERTED.ID
                    VALUES                          (@UserId,
                                                    @Total,
                                                    @RecipientName,
                                                    @ShippingAddress,
                                                    @IsComplete,
                                                    @UserPaymentId,
                                                    @DateOrdered,
                                                    @DateCompleted);
                ";
                    cmd.Parameters.AddWithValue("@userId", order.UserId);
                    cmd.Parameters.AddWithValue("@Total", order.Total);
                    cmd.Parameters.AddWithValue("@RecipientName", order.RecipientName);
                    cmd.Parameters.AddWithValue("@ShippingAddress", order.ShippingAddress);
                    cmd.Parameters.AddWithValue("@IsComplete", order.IsComplete);
                    cmd.Parameters.AddWithValue("@UserPaymentId", order.UserPaymentId);
                    cmd.Parameters.AddWithValue("@DateOrdered", order.DateOrdered);
                    cmd.Parameters.AddWithValue("@DateCompleted", order.DateCompleted);

                    int id = (int)cmd.ExecuteScalar();

                    order.Id = id;
                    return order;
                }
            }
        }


        public Order? GetOrderById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{_baseSqlSelect} WHERE Id" +
                        $" = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Order? result = null;
                        if (reader.Read())
                        {
                            return LoadFromData(reader);
                        }

                        return result;

                    }
                }
            }
        }

        public void UpdateOrder(Order order)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                UPDATE [Order]
                                SET
                                Total = @total,
                                RecipientName = @recipientName,
                                ShippingAddress = @shippingAddress,
                                IsComplete = @isComplete,
                                UserPaymentId = @userPaymentId,
                                DateCompleted = @dateCompleted
                            WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@total", order.Total);
                    cmd.Parameters.AddWithValue("@recipientName", order.RecipientName);
                    cmd.Parameters.AddWithValue("@shippingAddress", order.ShippingAddress);
                    cmd.Parameters.AddWithValue("@isComplete", order.IsComplete);
                    cmd.Parameters.AddWithValue("@userPaymentId", order.UserPaymentId);
                    cmd.Parameters.AddWithValue("@dateCompleted", order.DateCompleted);
                    cmd.Parameters.AddWithValue("@id", order.Id);

                    cmd.ExecuteNonQuery();
                }
            }

        }

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

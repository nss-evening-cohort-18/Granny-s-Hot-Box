using Microsoft.Data.SqlClient;
using Granny_s_Hot_Box.Models;
using Granny_s_Hot_Box.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace Granny_s_Hot_Box.Repositories
{
    public class OrderMealsRepository : BaseRepository, IOrderMeals
    {
        private readonly string _baseSqlSelect = @"SELECT Id,
                                                   orderId,
                                                   mealProductId
                                                   FROM OrderMeals";

        public OrderMealsRepository(IConfiguration config) : base(config) { }

        public List<OrderMeals> GetAllOrderMeals()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = _baseSqlSelect;

                    using (var reader = cmd.ExecuteReader())
                    {
                        var results = new List<OrderMeals>();
                        while (reader.Read())
                        {
                            var product = LoadFromData(reader);

                            results.Add(product);
                        }

                        return results;
                    }
                }
            }
        }

        public OrderMeals CreateOrderMeals(OrderMeals om)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO [OrderMeals] (orderId,mealProductId)
                    OUTPUT INSERTED.ID
                    VALUES (@orderId, @mealProductId);
                ";
                    cmd.Parameters.AddWithValue("@orderId", om.orderId);
                    cmd.Parameters.AddWithValue("@mealProductId", om.mealProductId);

                    int id = (int)cmd.ExecuteScalar();

                    om.Id = id;

                    return om;

                }
            }
        }


        public OrderMealsViewModel? GetOrderMealsByOrderId(int id)

        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{_baseSqlSelect} WHERE Id" +
                        $" = @orderId";

                    cmd.Parameters.AddWithValue("@orderId", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        OrderMealsViewModel? result = null;
                        if (reader.Read())
                        {   
                            return LoadFromData(reader);
                        }

                        return result;

                    }
                }
            }
        }

*/

/*
        public OrderMeals? GetOrderMealsByMealProductId(int id)

        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"{_baseSqlSelect} WHERE Id" +
                        $" = @id";

                    cmd.Parameters.AddWithValue("@mealProductId", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        OrderMeals? result = null;
                        if (reader.Read())
                        {
                            return LoadFromData(reader);
                        }

                        return result;

                    }
                }
            }
        }



*/

        private OrderMeals LoadFromData(SqlDataReader reader)
        {
            return new OrderMeals
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                orderId = reader.GetInt32(reader.GetOrdinal("orderId")),
                mealProductId = reader.GetInt32(reader.GetOrdinal("mealProductId"))

            };
        }
    }

}
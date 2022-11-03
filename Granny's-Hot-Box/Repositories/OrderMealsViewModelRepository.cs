using Microsoft.Data.SqlClient;
using Granny_s_Hot_Box.Models;
using Granny_s_Hot_Box.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace Granny_s_Hot_Box.Repositories
{
    public class OrderMealsViewModelRepository : BaseRepository, IOrderMealsViewModel
    {
        private readonly string _baseSqlSelect = @"SELECT o.Id AS OrderId, mp.Id AS MealProductId, o.UserId, RecipientName, ShippingAddress, UserPaymentId, Total, IsComplete, DateOrdered, DateCompleted, MealName, Price, mp.UserId AS SellerId, [Image], [Description], Quantity, IsForSale 
                                                    FROM ((OrderMeals om
                                                    JOIN [Order] o ON om.OrderId = o.Id)
                                                    JOIN MealProduct mp ON om.MealProductId = mp.Id);";

        public OrderMealsViewModelRepository(IConfiguration config) : base(config) { }



        public OrderMealsViewModel CreateOrderMealsViewModel(OrderMealsViewModel OMVM)
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
                    cmd.Parameters.AddWithValue("@Id", OMVM.Id);
                    cmd.Parameters.AddWithValue("@OrderId", OMVM.OrderId);
                    cmd.Parameters.AddWithValue("@MealProductId", OMVM.MealProductId);
                    cmd.Parameters.AddWithValue("@OrderUserId", OMVM.OrderUserId);
                    cmd.Parameters.AddWithValue("@orderId", OMVM.orderId);
                    cmd.Parameters.AddWithValue("@mealProductId", OMVM.mealProductId);
                    cmd.Parameters.AddWithValue("@orderId", OMVM.orderId);
                    cmd.Parameters.AddWithValue("@mealProductId", OMVM.mealProductId);
                    cmd.Parameters.AddWithValue("@orderId", OMVM.orderId);
                    cmd.Parameters.AddWithValue("@mealProductId", OMVM.mealProductId);

                    int id = (int)cmd.ExecuteScalar();

                    OMVM.Id = id;

                    return OMVM;

                }
            }
        }


        public List<OrderMealsViewModel>? GetOrderMealsByOrderId(int id)

        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @$"SELECT o.Id AS OrderId, mp.Id AS MealProductId, o.UserId, RecipientName, ShippingAddress, UserPaymentId, Total, IsComplete, DateOrdered, DateCompleted, MealName, Price, mp.UserId AS SellerId, [Image], [Description], Quantity, IsForSale 
FROM((OrderMeals om
JOIN[Order] o ON om.OrderId = o.Id)
JOIN MealProduct mp ON om.MealProductId = mp.Id); WHERE Id" +
                        $" = @orderId";

                    cmd.Parameters.AddWithValue("@orderId", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<OrderMealsViewModel>? result = null;
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

        private OrderMealsViewModel LoadFromData(SqlDataReader reader)
        {
            return new OrderMealsViewModel
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                OrderId = reader.GetInt32(reader.GetOrdinal("OrderId")),
                mealProductId = reader.GetInt32(reader.GetOrdinal("mealProductId"))

            };
        }
    }

}
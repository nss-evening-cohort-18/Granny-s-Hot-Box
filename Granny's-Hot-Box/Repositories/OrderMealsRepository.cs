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


        public List <OrderMealsViewModel>? GetOrderMealsByOrderId(int id)

        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @$"SELECT om.Id, o.Id AS OrderId, mp.Id AS MealProductId, o.UserId, RecipientName, 
                                                ShippingAddress, UserPaymentId, Total, IsComplete, DateOrdered, 
                                                DateCompleted, Message, MealName, Price, mp.UserId AS SellerId, [Image], 
                                                [Description], Quantity, IsForSale, IsDessert
                                         FROM((OrderMeals om
                                         JOIN[Order] o ON om.OrderId = o.Id)
                                         JOIN MealProduct mp ON om.MealProductId = mp.Id) 
                                         WHERE OrderId = @orderId";

                    cmd.Parameters.AddWithValue("@orderId", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List <OrderMealsViewModel>? orderMeals = new List<OrderMealsViewModel>();
                        while (reader.Read())
                        {
                            OrderMealsViewModel orderMeal = LoadFromDataTwo(reader);

                            orderMeals.Add(orderMeal);
                        }

                        return orderMeals;
                    }
                }
            }
        }

        private OrderMeals LoadFromData(SqlDataReader reader)
        {
            return new OrderMeals
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                orderId = reader.GetInt32(reader.GetOrdinal("orderId")),
                mealProductId = reader.GetInt32(reader.GetOrdinal("mealProductId"))

            };
        }

        private OrderMealsViewModel LoadFromDataTwo(SqlDataReader reader)
        {
            return new OrderMealsViewModel
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                OrderId = reader.GetInt32(reader.GetOrdinal("OrderId")),
                MealProductId = reader.GetInt32(reader.GetOrdinal("MealProductId")),
                OrderUserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                RecipientName = reader.GetString(reader.GetOrdinal("RecipientName")),
                ShippingAddress = reader.GetString(reader.GetOrdinal("ShippingAddress")),
                UserPaymentId = reader.GetInt32(reader.GetOrdinal("UserPaymentId")),
                Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                IsComplete = reader.GetBoolean(reader.GetOrdinal("IsComplete")),
                DateOrdered = reader.GetDateTime(reader.GetOrdinal("DateOrdered")),
                DateCompleted = reader.GetDateTime(reader.GetOrdinal("DateCompleted")),
                Message = reader.GetString(reader.GetOrdinal("Message")),
                MealName = reader.GetString(reader.GetOrdinal("MealName")),
                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                SellerId = reader.GetInt32(reader.GetOrdinal("SellerId")),
                Image = reader.GetString(reader.GetOrdinal("Image")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                IsForSale = reader.GetBoolean(reader.GetOrdinal("IsForSale")),
                IsDessert = reader.GetBoolean(reader.GetOrdinal("IsDessert"))

            };
        }
    }

}

                      
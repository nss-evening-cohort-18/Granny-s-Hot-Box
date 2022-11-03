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
                    cmd.Parameters.AddWithValue("@OrderId", om.orderId);
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
                    cmd.CommandText = @$"SELECT Id, o.Id AS OrderId, mp.Id AS MealProductId, o.UserId AS OrderUserId, RecipientName, ShippingAddress, UserPaymentId, Total, IsComplete, DateOrdered, DateCompleted, MealName, Price, mp.UserId AS SellerId, [Image], [Description], Quantity, IsForSale 
                                         FROM((OrderMeals om
                                        JOIN[Order] o ON om.OrderId = o.Id)
                                        JOIN MealProduct mp ON om.MealProductId = mp.Id) WHERE Id" +
                        $" = @Id";

                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List <OrderMealsViewModel>? result = new List<OrderMealsViewModel>();
                        while (reader.Read())
                        {   
                            OrderMealsViewModel viewModel = new OrderMealsViewModel();
                            {
                               int Id = reader.GetInt32(reader.GetOrdinal("Id"));
                               int OrderId = reader.GetInt32(reader.GetOrdinal("OrderId"));
                               int  MealProductId = reader.GetInt32(reader.GetOrdinal("mealProductId"));
                               int OrderUserId = reader.GetInt32(reader.GetOrdinal("OrderUserId"));
                               string RecipientName = reader.GetString(reader.GetOrdinal("RecipientName"));
                               string ShippingAddress = reader.GetString(reader.GetOrdinal("ShippingAddress"));
                               int UserPaymentId = reader.GetInt32(reader.GetOrdinal("UserPaymentId"));
                               decimal Total = reader.GetDecimal(reader.GetOrdinal("Total"));
                               Boolean IsComplete = reader.GetBoolean(reader.GetOrdinal("IsComplete"));
                               DateTime DateOrdered = reader.GetDateTime(reader.GetOrdinal("DateOrdered"));
                               DateTime DateCompleted = reader.GetDateTime(reader.GetOrdinal("DateCompleted"));
                               string MealName = reader.GetString(reader.GetOrdinal("MealName"));
                               decimal Price = reader.GetDecimal(reader.GetOrdinal("Price"));
                               int SellerId = reader.GetInt32(reader.GetOrdinal("SellerId"));
                               string Image = reader.GetString(reader.GetOrdinal("Image"));
                               string Description = reader.GetString(reader.GetOrdinal("Description"));
                               int Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                               Boolean IsForSale = reader.GetBoolean(reader.GetOrdinal("IsForSale"));

                            }

                            result.Add(viewModel);
                            
                        }

                        return result;

                    }
                }
            }
        }



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
using Microsoft.Data.SqlClient;
using Granny_s_Hot_Box.Models;
using Granny_s_Hot_Box.Interfaces;

namespace Granny_s_Hot_Box.Repositories
{
    public class MealProductRepository : BaseRepository , IMealProduct
    {
        private readonly string _baseSqlSelect = @"SELECT Id,
                                                    MealName,
                                                    Price,
                                                    UserId,
                                                    Image,
                                                    Description,
                                                    Quantity,
                                                    IsForSale
                                                   FROM MealProduct";

        public MealProductRepository(IConfiguration config) : base(config) { }

        public List<MealProduct> GetAllMealProducts()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = _baseSqlSelect;

                    using (var reader = cmd.ExecuteReader())
                    {
                        var results = new List<MealProduct>();
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

        public MealProduct CreateMealProduct(MealProduct product)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO [MealProduct] (MealName, Price, UserId, Image, Description, Quantity, IsForSale)
                    OUTPUT INSERTED.ID
                    VALUES (@MealName, @Price, @UserId, @Image, @Description, @Quantity, @IsForSale);
                ";
                    cmd.Parameters.AddWithValue("@MealName", product.MealName);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@UserId", product.UserId);
                    cmd.Parameters.AddWithValue("@Image", product.Image);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
                    cmd.Parameters.AddWithValue("@IsForSale", product.IsForSale);

                    int id = (int)cmd.ExecuteScalar();

                    product.Id = id;

                    return product;

                }
            }
        }

        public MealProduct? GetMealProductById(int id)
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
                        MealProduct? result = null;
                        if (reader.Read())
                        {
                            return LoadFromData(reader);
                        }

                        return result;

                    }
                }
            }
        }



        private MealProduct LoadFromData(SqlDataReader reader)
        {
            return new MealProduct
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                MealName = reader.GetString(reader.GetOrdinal("MealName")),
                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                Image = reader.GetString(reader.GetOrdinal("Image")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                IsForSale = reader.GetBoolean(reader.GetOrdinal("IsForSale"))
            };
        }

    }
}

using Microsoft.Data.SqlClient;
using Granny_s_Hot_Box.Models;
using Granny_s_Hot_Box.Interfaces;

namespace Granny_s_Hot_Box.Repositories
{
    public class UserPaymentRepository : BaseRepository, IUserPayments
    {
        private readonly string _baseSqlSelect = @"SELECT Id,
                                                          CardName,
	                                                      AccountNum,
	                                                      UserId,
                                                          PaymentTypeId
                                                          FROM UserPayment";

        public UserPaymentRepository(IConfiguration config) : base(config) { }

        public List<UserPayment> GetAllUserPayments()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = _baseSqlSelect;

                    using (var reader = cmd.ExecuteReader())
                    {
                        var results = new List<UserPayment>();
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
        private UserPayment LoadFromData(SqlDataReader reader)
        {
            return new UserPayment
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                CardName = reader.GetString(reader.GetOrdinal("CardName")),
                AccountNum = reader.GetString(reader.GetOrdinal("AccountNum")),
                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                PaymentTypeId = reader.GetInt32(reader.GetOrdinal("PaymentTypeId"))
                
            };
        }

        public void UpdateUserPayment(UserPayment userPayment)
        {
            using (SqlConnection conn = Connection) 
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //Be sure to double check with other repos
                    cmd.CommandText = @"
                    UPDATE UserPayments
                    SET
                        CardName = @cardName
                        AccountNum = @accountNum
                        UserId = @userId
                        PaymentTypeId = @paymentTypeId
                    WHERE Id = @id
                ";

                    cmd.Parameters.AddWithValue("@cardName", userPayment.CardName);
                    cmd.Parameters.AddWithValue("@accountNum", userPayment.AccountNum);
                    cmd.Parameters.AddWithValue("@userId", userPayment.UserId);
                    cmd.Parameters.AddWithValue("@paymentTypeId", userPayment.PaymentTypeId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

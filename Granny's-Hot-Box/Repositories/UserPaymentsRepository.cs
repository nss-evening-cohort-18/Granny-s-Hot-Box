using Microsoft.Data.SqlClient;
using Granny_s_Hot_Box.Models;
using Granny_s_Hot_Box.Interfaces;
using NuGet.Protocol.Plugins;

namespace Granny_s_Hot_Box.Repositories
{
    public class UserPaymentRepository : BaseRepository, IUserPayment
    {
        private readonly string _baseSqlSelect = @"SELECT Id,
                                                          CardName,
	                                                      AccountNum,
	                                                      UserId,
                                                          PaymentTypeId
                                                          FROM UserPayments";

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
        public UserPayment CreateUserPayment(UserPayment userPayments)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                   INSERT INTO [UserPayments]             (
                                                          CardName,
	                                                      AccountNum,
	                                                      UserId,
                                                          PaymentTypeId
                                                          )
                    OUTPUT INSERTED.ID
                    VALUES                          (
                                                          @CardName,
	                                                      @AccountNum,
	                                                      @UserId,
                                                          @PaymentTypeId
                                                          );
                ";
                    cmd.Parameters.AddWithValue("@CardName", userPayments.CardName);
                    cmd.Parameters.AddWithValue("@AccountNum", userPayments.AccountNum);
                    cmd.Parameters.AddWithValue("@UserId", userPayments.UserId);
                    cmd.Parameters.AddWithValue("@PaymentTypeId", userPayments.PaymentTypeId);


                    int id = (int)cmd.ExecuteScalar();

                    userPayments.Id = id;
                    return userPayments;
                }
            }
        }
    }
}



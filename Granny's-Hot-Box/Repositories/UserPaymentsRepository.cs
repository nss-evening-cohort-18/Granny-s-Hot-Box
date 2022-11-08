using Microsoft.Data.SqlClient;
using Granny_s_Hot_Box.Models;
using Granny_s_Hot_Box.Interfaces;
using NuGet.Protocol.Plugins;
using Google.Api.Gax;

namespace Granny_s_Hot_Box.Repositories
{
    public class UserPaymentRepository : BaseRepository, IUserPayment
    {
        private readonly string _baseSqlSelect = @"SELECT Id,
                                                          CardName,
                                                          BillingAddress,
	                                                      AccountNum,
                                                          Expiration,
                                                          CVV,
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
                            var userPayment = LoadFromData(reader);

                            results.Add(userPayment);
                        }

                        return results;
                    }
                }
            }
        }



        public UserPayment? GetUserPaymentById(int id)

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
                        UserPayment? result = null;
                        if (reader.Read())
                        {
                            return LoadFromData(reader);
                        }

                        return result;

                    }
                }
            }
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
                                                          BillingAddress,
	                                                      AccountNum,
                                                          Expiration,
                                                          CVV,
	                                                      UserId,
                                                          PaymentTypeId
                                                          )
                    OUTPUT INSERTED.ID
                    VALUES                          (
                                                          @CardName,
                                                          @BillingAddress,
	                                                      @AccountNum,
                                                          @Expiration,
                                                          @CVV,
	                                                      @UserId,
                                                          @PaymentTypeId
                                                          );
                ";
                    cmd.Parameters.AddWithValue("@CardName", userPayments.CardName);
                    cmd.Parameters.AddWithValue("@BillingAddress", userPayments.BillingAddress);
                    cmd.Parameters.AddWithValue("@AccountNum", userPayments.AccountNum);
                    cmd.Parameters.AddWithValue("@Expiration", userPayments.Expiration);
                    cmd.Parameters.AddWithValue("@CVV", userPayments.CVV);
                    cmd.Parameters.AddWithValue("@UserId", userPayments.UserId);
                    cmd.Parameters.AddWithValue("@PaymentTypeId", userPayments.PaymentTypeId);


                    int id = (int)cmd.ExecuteScalar();

                    userPayments.Id = id;
                    return userPayments;
                }
            }
        }

        public void UpdateUserPayments(UserPayment userPayment)
        {
            using (SqlConnection conn = Connection) 
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    UPDATE UserPayments
                    SET
                        CardName = @cardName,
                        BillingAddress = @billingAddress,
                        AccountNum = @accountNum,
                        Expiration = @expiration,
                        CVV = @cvv,
                        UserId = @userId,
                        PaymentTypeId = @paymentTypeId
                    WHERE Id = @id";

                    cmd.Parameters.AddWithValue("@cardName", userPayment.CardName);
                    cmd.Parameters.AddWithValue("@BillingAddress", userPayment.BillingAddress);
                    cmd.Parameters.AddWithValue("@accountNum", userPayment.AccountNum);
                    cmd.Parameters.AddWithValue("@Expiration", userPayment.Expiration);
                    cmd.Parameters.AddWithValue("@CVV", userPayment.CVV);
                    cmd.Parameters.AddWithValue("@userId", userPayment.UserId);
                    cmd.Parameters.AddWithValue("@paymentTypeId", userPayment.PaymentTypeId);
                    cmd.Parameters.AddWithValue("@id", userPayment.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        private UserPayment LoadFromData(SqlDataReader reader)
        {
            return new UserPayment
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                CardName = reader.GetString(reader.GetOrdinal("CardName")),
                BillingAddress = reader.GetString(reader.GetOrdinal("BillingAddress")),
                AccountNum = reader.GetString(reader.GetOrdinal("AccountNum")),
                Expiration = reader.GetDateTime(reader.GetOrdinal("Expiration")),
                CVV = reader.GetString(reader.GetOrdinal("CVV")),
                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                PaymentTypeId = reader.GetInt32(reader.GetOrdinal("PaymentTypeId"))
                
            };
        }
    }
}



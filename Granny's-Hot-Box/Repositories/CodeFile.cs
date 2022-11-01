using Microsoft.Data.SqlClient;
using Granny_s_Hot_Box.Models;
using Granny_s_Hot_Box.Interfaces;

namespace Granny_s_Hot_Box.Repositories
{
    public class UserPaymentRepository : BaseRepository
    {
        private readonly string _baseSqlSelect = @"SELECT Id,
                                                          CardName,
	                                                      AccountNum,
	                                                      UserId,
                                                          PaymentTypeId
                                                          FROM UserPayment";

        public UserPaymentRepository(IConfiguration config) : base(config) { }

        public List<User> GetAllUserPayments()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = _baseSqlSelect;

                    using (var reader = cmd.ExecuteReader())
                    {
                        var results = new List<UserPayments>();
                        while (reader.Read())
                        {
                            var user = LoadFromData(reader);

                            results.Add(userPayments);
                        }

                        return results;
                    }
                }
            }
        }


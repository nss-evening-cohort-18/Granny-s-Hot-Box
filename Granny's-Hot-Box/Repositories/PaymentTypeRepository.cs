using Microsoft.Data.SqlClient;
using Granny_s_Hot_Box.Models;
using Granny_s_Hot_Box.Interfaces;


namespace Granny_s_Hot_Box.Repositories
{
    public class PaymentTypeRepository : BaseRepository, IPaymentType
    {
        private readonly string _baseSqlSelect = @"SELECT Id,
                                                    Type
                                                   FROM PaymentType";

        public PaymentTypeRepository(IConfiguration config) : base(config) { }

        public List<PaymentType> GetAllPaymentTypes()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = _baseSqlSelect;

                    using (var reader = cmd.ExecuteReader())
                    {
                        var results = new List<PaymentType>();
                        while (reader.Read())
                        {
                            var pt = LoadFromData(reader);

                            results.Add(pt);
                        }

                        return results;
                    }
                }
            }
        }

      

      private PaymentType LoadFromData(SqlDataReader reader)
        {
            return new PaymentType
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Type = reader.GetString(reader.GetOrdinal("Type")),
               
            };
        }
    }
}

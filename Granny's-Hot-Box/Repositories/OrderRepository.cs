using Granny_s_Hot_Box.Models;

namespace Granny_s_Hot_Box.Repositories
{
    public class OrderRepository
    {
        private readonly IConfiguration _config;

        public OrderRepository(IConfiguration config)
        {
            _config = config;
        }

/*      NATHAN WORKING
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection
            }
        }

        public List<Orders> GetAllOrders
        {
            using (SqlConnection conn = Connection)
            {
                cmd.CommandText = @"
            "
            }
        }
*/
    }
}

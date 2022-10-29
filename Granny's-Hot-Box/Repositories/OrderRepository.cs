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
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection
            }
        }
    }
}

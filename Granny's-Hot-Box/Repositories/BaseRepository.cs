﻿namespace Granny_s_Hot_Box.Repositories
{
    public class BaseRepository
    {
        private readonly string _connectionString;
        protected BaseRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public SqlConnection Connection => new SqlConnection(_connectionString);
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using QuickBasket.Application.Interfaces;
using System.Data;

namespace QuickBasket.Infrastructure.Data
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
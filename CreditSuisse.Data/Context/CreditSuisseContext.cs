using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace CreditSuisse.Data.Context
{
    public class CreditSuisseContext 
    {
        private readonly string _connectionString;
        
        public CreditSuisseContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlConn");            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public SqlConnection SqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }    
}

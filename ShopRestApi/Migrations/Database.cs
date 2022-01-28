using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRestApi.Migrations
{
    public static class Database
    {
        public static void Migrate(string connectionString, string name)
        {
            using var connection = new SqlConnection(connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("name", name);
            if (!connection.Query("SELECT * FROM sys.databases WHERE name = @name", parameters).Any())
            {
                connection.Execute($"CREATE DATABASE {name}");
            }
        }
    }
}

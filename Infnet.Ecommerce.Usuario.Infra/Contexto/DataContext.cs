using System;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Infnet.Ecommerce.Usuario.Infra.Contexto
{
    public class DataContext : IDataContext
    {
        protected readonly IDbConnection connection;

        public DataContext(string connectionString)
        {
            connection = new SqliteConnection(connectionString);
        }

        public void Init()
        {
            var parametros = new DynamicParameters();

            var sql = """
            CREATE TABLE IF NOT EXISTS 
            Users (
                Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                Title TEXT,
                FirstName TEXT,
                LastName TEXT,
                Email TEXT,
                Role INTEGER,
                PasswordHash TEXT
                );
            """;
            connection.Execute(sql);
        }
    }
}

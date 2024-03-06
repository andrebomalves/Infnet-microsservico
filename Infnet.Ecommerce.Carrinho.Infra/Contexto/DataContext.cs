using System.Data;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Infnet.Ecommerce.Carrinho.Infra.Contexto
{
    public class DataContext : IDataContext
    {
        protected readonly IDbConnection connection;

        public DataContext(string connectionString)
        {
            connection = new SqliteConnection(connectionString);
        }
        
        public IDbConnection GetDbConnection()
        {
            return this.connection;
        }

        public void Init()
        {
            var parametros = new DynamicParameters();

            var sql = @"
            CREATE TABLE IF NOT EXISTS 
            Usuarios (
                UsuarioId TEXT NOT NULL PRIMARY KEY,
                Nome TEXT,
                Email TEXT
                );
            ";
            connection.Execute(sql);
        }
    }
}

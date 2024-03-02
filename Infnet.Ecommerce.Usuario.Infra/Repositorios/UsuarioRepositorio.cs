using Dapper;
using Infnet.Ecommerce.Usuario.Dominio.Repositorios;
using Infnet.Ecommerce.Usuario.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Usuario.Infra.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRespositorio
    {
        public UsuarioRepositorio(IDataContext dataContext) : base(dataContext)
        {
        }

        public Dominio.Entidades.Usuario ObterPorId(Guid usuarioId)
        {
            var parans = new DynamicParameters();
            parans.Add("@usuarioId", usuarioId);

            string sql = @"select usuarioId, nome, email from usuarios where usuarioId = @usuarioId;";

            return connection.QueryFirst<Dominio.Entidades.Usuario>(sql, parans);
        }

        public IEnumerable<Dominio.Entidades.Usuario> ObterTodos()
        {
            string sql = @"select usuarioId, nome, email from usuarios;";

            return connection.Query<Dominio.Entidades.Usuario>(sql);
        }

        public void salvar(Dominio.Entidades.Usuario usuario)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into usuarios ");
            sql.Append("(usuarioId, nome, email) ");
            sql.Append("values (@usuarioId, @nome, @email); ");

            connection.Execute(sql.ToString(),usuario);


        }
    }
}

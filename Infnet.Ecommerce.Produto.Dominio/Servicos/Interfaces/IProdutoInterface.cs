using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Produto.Dominio.Servicos.Interfaces
{
    public interface IProdutoInterface
    {
        public void Salvar(Dominio.Entidades.Produto usuario);
        public Dominio.Entidades.Produto ObterPorId(string usuarioId);
        public IEnumerable<Dominio.Entidades.Produto> ObterTodos();
    }
}

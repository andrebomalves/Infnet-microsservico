using Infnet.Ecommerce.Produto.Dominio.Repositorios;
using Infnet.Ecommerce.Produto.Dominio.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Produto.Dominio.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            this.produtoRepositorio = produtoRepositorio;
        }
        public Entidades.Produto ObterPorId(int produtoId)
        {
            return produtoRepositorio.ObterPorId(produtoId);
        }

        public IEnumerable<Entidades.Produto> ObterTodos()
        {
            return produtoRepositorio.ObterTodos();
        }

        public void Salvar(Entidades.Produto produto)
        {
            produtoRepositorio.Salvar(produto);
        }
    }
}

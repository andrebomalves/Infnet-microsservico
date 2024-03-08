using Infnet.Ecommerce.Carrinho.Dominio.Repositorios.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Dominio.Repositorios
{
    public interface IPagamentoRepositorio
    {
        void RegistrarPagamento(PagamentoFiltro pagamentoFiltro);
    }
}

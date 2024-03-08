using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Dominio.Repositorios.Filtro
{
    public class PagamentoFiltro
    {
        public int CestaId { get; set; }
        public string UsuarioId { get; set; }
        public string MeioDePagamento { get; set; }
        public int Parcelas { get; set; }
        public decimal ValorTotal { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Pagamento.Dominio.Entidades
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }
        public int CestaId { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataPagamento { get; set; }
        public StatusPagamento Status { get; set; }
  
    }

    public enum StatusPagamento
    {
        Pendente,
        Aprovado,
        Rejeitado
    }
}

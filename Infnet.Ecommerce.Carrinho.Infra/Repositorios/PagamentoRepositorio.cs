using EasyNetQ;
using Infnet.Ecommerce.Carrinho.Dominio.Repositorios;
using Infnet.Ecommerce.Carrinho.Dominio.Repositorios.Filtro;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Infra.Repositorios
{
    public class PagamentoRepositorio : IPagamentoRepositorio
    {
        public PagamentoRepositorio()
        {
            
        }
        public void RegistrarPagamento(PagamentoFiltro pagamentoFiltro)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost;port=5672;username=guest;password=guest;"))
            {
                bus.PubSub.Publish<PagamentoFiltro>(pagamentoFiltro);
            }
        }
    }
}

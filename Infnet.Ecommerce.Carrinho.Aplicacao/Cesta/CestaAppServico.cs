using AutoMapper;
using Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.DTO;
using Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.Interfaces;
using Infnet.Ecommerce.Carrinho.Dominio.Servicos.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Aplicacao.Cesta
{
    public class CestaAppServico : ICestaAppServico
    {
        private readonly ICestaServico cestaServico;
        private readonly ILogger<CestaAppServico> logger;
        private readonly IMapper mapper;

        public CestaAppServico(ICestaServico cestaServico, ILogger<CestaAppServico> logger, IMapper mapper)
        {
            this.cestaServico = cestaServico;
            this.logger = logger;
            this.mapper = mapper;
        }
        public void AdicionarItemCesta(int cestaId, ItemCestaRequest itemCestaRequest)
        {
            try
            {

            }
            catch (Exception ex )
            {

                throw;
            }
        }

        public void CriarCesta(CestaRequest cestaRequest)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Dominio.Entidades.Cesta RecuperarCestaAbertaPorUsuario(string usuarioId)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            return new Dominio.Entidades.Cesta(usuarioId);
        }

        public int RemoverItemCesta(int itemCestaId)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            return 0;
        }
    }
}

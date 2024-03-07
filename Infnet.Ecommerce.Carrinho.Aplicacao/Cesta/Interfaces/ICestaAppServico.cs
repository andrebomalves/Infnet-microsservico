using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Aplicacao.Cesta.Interfaces
{
    public interface ICestaAppServico
    {
        void CriarCesta(DTO.CestaRequest cestaRequest);
        void AdicionarItemCesta(int cestaId, DTO.ItemCestaRequest itemCestaRequest);

        int RemoverItemCesta(string itemCestaId);

        Dominio.Entidades.Cesta RecuperarCestaAbertaPorUsuario(int usuarioId);
    }
}

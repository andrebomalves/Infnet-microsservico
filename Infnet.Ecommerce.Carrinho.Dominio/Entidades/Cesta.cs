using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Carrinho.Dominio.Entidades
{
    public class Cesta
    {
        public Cesta(string usuarioId)
        {
            Itens = new List<ItemCesta>();
            this.UsuarioId = usuarioId;
            this.Status = StatusCesta.Aberta;
        }
        
        public int CestaId { get; set; }
        public string UsuarioId { get; set; }
        public StatusCesta Status { get; set; }

        public List<ItemCesta> Itens { get; set; }
        public decimal ValorTotal
        {
            get
            {
                return Itens.Sum(item => item.Subtotal);
            }
        }

        
    }

    //Value Object da CestaCompra
    public class ItemCesta
    {
        public int ItemCestaId { get; set; }
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }

        public decimal Subtotal
        {
            get
            {
                return PrecoUnitario * Quantidade;
            }
        }
    }

    public enum StatusCesta
    {
        Aberta = 0,
        AguardandoPgamento,
        Fechada
    }
}

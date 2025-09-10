using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDeClientes
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string ItemPedido { get; set; }
        public decimal Valor { get; set; }
        public DateTime UltimoPedido { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace CarteiraDeClientes
{
    [Serializable]
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; } // Certifique-se de que esta propriedade está definida
        public string Telefone { get; set; }
        public string Endereco { get; set; } // Adicionar endereço
        public DateTime UltimoPedido { get; set; } // Adiciona o campo para o último pedido
    }


}

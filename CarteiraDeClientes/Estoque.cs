using System;
using System.Collections.Generic;

namespace CarteiraDeClientes
{
    // Esta classe representa o arquivo "estoque.json" inteiro
    public class EstoqueGeral
    {
        public int SaldoCheios { get; set; }
        public int SaldoVazios { get; set; }
        public List<MovimentacaoEstoque> Movimentacoes { get; set; }

        // Construtor para garantir que a lista nunca seja nula
        public EstoqueGeral()
        {
            Movimentacoes = new List<MovimentacaoEstoque>();
        }
    }

    // Esta classe representa uma única linha na grade (uma compra ou devolução)
    public class MovimentacaoEstoque
    {
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
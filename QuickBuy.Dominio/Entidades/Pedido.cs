using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string EnderecoCompleto { get; set; }
        public string NumeroEndereco { get; set; }
        public int FormaPagamentoId { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }

        /// <summary>
        /// Um pedidos DEVE ter pelo menos um ou varios itens de Pedidos
        /// </summary>
        public virtual ICollection<ItemPedido> ItensPedido { get; set; }

        public override void Validate()
        {
            LimparMensangensValidacao();

            if (!ItensPedido.Any()) AdicionarCritica("Crítica - Pedido não pode ficar sem Item de pedido");

            if (string.IsNullOrEmpty(CEP)) AdicionarCritica("Crítica - CEP deve estar preenchido");

            if (FormaPagamentoId == 0) AdicionarCritica("Crítica - Não foi Informado a forma de pagamento");
        }
    }
}

using EverisStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisSore
{
    public class Produto : EntidadeBase
    {
        public Produto(string nome, string descricao, decimal valor, int qtdEstoque)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            QtdEstoque = qtdEstoque;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; } = 0;
        public int QtdEstoque { get; private set; }

        public void Ativar() => Ativo = true;

        public void Desativar() => Ativo = false;

        public void DebitarEstoque(int qtd)
        {
            if (qtd < 0) qtd *= -1;
            QtdEstoque -= qtd;
        }

        public void ReporEstoque(int qtd)
        {
            QtdEstoque += qtd;
        }
        public bool PossuiEstoque(int qtd)
        {
            return QtdEstoque >= qtd;
        }
    }
}

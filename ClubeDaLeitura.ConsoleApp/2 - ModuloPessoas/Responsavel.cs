using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.ModuloPessoas
{
    public abstract class Responsavel : Pessoas
    {
        public string nomeFilho { get; set; }
        public Responsavel(string nome, string telefone, string endereco, string nomeFilho) : base(nome, telefone, endereco)
        {
            this.nomeFilho = nomeFilho;
        }

        public override void AtualizarRegistro(Compartilhado.EntidadeBase novoRegistro)
        {
            Responsavel registroNovo = (Responsavel)novoRegistro;

            this.nome = registroNovo.nome;
            this.nomeFilho = registroNovo.nomeFilho;
            this.telefone = registroNovo.telefone;
            this.endereco = registroNovo.endereco;
        }
        private void PagarContas() { }
    }
}
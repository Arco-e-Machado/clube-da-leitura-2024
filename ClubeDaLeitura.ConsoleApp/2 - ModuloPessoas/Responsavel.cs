using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    internal abstract class Responsavel : Pessoas
    {
        public string nomeFilho { get; set; }
        public Responsavel(string nome, string telefone, string endereco, string nomeFilho) : base(nome, telefone, endereco)
        {
            this.nomeFilho = nomeFilho;
        }

        private void PagarContas() { }
    }
}
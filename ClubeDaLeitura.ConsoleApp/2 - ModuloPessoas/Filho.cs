using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Filho : Pessoas
    {

        public string responsavel { get; set; }
        public Filho(string nome, string endereco, string telefone, string responsavel) : base(nome, telefone, endereco)
        {
            this.responsavel = responsavel;
        }
    }
}
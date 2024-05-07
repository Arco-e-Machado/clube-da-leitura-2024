using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Pessoas
{
    public class Filho : Pessoa
    {
        public string responsavel { get; set; }

        public Filho(string responsavel)
        {
            this.responsavel = responsavel;
        }
    }
}
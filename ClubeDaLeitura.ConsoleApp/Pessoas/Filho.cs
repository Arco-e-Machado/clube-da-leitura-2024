using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClubeDaLeitura.ConsoleApp.Pessoas.ModuloAmigo;

namespace ClubeDaLeitura.ConsoleApp.Pessoas
{
    public class Filho : Amigo
    {
        public string responsavel { get; set; }

        public Filho(string responsavel)
        {
            this.responsavel = responsavel;
        }
    }
}
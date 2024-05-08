using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.Revistas
{
    public class Revista : EntidadeBase
    {
        public string titulo { get; set; }
        public DateTime anoDeEdicao { get; set; }
    }
}
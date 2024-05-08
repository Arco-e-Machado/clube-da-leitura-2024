using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.Pessoas.ModuloAmigo
{
    public class Amigo : EntidadeBase
    {
        protected string nome { get; set; }
        protected string telefone { get; set; }
        protected string endereco { get; set; }
    }
}
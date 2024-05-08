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
        public string numeroEdicao { get; set; }

        public Revista(string titulo, DateTime anoDeEdicao, string numeroEdicao)
        {
            this.titulo = titulo;
            this.anoDeEdicao = anoDeEdicao;
            this.numeroEdicao = numeroEdicao;
        }
    }
}
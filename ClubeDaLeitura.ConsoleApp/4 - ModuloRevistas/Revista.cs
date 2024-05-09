using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    internal abstract class Revista : EntidadeBase
    {
        public string titulo { get; set; }
        public string numeroDeEdicao { get; set; }
        public DateTime dataDeEdicao { get; set; }
        public string repositorio { get; set; }
        public Revista(string titulo,string numeroDeEdicao, string repositorio, DateTime dataDeEdicao) 
        {
            this.titulo = titulo;
            this.dataDeEdicao = dataDeEdicao;
            this.numeroDeEdicao = numeroDeEdicao;
            this.repositorio = repositorio;
        }
    }
}
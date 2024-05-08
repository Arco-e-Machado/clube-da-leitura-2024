using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Pessoa : EntidadeBase
    {

        public string nome { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
        public Pessoa(string nome, string endereco, string telefone)
        {
            this.endereco = endereco;
            this.nome = nome;
            this.telefone = telefone;
        }
    }
}
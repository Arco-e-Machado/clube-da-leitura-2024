using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class DominioPessoas
    {
        public Pessoa RegistrarPessoa()
        {
            string nome = Program.Input<string>("Digite o nome:\n");
            string endereco = Program.Input<string>("Digite o endereço:\n");
            string telefone = Program.Input<string>("Digite o telefone:\n");

            Pessoa novaPessoa = new(nome, endereco, telefone);
            return novaPessoa;
        }
    }
}
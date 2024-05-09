using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    internal abstract class Pessoas : EntidadeBase
    {
        public string nome { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }

        public Pessoas(string nome, string telefone, string endereco)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.endereco = endereco;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(telefone.Trim()))
                erros.Add("O campo \"telefone\" é obrigatório");

            if (string.IsNullOrEmpty(endereco.Trim()))
                erros.Add("O campo \"endereço\" é obrigatório");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            throw new NotImplementedException();
        }
    }
}
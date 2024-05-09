using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloPessoas
{
    public class Amigo : Pessoas
    {
        public string responsavel { get; set; }

        public string nome { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }

        public Amigo(string nome, string responsavel, string endereco, string telefone) : base(nome, endereco, telefone)
        {
            this.nome = nome;
            this.responsavel = responsavel;
            this.endereco = endereco;
            this.telefone = telefone;
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

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Amigo registroNovo = (Amigo)novoRegistro;

            this.nome = registroNovo.nome;
            this.responsavel = registroNovo.responsavel;
            this.telefone = registroNovo.telefone;
            this.endereco = registroNovo.endereco;
        }
    }
}
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloPessoas
{
    public class Amigo : Pessoas
    {
        public string responsavel { get; set; }

        public ArrayList multas { get; set; } = new ArrayList();

        public Amigo(string nome, string responsavel, string telefone, string endereco) : base(nome, telefone, endereco)
        {
            this.nome = nome;
            this.responsavel = responsavel;
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
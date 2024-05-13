using System.Collections;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloPessoas
{
    public abstract class Responsavel : Pessoas
    {
        public string nomeFilho { get; set; }
        public Responsavel(string nome, string telefone, string endereco, string nomeFilho) : base(nome, telefone, endereco)
        {
            this.nomeFilho = nomeFilho;
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
            Responsavel registroNovo = (Responsavel)novoRegistro;

            this.nome = registroNovo.nome;
            this.nomeFilho = registroNovo.nomeFilho;
            this.telefone = registroNovo.telefone;
            this.endereco = registroNovo.endereco;

        }
        private void PagarContas() { }
    }
}
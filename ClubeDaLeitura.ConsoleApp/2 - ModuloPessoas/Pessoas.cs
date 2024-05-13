using System.Collections;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloPessoas
{
    public class Pessoas : EntidadeBase
    {
        public string nome { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public ArrayList multas { get; set; } = new ArrayList();

        public Pessoas(string nome, string endereco, string telefone)
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

            if (string.IsNullOrEmpty(endereco.Trim()))
                erros.Add("O campo \"endereço\" é obrigatório");

            if (string.IsNullOrEmpty(telefone.Trim()))
                erros.Add("O campo \"telefone\" é obrigatório");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Pessoas registroNovo = (Pessoas)novoRegistro;

            this.nome = registroNovo.nome;
            this.telefone = registroNovo.telefone;
            this.endereco = registroNovo.endereco;
        }

        internal void ReceberMulta(Multa novaMulta)
        {
            multas.Add(novaMulta);
        }
    }
}
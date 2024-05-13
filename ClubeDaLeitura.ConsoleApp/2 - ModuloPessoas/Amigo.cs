using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloPessoas
{
    public class Amigo : Pessoas
    {
        public string responsavel { get; set; }

        public Amigo(string nome, string responsavel, string telefone, string endereco) : base(nome, telefone, endereco)
        {
            this.nome = nome;
            this.responsavel = responsavel;
            this.telefone = telefone;
            this.endereco = endereco;
        }


      

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Amigo registroNovo = (Amigo)novoRegistro;

            this.responsavel = registroNovo.responsavel;
        }

    }
}
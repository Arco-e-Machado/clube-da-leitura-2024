using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloPessoas;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;
using System.Collections;


namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimos
{
    public class Emprestimo : EntidadeBase
    {
        public Pessoas filho { get; set; }
        public Revista revista { get; set; }
        public DateTime dataEmprestimo { get; set; }
        public DateTime dataDevolucao { get; set; }
        public bool Concluido { get; set; } //Concluido

        public Emprestimo(Pessoas filho, Revista revista, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            this.filho = filho;
            this.revista = revista;
            this.dataEmprestimo = dataEmprestimo;
            this.dataDevolucao = dataDevolucao;
            this.Concluido = false;
        }

        public void Emprestar()
        {
            revista.Emprestar();
        }
        public void ConcluirEmprestimo()
        {
            revista.Devolver();
            Concluido = true;
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Emprestimo registroNovo = (Emprestimo)novoRegistro;

            filho = registroNovo.filho;
            revista = registroNovo.revista;
            dataEmprestimo = registroNovo.dataEmprestimo;
            dataDevolucao = registroNovo.dataDevolucao;
            Concluido = registroNovo.Concluido;
        }

        public override ArrayList Validar()
        {
            throw new NotImplementedException();
        }
    }
}
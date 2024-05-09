using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloPessoas;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;


namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimos
{
    public abstract class Emprestimo : EntidadeBase
    {
        public Amigo filho { get; set; }
        public Revista revista { get; set; }
        public DateTime dataEmprestimo { get; set; }
        public DateTime dataDevolucao { get; set; }
        public bool statusEmprestimo { get; set; }

        public Emprestimo(Amigo filho, Revista revista, DateTime dataEmprestimo, DateTime dataDevolucao, bool statusEmprestimo)
        {
            this.filho = filho;
            this.revista = revista;
            this.dataEmprestimo = dataEmprestimo;
            this.dataDevolucao = dataDevolucao;
            this.statusEmprestimo = statusEmprestimo;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Emprestimo registroNovo = (Emprestimo)novoRegistro;

            filho = registroNovo.filho;
            revista = registroNovo.revista;
            dataEmprestimo = registroNovo.dataEmprestimo;
            dataDevolucao = registroNovo.dataDevolucao;
            statusEmprestimo = registroNovo.statusEmprestimo;
        }
    }
}
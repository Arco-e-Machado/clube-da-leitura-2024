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
        public bool statusEmprestimo { get; set; }

        public Emprestimo(Pessoas filho, Revista revista, DateTime dataEmprestimo, DateTime dataDevolucao, bool statusEmprestimo)
        {
            this.filho = filho;
            this.revista = revista;
            this.dataEmprestimo = dataEmprestimo;
            this.dataDevolucao = dataDevolucao;
            this.revista.status = statusEmprestimo;
        }
        public string ConverterString(bool status)
        {
            if (statusEmprestimo == true)
                return "Atrasado";

            return "Sem atraso";
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

        public override ArrayList Validar()
        {
            throw new NotImplementedException();
        }
    }
}
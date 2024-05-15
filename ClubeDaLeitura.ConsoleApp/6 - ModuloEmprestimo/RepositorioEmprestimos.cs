using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimos
{
    internal class RepositorioEmprestimos : RepositorioBase
    {

          public ArrayList SelecionarEmprestimosDoMes()
        {
            ArrayList emprestimosDoMes = new ArrayList();

            foreach (Emprestimo e in registros)
            {
                if (e.dataEmprestimo.Month == DateTime.Today.Month)
                    emprestimosDoMes.Add(e);
            }

            return emprestimosDoMes;
        }

        public ArrayList SelecionarEmprestimosDoDia()
        {
            ArrayList emprestimosDoDia = new ArrayList();

            foreach (Emprestimo e in registros)
            {
                if (e.dataEmprestimo.Month == DateTime.Today.Month && e.dataEmprestimo.Day == DateTime.Today.Day)
                    emprestimosDoDia.Add(e);
            }

            return emprestimosDoDia;
        }
    }
}
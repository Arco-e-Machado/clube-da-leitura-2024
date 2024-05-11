using ClubeDaLeitura.ConsoleApp._7___Multa;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimos;
using ClubeDaLeitura.ConsoleApp.ModuloMultas;
using ClubeDaLeitura.ConsoleApp.ModuloPessoas;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class TelaEmprestimo : TelaBase
    {
        public TelaPessoas telaPessoas = null;
        public TelaRevista telaRevista = null;
        public TelaMulta telaMulta = null;

        public RepositorioPessoas repositorioPessoas = null;
        public RepositorioRevistas repositorioRevistas = null;
        public RepositorioMulta repositorioMulta = null;

        protected override EntidadeBase ObterRegistro()
        {
            telaPessoas.VisualizarRegistros(false);

            Console.WriteLine("Por favor, informe o ID do amigo");
            int idAmigo = Convert.ToInt32(Console.ReadLine());
            Amigo amigoSelecionado = (Amigo)repositorioPessoas.SelecionaPorId(idAmigo);


            telaRevista.VisualizarRegistros(false);

            Console.WriteLine("Por favor, informe ID da revista");
            int idRevista = Convert.ToInt32(Console.ReadLine());
            Revista revistaSelecionada = (Revista)repositorioRevistas.SelecionaPorId(idRevista);


            DateTime dataDevolucao = DateTime.Now.AddDays(telaRevista.EscolherCaixaRevistas(idRevista));

            bool status = true;

            Emprestimo novoEmprestimo = new(amigoSelecionado, revistaSelecionada, new DateTime(2000, 2, 12), dataDevolucao, status);

            return novoEmprestimo;
        }

        public override void VisualizarRegistros(bool verTudo)
        {
            Console.WriteLine("Visualizando Revistas");

            Console.WriteLine();

            Console.WriteLine(
             "{0, -10} | {1, -15} | {2, -20} | {3, -20} | {4, -20} | {5, -15}",
             "Id", "Amigo", "Revista", "Data do Emprestimo", "Data de Devolução", "Status"
         );

            ArrayList EmprestimosCadastrados = repositorio.PegaRegistros();

            foreach (Emprestimo emprestimo in EmprestimosCadastrados)
            {
                Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -20} | {3, -20} | {4, -20} | {5, -15}",
                emprestimo._ID,
                emprestimo.filho.nome,
                emprestimo.revista.titulo,
                emprestimo.dataEmprestimo.ToShortDateString(),
                emprestimo.dataDevolucao.ToShortDateString(),
                emprestimo.statusEmprestimo
              );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
       

        public override char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
            Console.WriteLine($"2 - Editar {tipoEntidade}");
            Console.WriteLine($"3 - Excluir {tipoEntidade}");
            Console.WriteLine($"4 - Visualizar {tipoEntidade}s");
            Console.WriteLine($"5 - Finalizar {tipoEntidade}");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }
        internal void CadastroTeste()
        {
            Amigo AmigoEmprestimo = (Amigo)repositorioPessoas.SelecionaPorId(0);
            Revista RevistaEmprestimo = (Revista)repositorioRevistas.SelecionaPorId(0);
            //DateTime dataDeEmprestimo = Convert.ToDateTime("12/12/2002");
            DateTime dataDeDevolucao = DateTime.Now.AddDays(telaRevista.EscolherCaixaRevistas(0));
            Emprestimo novoEmprestimo = new Emprestimo(AmigoEmprestimo, RevistaEmprestimo, DateTime.Now, dataDeDevolucao, true);

            repositorio.Cadastrar(novoEmprestimo);
        }

    }
}
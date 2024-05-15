using ClubeDaLeitura.ConsoleApp.ModuloMultas;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimos;
using ClubeDaLeitura.ConsoleApp.ModuloPessoas;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;
using System.Collections;

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

            Amigo amigoSelecionado = VerificarMulta();
            telaRevista.VisualizarRegistros(false);

            int idRevista;
            Revista revistaSelecionada;
            VerificarRevistaDisponivel(out idRevista, out revistaSelecionada);

            DateTime diaEmprestimo = DateTime.Now;
            DateTime dataDevolucao = diaEmprestimo.AddDays(telaRevista.EscolherCaixaRevistas(idRevista));

            Emprestimo novoEmprestimo = new(amigoSelecionado, revistaSelecionada, diaEmprestimo, dataDevolucao);
            novoEmprestimo.Emprestar();

            return novoEmprestimo;
        }

        private void VerificarRevistaDisponivel(out int idRevista, out Revista revistaSelecionada)
        {
            idRevista = Program.Input<int>("Por favor, informe ID da revista:\n");
            revistaSelecionada = (Revista)repositorioRevistas.SelecionaPorId(idRevista);
            while (revistaSelecionada.EstaEmprestada == true)
            {
                Console.WriteLine("Esta revista esta emprestada!");
                idRevista = Program.Input<int>("Por favor, informe ID da revista:\n");
                revistaSelecionada = (Revista)repositorioRevistas.SelecionaPorId(idRevista);
            }
        }

        private Amigo VerificarMulta()
        {
            int idAmigo = Program.Input<int>("Por favor, informe o ID do amigo: ");
            Amigo amigoSelecionado = (Amigo)repositorioPessoas.SelecionaPorId(idAmigo);
            while (amigoSelecionado.estaMultado == true)
            {
                Console.WriteLine("Seu empréstimo foi negado por estar multado");
                idAmigo = Program.Input<int>("Por favor, informe o ID do amigo: ");
                amigoSelecionado = (Amigo)repositorioPessoas.SelecionaPorId(idAmigo);
            }

            return amigoSelecionado;
        }

        public override void VisualizarRegistros(bool verTudo)
        {
            Console.Clear();

            Console.WriteLine("Visualizando Revistas");

            Console.WriteLine();

            Console.WriteLine(
             "{0, -10} | {1, -15} | {2, -20} | {3, -20} | {4, -20}",
             "Id", "Amigo", "Revista", "Data do Emprestimo", "Data de Devolução"
         );

            ArrayList EmprestimosCadastrados = repositorio.PegaRegistros();

            foreach (Emprestimo emprestimo in EmprestimosCadastrados)
            {
                Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -20} | {3, -20} | {4, -20}",
                emprestimo._ID,
                emprestimo.filho.nome,
                emprestimo.revista.titulo,
                emprestimo.dataEmprestimo.ToShortDateString(),
                emprestimo.dataDevolucao.ToShortDateString()
              );
            }

            Console.WriteLine("\nDigite qualquer tecla para continuar: ");
            Console.ReadKey();
            Console.WriteLine();
        }

        public void Multar()
        {
            ArrayList todosOsEmprestimos = repositorio.PegaRegistros();
            foreach (Emprestimo emprestimo in todosOsEmprestimos)
            {
                DateTime hoje = DateTime.Now;
                DateTime limite = emprestimo.dataDevolucao;
                TimeSpan dias = 5 * (limite - hoje);
                if (limite < hoje)
                {
                    emprestimo.filho.estaMultado = true;
                }
            }
        }

        public void FinalizarEmprestimo()
        {
            VisualizarRegistros(true);
            int idEmprestimo = Program.Input<int>("Digite o ID do Emprestimo desejado: ");
            Emprestimo emprestimoSelecionado = (Emprestimo)repositorio.SelecionaPorId(idEmprestimo);

            DevolverRevista(emprestimoSelecionado);
            emprestimoSelecionado.ConcluirEmprestimo();
            ArrayList todosOsEmprestimos = repositorio.PegaRegistros();
            todosOsEmprestimos.Remove(emprestimoSelecionado);

            ExibirMensagem("Emprestimo finalizado", ConsoleColor.Green);

        }

        private static void DevolverRevista(Emprestimo emprestimoSelecionado)
        {
            emprestimoSelecionado.revista.Devolver();

        }

        public override char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
            Console.WriteLine($"2 - Visualizar {tipoEntidade}s");
            Console.WriteLine($"3 - Finalizar {tipoEntidade}");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            char operacaoEscolhida = Program.Input<char>("Escolha uma das opções: ");
            return operacaoEscolhida;
        }

        internal void CadastroTeste()
        {
            Amigo AmigoEmprestimo = (Amigo)repositorioPessoas.SelecionaPorId(1);
            Revista RevistaEmprestimo = (Revista)repositorioRevistas.SelecionaPorId(1);
            DateTime dataDeDevolucao = DateTime.Now.AddDays(telaRevista.EscolherCaixaRevistas(RevistaEmprestimo.repositorio.tempoDeEmprestimo));
            Emprestimo novoEmprestimo = new Emprestimo(AmigoEmprestimo, RevistaEmprestimo, DateTime.Now, dataDeDevolucao);
            novoEmprestimo.Emprestar();

            Amigo AmigoEmprestimo1 = (Amigo)repositorioPessoas.SelecionaPorId(1);
            Revista RevistaEmprestimo1 = (Revista)repositorioRevistas.SelecionaPorId(2);
            DateTime dataDeDevolucao1 = new DateTime(2024, 05, 05).AddDays(telaRevista.EscolherCaixaRevistas(RevistaEmprestimo1.repositorio.tempoDeEmprestimo));
            Emprestimo novoEmprestimo1 = new Emprestimo(AmigoEmprestimo1, RevistaEmprestimo1, new DateTime(2024, 05, 05), dataDeDevolucao1);
            novoEmprestimo1.Emprestar();

            repositorio.Cadastrar(novoEmprestimo);
            repositorio.Cadastrar(novoEmprestimo1);

        }

    }
}
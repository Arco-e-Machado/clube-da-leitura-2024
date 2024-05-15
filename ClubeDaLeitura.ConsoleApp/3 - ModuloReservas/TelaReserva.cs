using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimos;
using ClubeDaLeitura.ConsoleApp.ModuloPessoas;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloReservas
{
    internal class TelaReserva : TelaBase
    {
        public Revista revista = null;
        public TelaRevista telaRevista = null;
        public RepositorioRevistas repositorioRevista = null;

        public RepositorioEmprestimos repositorioEmprestimos;

        public TelaPessoas telaPessoas = null;
        public RepositorioPessoas repositorioPessoas = null;

        public override void VisualizarRegistros(bool verTudo)
        {
            Console.WriteLine("Visualizando Reservas");

            Console.WriteLine();

            Console.WriteLine(
           "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -20}",
           "Id", "Revista", "Data da reserva", "Amigo", "Data Limite"
       );

            ArrayList reservasCadastradas = repositorio.PegaRegistros();

            foreach (Reserva reserva in reservasCadastradas)
            {
                Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -20}",
                reserva._ID, reserva.revista.titulo, reserva.dataReserva.ToShortDateString(), reserva.filho.nome, reserva.fimReserva.ToShortDateString()
              );
            }

            Console.WriteLine("\nDigite qualquer tecla para continuar...");
            Console.ReadKey();
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
            Console.WriteLine($"2 - Visualizar {tipoEntidade}s");
            Console.WriteLine($"3 - Finalizar {tipoEntidade}");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            char operacaoEscolhida = Program.Input<char>("Escolha uma das opções: \n");
            return operacaoEscolhida;
        }
        protected override EntidadeBase ObterRegistro()
        {
            telaRevista.VisualizarRegistros(false);
            Console.WriteLine();
            int idRevista = Program.Input<int>("Por favor, informe o ID da revista a ser retirada: ");
            Revista revistaSelecionada = (Revista)repositorioRevista.SelecionaPorId(idRevista);

            VerificarDisponibilidade(ref idRevista, ref revistaSelecionada);

            telaPessoas.VisualizarRegistros(false);
            int idAmigo = Program.Input<int>("Por favor, informe o ID do amigo que vai retirar a revista: ");
            Amigo amigoSelecionado = (Amigo)repositorioPessoas.SelecionaPorId(idAmigo);

            int diasMaximosParaReserva = 2;

            DateTime fimReserva = DateTime.Now.AddDays(diasMaximosParaReserva);

            return new Reserva(revistaSelecionada, DateTime.Now, fimReserva, amigoSelecionado);
        }

        private bool VerificarDisponibilidade(ref int idRevista, ref Revista revistaSelecionada)
        {
            while (revistaSelecionada.EstaEmprestada == true)
            {
                Console.WriteLine("\nA revista não está disponível!");
                idRevista = Program.Input<int>("Por favor, informe o ID da revista a ser retirada: ");
                revistaSelecionada = (Revista)repositorioRevista.SelecionaPorId(idRevista);
            }
            return true;
        }

        public void RetirarReserva()
        {
            VisualizarRegistros(true);
            int idReserva = Program.Input<int>("Digite o ID da reserva desejada: ");
            Reserva reservaSelecionada = (Reserva)repositorio.SelecionaPorId(idReserva);

            reservaSelecionada.revista.Emprestar();
            ArrayList todasAsReservas = repositorio.PegaRegistros();
            todasAsReservas.Remove(reservaSelecionada);

            EmprestarReserva(reservaSelecionada);

            ExibirMensagem("Reserva finalizada", ConsoleColor.Green);
        }

        private Emprestimo EmprestarReserva(Reserva reservaSelecionada)
        {
            DateTime teste = DateTime.Now;
            DateTime Devolucao = teste.AddDays(reservaSelecionada.revista.repositorio.tempoDeEmprestimo);

            Emprestimo novoEsprestimoDaReserva = new(reservaSelecionada.filho, reservaSelecionada.revista, DateTime.Now, Devolucao);
            repositorioEmprestimos.Cadastrar(novoEsprestimoDaReserva);

            return novoEsprestimoDaReserva;
        }
    }
}

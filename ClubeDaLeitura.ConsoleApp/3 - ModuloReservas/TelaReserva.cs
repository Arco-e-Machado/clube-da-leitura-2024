using ClubeDaLeitura.ConsoleApp.Compartilhado;
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

        protected override EntidadeBase ObterRegistro()
        {
            telaRevista.VisualizarRegistros(false);
            Console.WriteLine();
            int idRevista = Program.Input<int>("Por favor, informe o ID da revista a ser retirada: ");
            Revista revistaSelecionada = (Revista)repositorioRevista.SelecionaPorId(idRevista);
            VerificarDisponibilidade(ref idRevista, ref revistaSelecionada);

            revistaSelecionada.status = true;

            telaPessoas.VisualizarRegistros(false);

            int idAmigo = Program.Input<int>("Por favor, informe o ID do amigo que vai retirar a revista: ");
            Amigo amigoSelecionado = (Amigo)repositorioPessoas.SelecionaPorId(idAmigo);

            int diasMaximosParaReserva = 2;

            DateTime fimReserva = DateTime.Now.AddDays(diasMaximosParaReserva);
            bool status = false;

            return new Reserva(revistaSelecionada, DateTime.Now, fimReserva, amigoSelecionado, status);
        }

        private void VerificarDisponibilidade(ref int idRevista, ref Revista revistaSelecionada)
        {
            while (!revistaSelecionada.status == false)
            {
                Console.WriteLine("\nA revista não está disponível!");
                idRevista = Program.Input<int>("Por favor, informe o ID da revista a ser retirada: ");
                revistaSelecionada = (Revista)repositorioRevista.SelecionaPorId(idRevista);
            }
        }
    }

}

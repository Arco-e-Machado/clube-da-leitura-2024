using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloPessoas;
using ClubeDaLeitura.ConsoleApp.ModuloReservas;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp._3___ModuloReservas
{
    internal class TelaReserva : TelaBase
    {
        public TelaRevista telaRevista;
        public RepositorioRevistas repositorioRevista;

        public TelaPessoas telaPessoas;
        public RepositorioPessoas repositorioPessoas;

        public override void VisualizarRegistros(bool verTudo)
        {
            Console.WriteLine("Visualizando Reservas");

            Console.WriteLine();

            Console.WriteLine(
           "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -20} | {5, -20}",
           "Id", "Revista", "Data da reserva", "Amigo", "Status da reserva, Data Limite"
       );

            ArrayList reservasCadastradas = repositorio.PegaRegistros();

            foreach (Reserva reserva in reservasCadastradas)
            {
                Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -20} | {5, -20}",
                reserva._ID, reserva.revista.titulo, reserva.dataReserva.ToShortTimeString(),
                reserva.filho.nome, reserva.statusReserva, reserva.fimReserva.ToShortTimeString()
              );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaRevista.VisualizarRegistros(false);
            Console.WriteLine();
            Console.WriteLine("Por favor, informe o ID da REVISTA a ser retirada");
            int idRevista = Convert.ToInt32(Console.ReadLine());
            Revista revistaSelecionada = (Revista)repositorioRevista.SelecionaPorId(idRevista);
            revistaSelecionada.status = true;

            telaPessoas.VisualizarRegistros(false);
            Console.WriteLine();
            Console.WriteLine("Por favor, informe o ID do AMIGO que vai retirar a REVISTA");
            int idAmigo = Convert.ToInt32(Console.ReadLine());
            Amigo amigoSelecionado = (Amigo)repositorioPessoas.SelecionaPorId(idAmigo);

            DateTime fimReserva = DateTime.Now.AddDays(2);
            bool status = false;

            return new Reserva(revistaSelecionada, DateTime.Now, fimReserva, amigoSelecionado, status);
        }
    }

}

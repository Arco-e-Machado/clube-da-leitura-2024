using ClubeDaLeitura.ConsoleApp.ModuloReservas;
using ClubeDaLeitura.ConsoleApp.Revistas;
using System.Globalization;

namespace ClubeDaLeitura.ConsoleApp
{

    internal class Program
    {
        public Revista revista;
        public Locador locador;
        public Responsavel responsavel;

        static void Main(string[] args)
        {
            #region deixa ali pra rever
            //    Console.WriteLine("Hello, World!");
            //    Responsavel novoResponsavel = new("Pai do luiz", "Casa do pai do luiz", "48-4848-8844");
            //    Revista novaRevista = new("branca de neve", new DateTime(1997, 07, 02), "6969");
            //    Locador novoLocador = new("Luiz", "Casa do luiz", "49-49499-4949", novoResponsavel.nome);

            //    Reservas novaReserva = new(3, novoLocador.nome, novaRevista.titulo);

            //    Console.WriteLine($"quantidade dias: {novaReserva.QtDiasReservados}\nNome locador: {novaReserva.nomeFilho}\nTitulo revista: {novaReserva.nomeRevista}");
            #endregion

            #region Instanciação de objetos

            TelaPessoas telaPessoas = new TelaPessoas();
            TelaPrincipal telaPrincipal = new TelaPrincipal(telaPessoas);

            #endregion
            telaPrincipal.TelaInicio();


        }
        public static T Input<T>(string texto){

            Console.Write(texto); // Lembrar de colocar o \n no fim;

            string input = Console.ReadLine().ToLower();

            try
            {
                return (T)Convert.ChangeType(input, typeof(T));
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato inválido, tente novamente!");
                return Input<T>(texto);
            }
        }
    }

}

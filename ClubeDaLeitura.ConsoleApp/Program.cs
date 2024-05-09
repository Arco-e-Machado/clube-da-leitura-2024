using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloPessoas;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Globalization;

namespace ClubeDaLeitura.ConsoleApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioPessoas repositorioPessoas = new RepositorioPessoas();
            TelaPessoas telaPessoas = new TelaPessoas();
            telaPessoas.tipoEntidade = "Pessoas";
            telaPessoas.repositorio = repositorioPessoas;

            ModuloCaixas.RepositorioCaixa repositorioCaixa = new ModuloCaixas.RepositorioCaixa();
            TelaCaixa telaCaixa = new TelaCaixa();
            telaCaixa.tipoEntidade = "Caixa";
            telaCaixa.repositorio = repositorioCaixa;

            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

            RepositorioReserva repositorioReserva = new RepositorioReserva();

            RepositorioRevistas repositorioRevistas = new RepositorioRevistas();
            TelaRevista telaRevista = new TelaRevista();
            telaRevista.tipoEntidade = "Revista";
            telaRevista.repositorio = repositorioRevistas;

            telaRevista.telaCaixa = telaCaixa;
            telaRevista.repositorioCaixa = repositorioCaixa;

            telaCaixa.telaRevista = telaRevista;
            telaCaixa.repositorioRevistas = repositorioRevistas;

            telaPessoas.CadastroTeste();
            telaCaixa.CadastroTeste();

            while (true)
            {
                char opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                    break;

                TelaBase tela = null;

                if (opcaoPrincipalEscolhida == '1')
                    tela = telaPessoas;

                else if (opcaoPrincipalEscolhida == '2')
                    tela = telaCaixa;

                //else if (opcaoPrincipalEscolhida == '3')
                //    tela = telaEmprestimo;

                //else if (opcaoPrincipalEscolhida == '4')
                //    tela = telaReserva;

                else if (opcaoPrincipalEscolhida == '5')
                    tela = telaRevista;

                while (true)
                {
                    char operacaoEscolhida = tela.ApresentarMenu();

                    if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                        break;

                    if (operacaoEscolhida == '1')
                        tela.Registrar();

                    else if (operacaoEscolhida == '2')
                        tela.Editar();

                    else if (operacaoEscolhida == '3')
                        tela.Excluir();

                    else if (operacaoEscolhida == '4')
                        tela.VisualizarRegistros(true);

                    else if (operacaoEscolhida == '5')
                    {
                        TelaCaixa telaConvertida = (TelaCaixa)tela;
                        telaConvertida.VisualizarRevistas();
                    }
            }
        }
        #region estudo
        //Console.WriteLine("Hello, World!");
        //Responsavel novoResponsavel = new("Pai do luiz", "Casa do pai do luiz", "48-4848-8844");
        //Revista novaRevista = new("branca de neve", new DateTime(1997, 07, 02), "6969");
        //Locador novoLocador = new("Luiz", "Casa do luiz", "49-49499-4949", novoResponsavel.nome);

        //Reservas novaReserva = new(3, novoLocador.nome, novaRevista.titulo);

        //Console.WriteLine($"quantidade dias: {novaReserva.QtDiasReservados}\nNome locador: {novaReserva.nomeFilho}\nTitulo revista: {novaReserva.nomeRevista}");
        #endregion

    }
        public static T Input<T>(string texto)
        {
            Console.Write(texto); // Não esquecer de colocar \n no fim;

            string input = Console.ReadLine().ToLower();

            try
            {
                return (T)Convert.ChangeType(input, typeof(T));
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato inválido!");
                return Input<T>(texto);
            }
        }
    }
}

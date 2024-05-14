using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.ModuloPessoas;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimos;
using ClubeDaLeitura.ConsoleApp.ModuloReservas;
using ClubeDaLeitura.ConsoleApp.ModuloMultas;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioPessoas repositorioPessoas = new RepositorioPessoas();
            TelaPessoas telaPessoas = new TelaPessoas();
            telaPessoas.tipoEntidade = "Pessoa";
            telaPessoas.repositorio = repositorioPessoas;

            RepositorioMulta repositorioMulta = new RepositorioMulta();
            TelaMulta telaMulta = new TelaMulta();
            telaMulta.tipoEntidade = "Multa";
            telaMulta.repositorio = repositorioMulta;

            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            TelaCaixa telaCaixa = new TelaCaixa();
            telaCaixa.tipoEntidade = "Caixa";
            telaCaixa.repositorio = repositorioCaixa;

            RepositorioReservas repositorioReserva = new RepositorioReservas();
            TelaReserva telaReserva = new TelaReserva();
            telaReserva.tipoEntidade = "Reserva";
            telaReserva.repositorio = repositorioReserva;

            RepositorioRevistas repositorioRevistas = new RepositorioRevistas();
            TelaRevista telaRevista = new TelaRevista();
            telaRevista.tipoEntidade = "Revista";
            telaRevista.repositorio = repositorioRevistas;

            RepositorioEmprestimos repositorioEmprestimo = new RepositorioEmprestimos();
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo();
            telaEmprestimo.tipoEntidade = "Emprestimo";
            telaEmprestimo.repositorio = repositorioEmprestimo;

            telaRevista.telaCaixa = telaCaixa;
            telaRevista.repositorioCaixa = repositorioCaixa;

            telaReserva.telaRevista = telaRevista;
            telaReserva.telaPessoas = telaPessoas;

            telaReserva.repositorioRevista = repositorioRevistas;
            telaReserva.repositorioPessoas = repositorioPessoas;


            telaCaixa.telaRevista = telaRevista;
            telaCaixa.repositorioRevistas = repositorioRevistas;

            telaEmprestimo.telaPessoas = telaPessoas;
            telaEmprestimo.telaRevista = telaRevista;
            telaEmprestimo.telaMulta = telaMulta;

            telaEmprestimo.repositorioPessoas = repositorioPessoas;
            telaEmprestimo.repositorioRevistas = repositorioRevistas;
            telaEmprestimo.repositorioMulta = repositorioMulta;

            telaPessoas.CadastroTeste();
            telaCaixa.CadastroTeste();
            telaRevista.CadastroTeste();
            telaEmprestimo.CadastroTeste();

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

                else if (opcaoPrincipalEscolhida == '3')
                    tela = telaEmprestimo;

                else if (opcaoPrincipalEscolhida == '4')
                    tela = telaReserva;

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
            Console.Write(texto);

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

using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class TelaPessoas : TelaBase
    {

        public DominioPessoas dominioPessoas;

        public void MenuPessoas()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu inicial");
                Console.WriteLine("Escolha uma opção: \n1 - Cadastrar pessoa\n2 - Registro de pessoas\n3 - Editar cadastro\n4 - Verificar situação\n0 - Sair\n\n");

                int opcao = Program.Input<int>("Digite:\n");

                switch (opcao)
                {
                    case 1:
                        dominioPessoas.RegistrarPessoa();
                        break;
                    case 2:

                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}
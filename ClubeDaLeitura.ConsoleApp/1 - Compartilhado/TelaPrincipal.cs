namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal class TelaPrincipal
    {
        public static char ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|           Clube da Leitura           |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Cadastro de Amigos");
            Console.WriteLine("2 - Cadastro de Caixas");
            Console.WriteLine("3 - Cadastro de Emprestimos");
            Console.WriteLine("4 - Cadastro de Reservas");
            Console.WriteLine("5 - Cadastro de Revistas");

            Console.WriteLine("S - Sair");

            Console.WriteLine();
            char opcaoEscolhida = Program.Input<char>("Escolha uma das opções: ");

            return opcaoEscolhida;
        }
    }
}
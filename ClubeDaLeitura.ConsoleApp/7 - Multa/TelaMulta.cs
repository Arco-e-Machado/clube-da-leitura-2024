using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloPessoas;

namespace ClubeDaLeitura.ConsoleApp.ModuloMultas
{
    internal class TelaMulta : TelaBase
    {
        public TelaPessoas telaPessoas = null;

        public RepositorioPessoas repositorioPessoas = null;
        public override void VisualizarRegistros(bool verTudo)
        {
            
            telaPessoas.VisualizarRegistros(true);

            int idAmigo = Program.Input<int>("Digite o id da Caixa desejada: ");
            Amigo amigoMultado = (Amigo)repositorioPessoas.SelecionaPorId(idAmigo);

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -20} | {3, -20} | {4, -20}",
                "Id", "Tempo decorrido", "Valor", "Revista", "Amigo"
            );

            foreach (Amigo multado in amigoMultado.multas)
            {
                Console.WriteLine("Teste");
                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -20} | {5, -15}",
                    multado._ID, multado.nome, multado.multas, multado.endereco, multado.responsavel
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        public Multa GerarMulta(int tempoDecorrido, string revista, string amigo)
        {
            return new Multa(tempoDecorrido, revista, amigo);
        }

        public override char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - Visualizar Multas");
            Console.WriteLine($"2 - Pagar Multas");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            char operacaoEscolhida2 = Program.Input<char>("Escolha uma das opções: ");

            return operacaoEscolhida2;

        }

        protected override EntidadeBase ObterRegistro()
        {
            throw new NotImplementedException();
        }
    }
}


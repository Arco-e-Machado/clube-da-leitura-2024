using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloPessoas
{
    internal class TelaPessoas : TelaBase
    {
        protected override EntidadeBase ObterRegistro()
        {
            string nome =Program.Input<string>("Por favor, informe o nome do amigo: ");

            string responsavel = Program.Input<string>("\nPor favor, informe o responsável: ");

            string telefone = Program.Input<string>("\nPor favor, informe o telefone: ");

            string endereco = Program.Input<string>("\nPor favor, informe o endereço: ");

            return new Amigo(nome, responsavel, telefone, endereco);
        }
        public override char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
            Console.WriteLine($"2 - Editar {tipoEntidade}");
            Console.WriteLine($"3 - Excluir {tipoEntidade}");
            Console.WriteLine($"4 - Visualizar {tipoEntidade}s");
            Console.WriteLine($"5 - Gerenciar Multas do {tipoEntidade}\n");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            char operacaoEscolhida = Program.Input<char>("Escolha uma das opções: ");

            return operacaoEscolhida;
        }

        public override void VisualizarRegistros(bool verTudo)
        {
            Console.Clear();

            Console.WriteLine("Visualizando pessoas:");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -20}",
                "Id", "Nome", "Responsavel", "Telefone", "Endereço"
            );

            ArrayList pessoasCadastradas = repositorio.PegaRegistros();

            foreach (Amigo amigo in pessoasCadastradas)
            {
                Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -20}",
                amigo._ID, amigo.nome, amigo.responsavel, amigo.telefone, amigo.endereco
                );
            }

            Console.WriteLine("\nDigite qualquer tecla para continuar...");
            Console.ReadKey();
            Console.WriteLine();
        }

        public void CadastroTeste()
        {
            Amigo novoFilhoTeste = new("leo filho", "leo responsável", "4002-8922", "Casa do leo");

            repositorio.Cadastrar(novoFilhoTeste);
        }

    }
}
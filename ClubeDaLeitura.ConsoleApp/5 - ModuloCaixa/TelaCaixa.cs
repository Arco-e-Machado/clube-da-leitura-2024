using System.Collections;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;


namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas
{
    internal class TelaCaixa : TelaBase
    {
        public Revista revistas;
        internal TelaRevista telaRevista;
        internal RepositorioRevistas repositorioRevistas;

        protected override EntidadeBase ObterRegistro()
        {
            string etiqueta = Program.Input<string>("Por favor, informe o etiqueta da caixa: ");

            string cor = Program.Input<string>("\nPor favor, informe o cor da caixa: ");

            int TDEmprestimo = Program.Input<int>("\nPor favor, informe o tempo de empréstimo para os livros contidos na caixa: ");

            bool status = false;

            return new Caixa(etiqueta, cor, TDEmprestimo);
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
            Console.WriteLine($"5 - Visualizar Revistas da {tipoEntidade}\n");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            char operacaoEscolhida = Program.Input<char>("Escolha uma das opções: ");

            return operacaoEscolhida;
        }
        public override void VisualizarRegistros(bool verTudo)
        {
            Console.Clear();

            Console.WriteLine("Visualizando Caixas...");

            Console.WriteLine();

            Console.WriteLine(
             "{0, -10} | {1, -15} | {2, -20} | {3, -20} | {4, -15}",
             "Id", "Etiqueta", "Cor", "Dias de Emprestimo", "Livros contidos"
         );

            ArrayList caixasCadastradas = repositorio.PegaRegistros();

            foreach (Caixa caixa in caixasCadastradas)
            {
                Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -20} | {3, -20} | {4, -15}",
                caixa._ID, caixa.etiqueta, caixa.cor, caixa.tempoDeEmprestimo, caixa.Revistas.Count);
            }

            Console.WriteLine("\nDigite qualquer tecla para continuar...");
            Console.ReadKey();
            Console.WriteLine();
        }

        internal void CadastroTeste()
        {
            Caixa caixaTeste = new("Terror", "Amarelo", 2);
            Caixa caixaTeste1 = new("Comedia", "Preto", 3);
            Caixa caixaTeste2 = new("Drama", "Azul", 4);
            Caixa caixaTeste3 = new("Suspense", "Vermelho", 5);

            repositorio.Cadastrar(caixaTeste);
            repositorio.Cadastrar(caixaTeste1);
            repositorio.Cadastrar(caixaTeste2);
            repositorio.Cadastrar(caixaTeste3);
        }

        internal void VisualizarRevistas()
        {
            VisualizarRegistros(false);

            Console.Write("Digite o id da Caixa desejada: ");
            int idCaixa = Convert.ToInt32(Console.ReadLine());
            Caixa caixaSelecionada = (Caixa)repositorio.SelecionaPorId(idCaixa);

            Console.Clear();
            Console.WriteLine("Visualizando Revistas dentro da caixa selecionada...\n");

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -20}",
                "Id", "Titulo", "Numero da Edicao", "Ano", "Disponilidade"
            );

            foreach (Revista revista in caixaSelecionada.Revistas)
            {
                Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -20}",
                revista._ID, revista.titulo, revista.numeroDeEdicao, revista.dataDeEdicao.ToShortDateString(), revista.ConverterString(revista.status)
              );
            }

            Console.WriteLine("\nDigite qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
using System.Collections;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;


namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas
{
    internal class TelaRevista : TelaBase
    {
        public TelaCaixa telaCaixa = null;

        public RepositorioCaixa repositorioCaixa = null;

        protected override EntidadeBase ObterRegistro()
        {
            string titulo = Program.Input<string>("Por favor, informe o titulo da revista: ");

            int numeroDeEdicao = Program.Input<int>("\nPor favor, informe o número de edição da revista: ");

            DateTime dataDeEdicao = Program.Input<DateTime>("\nPor favor, informe o ano de publicação da revista: ");

            int idCaixa = Program.Input<int>("\nPor favor, informe o ID da caixa: ");
            Caixa repositorioRevista = (Caixa)repositorioCaixa.SelecionaPorId(idCaixa);

            bool status = false;


            return new Revista(titulo, numeroDeEdicao, repositorioRevista, dataDeEdicao);
        }

        public override void VisualizarRegistros(bool verTudo)
        {
            Console.Clear();

            Console.WriteLine("Visualizando Revistas....");

            Console.WriteLine();

            Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -10 } | {5, -20} | {6, -15}",
             "Id", "Titulo", "Numero da Edicao", "Ano", "Id Caixa", "caixa", "Status da revista"
         );

            ArrayList revistasCadastradas = repositorio.PegaRegistros();

            foreach (Revista revista in revistasCadastradas)
            {
                Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -10 } | {5, -20} | {6, -15}",
                revista._ID, revista.titulo, revista.numeroDeEdicao, revista.dataDeEdicao.ToShortDateString(), revista.repositorio._ID, revista.repositorio.etiqueta, revista.ConverterString(revista.EstaEmprestada)
              );
            }

            Console.Write("Digite qualquer tecla para continuar...\n ");
            Console.ReadKey();
            Console.WriteLine();
        }

        public int EscolherCaixaRevistas(int idRevista)
        {
            int tempoEmprestimo = 0;
            ArrayList revistasCadastradas = repositorio.PegaRegistros();
            foreach (Revista revista in revistasCadastradas)
            {
                if (revista._ID != idRevista)
                    continue;
                else
                {
                    tempoEmprestimo = revista.repositorio.tempoDeEmprestimo;
                    break;
                }
            }
            return tempoEmprestimo;
        }

        public void CadastroTeste()
        {
            Caixa caixa = (Caixa)repositorioCaixa.SelecionaPorId(1);
            Revista revistaTeste = new Revista("Batman", 7, caixa, new DateTime(1997, 07, 02));

            Caixa caixa2 = (Caixa)repositorioCaixa.SelecionaPorId(2);
            Revista revistaTeste2 = new Revista("Branca de neve", 7, caixa2, new DateTime(1899, 02, 22));

            Caixa caixa3 = (Caixa)repositorioCaixa.SelecionaPorId(3);
            Revista revistaTeste3 = new Revista("Berserker", 7, caixa3, new DateTime(2005, 11, 20));

            Caixa caixa4 = (Caixa)repositorioCaixa.SelecionaPorId(4);
            Revista revistaTeste4 = new Revista("Ragnarok", 7, caixa4, new DateTime(1999, 10, 22));


            repositorio.Cadastrar(revistaTeste);
            repositorio.Cadastrar(revistaTeste2);
            repositorio.Cadastrar(revistaTeste3);
            repositorio.Cadastrar(revistaTeste4);
        }
    }
}

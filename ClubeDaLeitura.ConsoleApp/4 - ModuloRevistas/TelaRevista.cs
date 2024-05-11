using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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
            Console.WriteLine("Por favor, informe o titulo da revista");
            string titulo = Convert.ToString(Console.ReadLine());
            
            Console.WriteLine("Por favor, informe o número de edição da revista");
            int numeroDeEdicao = Convert.ToInt32(Console.ReadLine());

            
            DateTime dataDeEdicao = Program.Input<DateTime>("Por favor, informe o ano de publicação da revista\n");


            Console.WriteLine("Por favor, informe o ID da caixa");
            int idCaixa = Convert.ToInt32(Console.ReadLine());
            Caixa caixa = (ModuloCaixas.Caixa)repositorioCaixa.SelecionaPorId(idCaixa);

            bool status = false;

            

            return new Revista(titulo, numeroDeEdicao, caixa, dataDeEdicao, status);
        }

        public override void VisualizarRegistros(bool verTudo)
        {
            Console.WriteLine("Visualizando Revistas");

            Console.WriteLine();

            Console.WriteLine(
             "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -20} | {5, -15}",
             "Id", "Titulo", "Numero da Edicao", "Ano", "caixa", "Emprestada ?"
         );

            ArrayList revistasCadastradas = repositorio.PegaRegistros();

            foreach (Revista revista in revistasCadastradas)
            {
                Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -20} | {5, -15}",
                revista._ID, revista.titulo, revista.numeroDeEdicao,
                revista.dataDeEdicao.ToString("d"), revista.caixa._ID, revista.status
              );
            }

            Console.ReadLine();
            Console.WriteLine();
        }
    }
}

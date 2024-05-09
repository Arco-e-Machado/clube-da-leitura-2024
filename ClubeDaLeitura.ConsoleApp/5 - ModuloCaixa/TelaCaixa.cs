using ClubeDaLeitura.ConsoleApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;
using System.Text.RegularExpressions;


namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas
{
    internal class TelaCaixa : TelaBase
    {
        public Revista revistas;
        internal TelaRevista telaRevista;
        internal RepositorioRevistas repositorioRevistas;

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Por favor, informe o etiqueta da caixa");
            string etiqueta = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Por favor, informe o cor da caixa");
            string cor = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Por favor, informe o tempo de empréstimo para os livros contidos na caixa");
            int TDEmprestimo= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Por favor, informe o ID da caixa");
            int idRepositorio = Convert.ToInt32(Console.ReadLine());
            //RepositorioCaixa repositorioDasCaixas= (RepositorioCaixa)repositorio.SelecionaPorId(idRepositorio);

            bool status = false;

            return new Caixa(etiqueta, cor, TDEmprestimo);
        }

        public override void VisualizarRegistros(bool verTudo)
        {
            Console.WriteLine("Visualizando Caixas");

            Console.WriteLine();

            Console.WriteLine(
             "{0, -10} | {1, -15} | {2, -20} | {3, -15}",
             "Id", "Etiqueta", "Cor", "Tempo De Emprestimo"
         );

            ArrayList caixasCadastradas= repositorio.PegaRegistros();

            foreach (Caixa caixa in caixasCadastradas)
            {
                Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -20} | {3, -15}",
                caixa._ID, caixa.etiqueta, caixa.cor,
                caixa.tempoDeEmprestimo
              );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        internal void CadastroTeste()
        {
            Caixa caixaTeste = new("Terror", "Amarelo", 9);

            repositorio.Cadastrar(caixaTeste);
        }

        internal void VisualizarRevistas()
        {
            throw new NotImplementedException();
        }
    }
}
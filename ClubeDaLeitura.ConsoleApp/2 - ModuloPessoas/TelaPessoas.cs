using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.ModuloPessoas
{
    internal class TelaPessoas : TelaBase
    {
        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Por favor, informe o nome do amigo");
            string nome = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Por favor, informe o responsável");
            string responsavel = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Por favor, informe o telefone ");
            string telefone = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Por favor, informe o endereço");
            string endereco = Convert.ToString(Console.ReadLine());

            return new Amigo(nome, responsavel, telefone, endereco);
        }

        public override void VisualizarRegistros(bool verTudo)
        {
            Console.WriteLine("Visualizando pessoas");

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -20}",
                "Id", "Nome", "Responsavel", "Telefone", "Endereco"
            );

            ArrayList pessoasCadastradas = repositorio.PegaRegistros();

            foreach (Amigo amigo in pessoasCadastradas)
            {
                Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -20}",
                amigo._ID, amigo.nome, amigo.responsavel, amigo.telefone, amigo.endereco
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        public void CadastroTeste()
        {
            Amigo novoFilhoTeste = new Amigo("leo filho", "leo responsável", "Duarte da costa", "4002-8922");

            repositorio.Cadastrar(novoFilhoTeste);
        }

    }
}
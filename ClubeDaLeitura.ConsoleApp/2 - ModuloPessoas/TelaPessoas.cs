using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloPessoas
{
    internal class TelaPessoas : TelaBase
    {
        protected override EntidadeBase ObterRegistro()
        {
            string nome =Program.Input<string>("Por favor, informe o nome do amigo:\n");

            string responsavel = Program.Input<string>("Por favor, informe o responsável:\n");

            string telefone = Program.Input<string>("Por favor, informe o telefone:\n");

            string endereco = Program.Input<string>("Por favor, informe o endereço:\n");

            return new Amigo(nome, responsavel, telefone, endereco);
        }

        public override void VisualizarRegistros(bool verTudo)
        {
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

            Console.ReadKey();
            Console.WriteLine();
        }

        public void CadastroTeste()
        {
            Amigo novoFilhoTeste = new Amigo("leo filho", "leo responsável","4002-8922", "Casa do leo");

            repositorio.Cadastrar(novoFilhoTeste);
        }

    }
}
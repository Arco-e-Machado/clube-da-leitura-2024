using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal abstract class TelaBase
    {
        public string tipoEntidade = "";
        public RepositorioBase repositorio = null;

        public char ApresentarMenu()
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

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public virtual void Registrar()
        {
            Console.WriteLine($"Cadastrando{tipoEntidade}");

            Console.WriteLine("");

            EntidadeBase entidade = ObterRegistro();

            repositorio.Cadastrar(entidade);

            ExibirMensagem($"o {tipoEntidade} foi cadastrado com Sucesso", ConsoleColor.Green);
        }

        public void Editar()
        {
            Console.WriteLine($"Editando {tipoEntidade}");

            Console.WriteLine("");

            VisualizarRegistros(false);

            Console.WriteLine($"informe o ID do {tipoEntidade} a ser EDITADO");
            int idEscolhido = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("");

            EntidadeBase entidade = ObterRegistro();

            bool consegueEditar = repositorio.Editar(idEscolhido, entidade);

            if (!consegueEditar)
            {
                ExibirMensagem("Não foi possivel editar", ConsoleColor.Red);
            }

            ExibirMensagem("Alteração concluida com sucesso", ConsoleColor.Green);
        }

        public void Excluir()
        {
            Console.WriteLine($"Excluindo {tipoEntidade}");

            Console.WriteLine("");

            VisualizarRegistros(false);

            Console.WriteLine($"informe o ID do {tipoEntidade} a ser EXCLUIDO");
            int idEscolhido = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("");


            bool consegueExcuir = repositorio.Excluir(idEscolhido);

            if (!consegueExcuir)
            {
                ExibirMensagem("Não foi possivel excuir", ConsoleColor.Red);
            }

            ExibirMensagem("Remoção concluida com sucesso", ConsoleColor.Green);
        }

        protected abstract void VisualizarRegistros(bool verTudo);

        protected abstract EntidadeBase ObterRegistro();

        public void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine();

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }

    }
}

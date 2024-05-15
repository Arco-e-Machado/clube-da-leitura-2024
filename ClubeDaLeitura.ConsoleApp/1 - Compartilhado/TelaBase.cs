namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal abstract class TelaBase
    {
        public string tipoEntidade = "";
        public RepositorioBase repositorio = null;

        public virtual char ApresentarMenu()
        {
            Console.Clear();

            ApresentarCabeçalho();

            Console.WriteLine();

            Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
            Console.WriteLine($"2 - Editar {tipoEntidade}");
            Console.WriteLine($"3 - Excluir {tipoEntidade}");
            Console.WriteLine($"4 - Visualizar {tipoEntidade}s\n");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            char operacaoEscolhida = Program.Input<char>("Escolha uma das opções: ");

            return operacaoEscolhida;
        }

        public virtual void Registrar()
        {
            ApresentarCabeçalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine("");

            EntidadeBase entidade = ObterRegistro();

            repositorio.Cadastrar(entidade);

            ExibirMensagem($"O {tipoEntidade} foi cadastrado com Sucesso", ConsoleColor.Green);
        }

        public void Editar()
        {
            ApresentarCabeçalho();

            Console.WriteLine($"Editando {tipoEntidade}...");

            VisualizarRegistros(false);

            int idEscolhido = Program.Input<int>($"Informe o ID do {tipoEntidade} a ser editado: ");

            Console.WriteLine("");

            EntidadeBase entidade = ObterRegistro();

            bool consegueEditar = repositorio.Editar(idEscolhido, entidade);

            if (!consegueEditar)
            {
                ExibirMensagem("Não foi possivel editar!", ConsoleColor.Red);
            }

            ExibirMensagem("Alteração concluida com sucesso!", ConsoleColor.Green);
        }
    
        public void Excluir()
        {
            ApresentarCabeçalho();

            Console.WriteLine($"Excluindo {tipoEntidade}...");

            Console.WriteLine("");

            VisualizarRegistros(false);

            int idEscolhido = Program.Input<int>($"Informe o ID do {tipoEntidade} a ser excluido: ");

            bool consegueExcuir = repositorio.Excluir(idEscolhido);

            if (!consegueExcuir)
            {
                ExibirMensagem("Não foi possivel excuir", ConsoleColor.Red);
            }

            ExibirMensagem("Remoção concluida com sucesso", ConsoleColor.Green);
        }

        public abstract void VisualizarRegistros(bool verTudo);

        protected abstract EntidadeBase ObterRegistro();

        public void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine();

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadKey();
        }

        public void ApresentarCabeçalho()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"|       Gestão de {tipoEntidade}s       ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();
        }
    }
}

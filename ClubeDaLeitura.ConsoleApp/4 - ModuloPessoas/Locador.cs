namespace ClubeDaLeitura.ConsoleApp
{
    internal class Locador : Pessoa
    {
        public string responsavel { get; set; }

        public Locador(string nome, string endereco, string telefone, string responsavel) : base( nome, endereco, telefone)
        {
            this.responsavel = responsavel;
        }

    }
}
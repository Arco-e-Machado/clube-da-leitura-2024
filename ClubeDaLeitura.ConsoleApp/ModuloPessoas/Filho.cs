namespace ClubeDaLeitura.ConsoleApp
{
    public class Filho : Amigo
    {
        public string responsavel { get; set; }

        public Filho(string responsavel)
        {
            this.responsavel = responsavel;
        }
    }
}
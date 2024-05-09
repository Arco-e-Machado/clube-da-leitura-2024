using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class EntidadeBase
    {
        public int _ID { get; set; }

        public abstract ArrayList Validar();

        public abstract void AtualizarRegistro(EntidadeBase novoegistro);
    }
}

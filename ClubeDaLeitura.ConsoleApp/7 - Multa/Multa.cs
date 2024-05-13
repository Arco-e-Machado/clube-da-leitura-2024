using System.Collections;
using ClubeDaLeitura.ConsoleApp.Compartilhado;


namespace ClubeDaLeitura.ConsoleApp.ModuloMultas
{
    public class Multa : EntidadeBase
    {
        public int dias { get; set; }
        public double valor { get; set; }
        public string revista { get; set; }
        public string filho { get; set; }

        public Multa(int dias, string revista, string filho)
        {
            this.dias = dias;
            this.valor = ((3 * 27) / .555);
            this.revista = revista;
            this.filho = filho;
        }

        public override ArrayList Validar()
        {
            throw new NotImplementedException();
        }

        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            throw new NotImplementedException();
        }
    }
}
using System.Collections;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloReservas
{
    public class Reserva : EntidadeBase
    {
        public Revista revista { get; set; }
        public DateTime dataReserva { get; set; }
        public DateTime fimReserva { get; set; }
        public ModuloPessoas.Amigo filho { get; set; }
        public bool statusReserva { get; set; }

        public Reserva(Revista revista, DateTime dataReserva, DateTime fimReserva, ModuloPessoas.Amigo filho, bool statusReserva)
        {
            this.revista = revista;
            this.dataReserva = dataReserva;
            this.fimReserva = fimReserva;
            this.filho = filho;
            this.statusReserva = statusReserva;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Reserva registroNovo = (Reserva)novoRegistro;

            this.revista = registroNovo.revista;
            this.dataReserva = registroNovo.dataReserva;
            this.filho = registroNovo.filho;
            this.statusReserva = registroNovo.statusReserva;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (dataReserva == null)
                erros.Add("O campo \"Data\" é obrigatório");

            return erros;
        }
    }
}
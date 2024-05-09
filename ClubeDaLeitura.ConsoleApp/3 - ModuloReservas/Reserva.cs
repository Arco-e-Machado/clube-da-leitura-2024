using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.ModuloReservas
{
    public class Reserva : Compartilhado.EntidadeBase
    {
        public Revista revista { get; set; }
        public DateTime dataReserva { get; set; }
        public ModuloPessoas.Filho filho { get; set; }
        public bool statusReserva { get; set; }

        public Reserva(Revista revista, DateTime dataReserva, ModuloPessoas.Filho filho, bool statusReserva)
        {
            revista = revista;
            dataReserva = dataReserva;
            filho = filho;
            statusReserva = statusReserva;
        }

        public override void AtualizarRegistro(Compartilhado.EntidadeBase novoRegistro)
        {
            Reserva registroNovo = (Reserva)novoRegistro;

            this.revista = registroNovo.revista;
            this.dataReserva = registroNovo.dataReserva;
            this.filho = registroNovo.filho;
            this.statusReserva = registroNovo.statusReserva;
        }
    }
}
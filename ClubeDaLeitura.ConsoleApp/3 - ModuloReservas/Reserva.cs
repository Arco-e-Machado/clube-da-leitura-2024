using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloReservas
{
    public abstract class Reserva : EntidadeBase
    {
        public Revista revista { get; set; }
        public DateTime dataReserva { get; set; }
        public ModuloPessoas.Amigo filho { get; set; }
        public bool statusReserva { get; set; }

        public Reserva(Revista revista, DateTime dataReserva, ModuloPessoas.Amigo filho, bool statusReserva)
        {
            revista = revista;
            dataReserva = dataReserva;
            filho = filho;
            statusReserva = statusReserva;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Reserva registroNovo = (Reserva)novoRegistro;

            this.revista = registroNovo.revista;
            this.dataReserva = registroNovo.dataReserva;
            this.filho = registroNovo.filho;
            this.statusReserva = registroNovo.statusReserva;
        }
    }
}
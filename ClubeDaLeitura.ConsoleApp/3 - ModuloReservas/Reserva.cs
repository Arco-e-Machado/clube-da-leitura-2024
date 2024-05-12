using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public override ArrayList Validar()
        {
            throw new NotImplementedException();
        }
    }
}
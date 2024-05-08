using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevistas;
using ClubeDaLeitura.ConsoleApp.Revistas;

namespace ClubeDaLeitura.ConsoleApp.ModuloReservas
{
    internal class Reserva : EntidadeBase
    {
        public string nomeFilho { get; set; }
        public string nomeRevista { get; set; }
        public int QtDiasReservados { get; set; }

        public Reserva(int QtDiasReservados, string nomeFilho, string nomeRevista) : base()
        {
            this.QtDiasReservados = QtDiasReservados;
            this.nomeFilho = nomeFilho;
            this.nomeRevista = nomeRevista;
        }


    }
}

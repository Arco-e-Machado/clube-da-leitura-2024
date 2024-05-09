using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClubeDaLeitura.ConsoleApp.Compartilhado;


namespace ClubeDaLeitura.ConsoleApp
{
    public abstract class Multa : EntidadeBase
    {
        public int dias { get; set; }
        public int valor { get; set; }
        public int revista { get; set; }
        public ModuloPessoas.Amigo filho { get; set; }

        public Multa(int dias, int valor, int revista, ModuloPessoas.Amigo filho)
        {
            dias = dias;
            valor = valor;
            revista = revista;
            filho = filho;
        }

        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            throw new NotImplementedException();
        }
    }
}
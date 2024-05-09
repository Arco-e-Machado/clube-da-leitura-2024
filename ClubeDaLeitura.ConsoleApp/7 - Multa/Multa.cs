using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    public abstract class Multa : Compartilhado.EntidadeBase
    {
        public int dias { get; set; }
        public int valor { get; set; }
        public int revista { get; set; }
        public ModuloPessoas.Filho filho { get; set; }

        public Multa(int dias, int valor, int revista, ModuloPessoas.Filho filho)
        {
            dias = dias;
            valor = valor;
            revista = revista;
            filho = filho;
        }

        public override void AtualizarRegistro(Compartilhado.EntidadeBase novoegistro)
        {
            throw new NotImplementedException();
        }
    }
}
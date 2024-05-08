using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class EntidadeBase
    {
        private int contador = 1;
        public static int Id { get; set; }

        public EntidadeBase() { int id = IncrementarID(); }

        private int IncrementarID()
        {
            return contador++;
        }
    }
}
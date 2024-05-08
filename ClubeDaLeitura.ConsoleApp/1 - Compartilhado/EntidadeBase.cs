using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal abstract class EntidadeBase
    {
        private int contador = 1;
        public int _ID { get; set; }

        public EntidadeBase()
        {
            _ID = IncrementarID();
        }

        private int IncrementarID()
        {
            return contador++;
        }
    }
}
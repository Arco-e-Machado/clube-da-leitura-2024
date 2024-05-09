using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    internal  class EntidadeBase
    {
        private int contador = 1;
        public int _ID {  get; set; }

        EntidadeBase()
        {
            _ID = IncrementarID();
        }

        public int IncrementarID()
        {
            return contador++;
        }
    }
}
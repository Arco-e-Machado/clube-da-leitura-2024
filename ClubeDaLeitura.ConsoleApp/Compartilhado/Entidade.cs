using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class Entidade
    {
        private int contador = 1;
        public static int _id { get; set; }

        public Entidade() { int _id = IncrementarID(); }

        private int IncrementarID()
        {
            return contador++;
        }
    }
}
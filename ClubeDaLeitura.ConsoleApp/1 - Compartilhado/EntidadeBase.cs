using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    internal abstract class EntidadeBase
    {
        private int contador = 1;
        public int _ID { get; set; }

        EntidadeBase()
        {
            _ID = IncrementarID();
        }
        //public abstract ArrayList Validar();

        //public abstract void AtualizarRegistro(EntidadeBase novoegistro);
        public int IncrementarID()
        {
            return contador++;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int _ID { get; set; }

        //public abstract ArrayList Validar();

        public abstract void AtualizarRegistro(EntidadeBase novoegistro);
    }
}

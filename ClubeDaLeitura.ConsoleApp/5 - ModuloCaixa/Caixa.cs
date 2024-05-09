using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas
{
    public abstract class Caixa : EntidadeBase
    {
        public string etiqueta { get; set; }
        public string cor { get; set; }
        public int tempoDeEmprestimo { get; set; }
        public ArrayList Revistas { get; set; } = new ArrayList();

        public Caixa(string etiqueta, string cor, int tempoDeEmprestimo)
        {
            this.etiqueta = etiqueta;
            this.cor = cor;
            this.tempoDeEmprestimo = tempoDeEmprestimo;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Caixa registroNovo = (Caixa)novoRegistro;

            this.etiqueta = registroNovo.etiqueta;
            this.cor = registroNovo.cor;
            this.tempoDeEmprestimo = registroNovo.tempoDeEmprestimo;
        }
    }
}
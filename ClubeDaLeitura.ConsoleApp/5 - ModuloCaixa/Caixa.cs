using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixas
{
    public class Caixa : EntidadeBase
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
        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(etiqueta.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(cor.Trim()))
                erros.Add("O campo \"telefone\" é obrigatório");

            if (tempoDeEmprestimo == 0 || tempoDeEmprestimo == null)
                erros.Add("O campo \"endereço\" é obrigatório");

            return erros;
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
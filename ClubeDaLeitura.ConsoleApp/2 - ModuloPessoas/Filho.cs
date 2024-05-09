﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloPessoas
{
    public abstract class Filho : Pessoas
    {

        public string responsavel { get; set; }
        public Filho(string nome, string endereco, string telefone, string responsavel) : base(nome, telefone, endereco)
        {
            this.responsavel = responsavel;
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Filho registroNovo = (Filho)novoRegistro;

            this.nome = registroNovo.nome;
            this.responsavel = registroNovo.responsavel;
            this.telefone = registroNovo.telefone;
            this.endereco = registroNovo.endereco;
        }
    }
}
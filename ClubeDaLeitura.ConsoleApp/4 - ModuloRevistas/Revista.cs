﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.Compartilhado;


namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas
{
    public class Revista : EntidadeBase
    {
        public string titulo { get; set; }
        public int numeroDeEdicao { get; set; }
        public DateTime dataDeEdicao { get; set; }
        public Caixa repositorio { get; set; }

        public bool status { get; set; }
        public Revista(string titulo, int numeroDeEdicao, Caixa repositorio, DateTime dataDeEdicao, bool status)
        {
            this.titulo = titulo;
            this.dataDeEdicao = dataDeEdicao;
            this.numeroDeEdicao = numeroDeEdicao;
            this.repositorio = repositorio;
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Revista registroNovo = (Revista)novoRegistro;

            this.titulo = registroNovo.titulo;
            this.dataDeEdicao = registroNovo.dataDeEdicao;
            this.numeroDeEdicao = registroNovo.numeroDeEdicao;
            this.repositorio = registroNovo.repositorio;
            this.status = registroNovo.status;
        }
    }
}
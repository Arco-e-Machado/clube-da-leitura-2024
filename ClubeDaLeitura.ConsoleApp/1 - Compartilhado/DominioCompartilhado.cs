using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class DominioCompartilhado
    {

        public bool RequisitarDoBancoDeDados(EntidadeBase registro)
        {
            return true;
        }

        public RepositorioCompartilhado SeletorDeBanco(int seletor, RepositorioRevistas repositorioRevistas, RepositorioPessoas repositorioPessoas, RepositorioReservas repositorioReservas)
        {

            if (seletor == 1)
            {
                return repositorioPessoas;
            }
            else if (seletor == 2)
            {
                return repositorioReservas;
            }
            else
                return repositorioPessoas;
        }
    }
}
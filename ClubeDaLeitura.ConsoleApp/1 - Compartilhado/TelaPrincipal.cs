using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class TelaPrincipal
    {

        public TelaPessoas telaPessoas;

        public TelaPrincipal(TelaPessoas telaPessoas)
        {
            this.telaPessoas = telaPessoas; 
        }

        public void TelaInicio()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu inicial");
                Console.WriteLine("Escolha uma opção: \n1 - Emprestimo\n2 - Pessoas\n3 - Revistas\n4 - Gestão de multas\n0 - Sair\n\n");

                int opcao = Program.Input<int>("Digite:\n");

                switch (opcao)
                {
                    case 1:

                        break;
                    case 2:
                        telaPessoas.MenuPessoas();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }

    }
}
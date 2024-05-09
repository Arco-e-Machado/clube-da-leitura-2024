using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    internal abstract class RepositorioBase
    {
        protected ArrayList registros = new ArrayList();

        protected int contadorId = 1;

        public void Cadastrar(EntidadeBase novoRegistro)
        {
            novoRegistro._ID = contadorId++;

            registros.Add(novoRegistro);
        }

        public bool Editar(int id, EntidadeBase novaEntidade)
        {
            novaEntidade._ID = id;

            foreach (EntidadeBase entidade in registros)
            {
                if (entidade == null)
                    continue;

                else if (entidade._ID == id)
                {
                    //entidade.AtualizarRegistro(novaEntidade);

                    return true;
                }
            }

            return false;
        }

        public bool Excluir(int id)
        {
            foreach (EntidadeBase entidade in registros)
            {
                if (entidade == null)
                    continue;

                else if (entidade._ID == id)
                {
                    registros.Remove(entidade);

                    return true;
                }
            }

            return false;
        }

        public ArrayList SelecionarTodos()
        {
            return registros;
        }

        public EntidadeBase SelecionarPorId(int id)
        {
            foreach (EntidadeBase e in registros)
            {
                if (e == null)
                    continue;

                else if (e._ID == id)
                    return e;
            }

            return null;
        }

        public bool Existe(int id)
        {
            foreach (EntidadeBase e in registros)
            {
                if (e == null)
                    continue;

                else if (e._ID == id)
                    return true;
            }

            return false;
        }
    }
}
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal class RepositorioBase
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

            foreach (EntidadeBase registro in registros)
            {
                if (registro._ID == id)
                {
                    registro.AtualizarRegistro(novaEntidade);

                    return true;
                }
            }
            return false;
        }

        public bool Excluir(int id)
        {

            foreach (EntidadeBase registro in registros)
            {
                if (registro._ID == id)
                {
                    registros.Remove(registro);

                    return true;
                }
            }
            return false;
        }

        public ArrayList PegaRegistros()
        {
            return registros;
        }

        public EntidadeBase SelecionaPorId(int id)
        {
            foreach (EntidadeBase registro in registros)
            {
                if (registro._ID == id)
                {
                    return registro;
                }
            }
            return null;
        }

        public bool Existe(int id)
        {
            foreach (EntidadeBase registro in registros)
            {
                if (registro._ID == id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
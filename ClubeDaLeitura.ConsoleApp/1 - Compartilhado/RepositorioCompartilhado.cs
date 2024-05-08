using ClubeDaLeitura.ConsoleApp.Compartilhado;
namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal abstract class RepositorioCompartilhado
    {
        public List<EntidadeBase> RepositorioGlobal = new List<EntidadeBase>();

        public void Cadastrar(EntidadeBase novoRegistro)
        {
            RepositorioGlobal.Add(novoRegistro); // Já incrementa dentro da classe;
        }

        public bool Editar(int id, EntidadeBase novoRegistro, RepositorioCompartilhado Repositorio, DominioCompartilhado Dominio)
        {
            novoRegistro._ID = id;

            EntidadeBase buscador = Repositorio.RepositorioGlobal.FirstOrDefault( registro =>  registro._ID == id ); // Busca um _ID dentro do repositório global;

            if( buscador == null )
            {
                Console.WriteLine("Nenhum registro encontrado");
                return false;
            }

            Dominio.RequisitarDoBancoDeDados(buscador);
            //Dominio.SeletorDeBanco();
            return true;
        }

        public void MostrarRegistros(RepositorioCompartilhado Repositorio, DominioCompartilhado Dominio) { }
    }
}
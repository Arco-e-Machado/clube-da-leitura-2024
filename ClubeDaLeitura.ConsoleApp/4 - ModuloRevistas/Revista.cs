using ClubeDaLeitura.ConsoleApp.ModuloCaixas;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;


namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas
{
    public class Revista : EntidadeBase
    {
        public string titulo { get; set; }
        public int numeroDeEdicao { get; set; }
        public DateTime dataDeEdicao { get; set; }
        public Caixa repositorio { get; set; }

        public bool EstaEmprestada { get; set; }
        public Revista(string titulo, int numeroDeEdicao, Caixa repositorio, DateTime dataDeEdicao)
        {
            this.titulo = titulo;
            this.dataDeEdicao = dataDeEdicao;
            this.repositorio = repositorio;
            this.numeroDeEdicao = numeroDeEdicao;
            this.EstaEmprestada = false;
            repositorio.GuardarRevista(this);
        }
        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();
            var hoje = DateTime.Now;
            if (string.IsNullOrEmpty(titulo.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (numeroDeEdicao == 0 || numeroDeEdicao == null)
                erros.Add("O campo \"numero da edição\" é obrigatório");

            if (dataDeEdicao == null)
                erros.Add("O campo \"data de edição\" é obrigatório");

            return erros;
        }

        public string ConverterString(bool status)
        {
            if (status == true)
                return "Indisponivel";

            return "Disponível";
        }

        public void Emprestar()
        {
            EstaEmprestada = true;
        }

        public void Devolver()
        {
            EstaEmprestada = false;
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Revista registroNovo = (Revista)novoRegistro;

            this.titulo = registroNovo.titulo;
            this.dataDeEdicao = registroNovo.dataDeEdicao;
            this.numeroDeEdicao = registroNovo.numeroDeEdicao;
            this.repositorio = registroNovo.repositorio;
            this.EstaEmprestada = registroNovo.EstaEmprestada;
        }

    }
}
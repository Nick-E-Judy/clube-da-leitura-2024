using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    internal class Revista : EntidadeBase
    {
        public Revista(string titulo, int numeroEdicao, int ano)
        {
            Titulo = titulo;
            NumeroEdicao = numeroEdicao;
            Ano = ano;
            //Caixa = caixa;
        }

        public string Titulo { get; set; }

        public int NumeroEdicao { get; set; }

        public int Ano { get; set; }

        public Caixa Caixa { get; set; }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Titulo.Trim()))
                erros.Add("O campo \"titulo\" é obrigatório");

            if (NumeroEdicao != null)
                erros.Add("O campo \"número edição\" é obrigatório");

            if (Ano > 0 && Ano != null)
                erros.Add("O campo \"ano\" é obrigatório");

            if (Caixa != null)
                erros.Add("O campo \"caixa\" é obrigatório");

            return erros;
        }
    }
}
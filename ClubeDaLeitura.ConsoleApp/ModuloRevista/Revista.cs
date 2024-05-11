using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    internal class Revista : EntidadeBase
    {
        public Revista(string titulo, int numeroEdicao, int ano, Caixa caixa)
        {
            Titulo = titulo;
            NumeroEdicao = numeroEdicao;
            Ano = ano;
            Caixa = caixa;
            Caixa.GuardarRevista(this);
        }

        public string Titulo { get; set; }

        public int NumeroEdicao { get; set; }

        public int Ano { get; set; }

        public Caixa Caixa { get; set; }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Revista novasInformacoes = (Revista)novoRegistro;

            this.Titulo = novasInformacoes.Titulo;
            this.NumeroEdicao = novasInformacoes.NumeroEdicao;
            this.Ano = novasInformacoes.Ano;
            this.Caixa = novasInformacoes.Caixa;
        }

        public override List<String> Validar()
        {
            List<String> erros = [];

            if (string.IsNullOrEmpty(Titulo.Trim()))
                erros.Add("O campo \"titulo\" é obrigatório");

            if (NumeroEdicao <= 0)
                erros.Add("Informe um número de edição válido");

            if (Ano <= 0)
                erros.Add("Informe um ano válido");

            if (Caixa == null)
                erros.Add("Informe um ID válido");

            return erros;
        }
    }
}
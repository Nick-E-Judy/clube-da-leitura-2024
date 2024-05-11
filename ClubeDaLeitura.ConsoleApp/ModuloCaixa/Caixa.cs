using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class Caixa : EntidadeBase
    {
        public List<Revista> Revistas { get; set; }

        public string Cor { get; set; }

        public string Etiqueta { get; set; }

        public int TempoEmprestimo { get; set; }

        public int QuantidadeRevistas { get; set; }

        public Caixa(string cor, string etiqueta, int tempoEmprestimo)
        {
            Cor = cor;
            Etiqueta = etiqueta;
            TempoEmprestimo = tempoEmprestimo;
            Revistas = [];
        }

        public override List<String> Validar()
        {
            List<String> erros = [];

            if (string.IsNullOrEmpty(Cor.Trim()))
                erros.Add("O campo \"cor\" é obrigatório");

            if (string.IsNullOrEmpty(Etiqueta.Trim()))
                erros.Add("O campo \"etiqueta\" é obrigatório");

            if (TempoEmprestimo <= 0)
                erros.Add("Informe um tempo de empréstimo válido");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Caixa novasInformacoes = (Caixa)novoRegistro;

            this.Cor = novasInformacoes.Cor;
            this.Etiqueta = novasInformacoes.Etiqueta;
            this.TempoEmprestimo = novasInformacoes.TempoEmprestimo;
        }

        public void GuardarRevista(Revista revista)
        {
            
            Revistas.Add(revista);
        }
    }
}
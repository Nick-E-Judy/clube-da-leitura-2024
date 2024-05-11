using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;
using System.Numerics;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class Emprestimo : EntidadeBase
    {
        public Emprestimo(Amigo amigo, Revista revista)
        {
            Amigo = amigo;
            Revista = revista;
            Data = DateTime.Now;
            DataDevolucao = Data.AddDays(Revista.Caixa.TempoEmprestimo);
            Concluido = false;
        }

        public Amigo Amigo { get; set; }
        public Revista Revista { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataDevolucao { get; set; }
        public bool Concluido { get; set; }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Emprestimo novasInformacoes = (Emprestimo)novoRegistro;

            this.Amigo = novasInformacoes.Amigo;
            this.Revista = novasInformacoes.Revista;
        }

        public override List<String> Validar()
        {
            List<String> erros = [];

            if (Amigo == null)
                erros.Add("Informe um número válido");

            if (Revista == null)
            {
                erros.Add("Informe uma revista válida");
            }               

            return erros;
        }
        public bool VerificaData()
        {
            return DateTime.Now > DataDevolucao;
        }

    }
}
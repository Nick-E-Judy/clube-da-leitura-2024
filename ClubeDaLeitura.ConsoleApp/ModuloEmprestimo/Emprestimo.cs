using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

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
        }

        public Amigo Amigo { get; set; }

        public Revista Revista { get; set; }

        public bool Concluido { get; set; }

        public DateTime Data { get; set; }

        public DateTime DataDevolucao { get; set; }

        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            throw new NotImplementedException();
        }

        public override ArrayList Validar()
        {
            throw new NotImplementedException();
        }
        public bool Status()
        {
            return DateTime.Now > DataDevolucao;
        }
    }
}
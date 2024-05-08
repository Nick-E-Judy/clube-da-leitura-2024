using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo
    {
        public Amigo Amigo { get; set; }

        public Revista Revista { get; set; }

        public bool Concluido { get; set; }

        public DateTime Data { get; set; }

        public DateTime DataDevolucao { get; set; }
    }
}
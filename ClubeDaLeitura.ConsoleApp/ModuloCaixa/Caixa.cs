using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class Caixa
    {
        public Revista[] Revistas { get; set; }

        public string Cor { get; set; }

        public string Etiqueta { get; set; }

        public int TempoEmprestimo { get; set; }
    }
}
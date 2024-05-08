using ClubeDaLeitura.ConsoleApp.ModuloMulta;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class Amigo
    {
        public string Nome { get; set; }

        public string NomeResponsavel { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public Multa[] HistoricoMultas { get; set; }

        public void Validar()
        {

        }
    }
}
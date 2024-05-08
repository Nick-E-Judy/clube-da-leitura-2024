using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloMulta;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class Amigo
    {
        public string Nome { get; set; }

        public string NomeResponsavel { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public Multa[] HistoricoMultas { get; set; }

        public Amigo(string nome, string nomeResponsavel, string telefone, string endereco, Multa[] historicoMultas)
        {
            Nome = nome;
            NomeResponsavel = nomeResponsavel;
            Telefone = telefone;
            Endereco = endereco;
            HistoricoMultas = historicoMultas;
        }
    }
}
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    internal class Reserva : EntidadeBase
    {
        public Reserva(Amigo amigo, Revista revista)
        {
            dataAbertura = DateTime.Now;
            Amigo = amigo;
            Revista = revista;
            Expirada = Expirada = dataAbertura.AddDays(2); ;
        }

        public DateTime dataAbertura { get; set; }

        public Amigo Amigo { get; set; }

        public Revista Revista { get; set; }

        public DateTime Expirada { get; set; }

        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            throw new NotImplementedException();
        }

        public override ArrayList Validar()
        {
            //ArrayList erros = new ArrayList();

            //if (string.IsNullOrEmpty(Titulo.Trim()))
            //    erros.Add("O campo \"titulo\" é obrigatório");

            //if (NumeroEdicao != null)
            //    erros.Add("O campo \"número edição\" é obrigatório");

            //if (Ano > 0 && Ano != null)
            //    erros.Add("O campo \"ano\" é obrigatório");

            //if (Caixa != null)
            //    erros.Add("O campo \"caixa\" é obrigatório");

            //return erros;
            return null;
        }

        public bool Status()
        {
            return DateTime.Now > Expirada;
        }
    }
}
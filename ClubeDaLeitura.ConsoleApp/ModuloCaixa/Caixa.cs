using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class Caixa : EntidadeBase
    {
        public Revista[] Revistas { get; set; }

        public string Cor { get; set; }

        public string Etiqueta { get; set; }

        public int TempoEmprestimo { get; set; }

        public Caixa(Revista[] revistas, string cor, string etiqueta, int tempoEmprestimo)
        {
            Revistas = revistas;
            Cor = cor;
            Etiqueta = etiqueta;
            TempoEmprestimo = tempoEmprestimo;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Cor.Trim()))
                erros.Add("O campo \"cor\" é obrigatório");

            if (string.IsNullOrEmpty(Etiqueta.Trim()))
                erros.Add("O campo \"etiqueta\" é obrigatório");

            if (TempoEmprestimo <= 0)
                erros.Add("Informe um tempo de empréstimo válido");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            throw new NotImplementedException();
        }
    }
}
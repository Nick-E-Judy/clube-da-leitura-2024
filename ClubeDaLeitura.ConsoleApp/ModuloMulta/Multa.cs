using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloMulta
{
    internal class Multa : EntidadeBase
    {
        public Multa(bool estaPaga)
        {
            EstaPaga = estaPaga;
        }
        public bool EstaPaga { get; set; }



        public Multa GerarMultas(Emprestimo emprestimos)
        {
            if (emprestimos.DataDevolucao < DateTime.Now)
            {
                EstaPaga = false;
            }
            return null;
        }

        public override void AtualizarRegistro(EntidadeBase novoegistro)
        {
            throw new NotImplementedException();
        }

        public override ArrayList Validar()
        {
            throw new NotImplementedException();
        }
    }
}
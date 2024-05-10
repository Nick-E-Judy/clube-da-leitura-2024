using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloMulta
{
    internal class Multa : EntidadeBase
    {
        public Multa(bool estaPaga, decimal valor)
        {
            EstaPaga = estaPaga;
            Valor = valor;
        }
        public bool EstaPaga { get; set; }
        public decimal Valor {  get; set; }



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
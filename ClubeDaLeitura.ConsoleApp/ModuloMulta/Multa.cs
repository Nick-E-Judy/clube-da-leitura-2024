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

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            throw new NotImplementedException();
        }

        public override List<String> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
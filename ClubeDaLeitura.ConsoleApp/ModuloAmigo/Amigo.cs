using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloMulta;
using System.Collections;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    internal class Amigo : EntidadeBase
    {
        public Amigo(string nome, string nomeResponsavel, string telefone, string endereco)
        {
            Nome = nome;
            NomeResponsavel = nomeResponsavel;
            Telefone = telefone;
            Endereco = endereco;
        }

        public string Nome { get; set; }

        public string NomeResponsavel { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public ArrayList Multas { get; set; } = new ArrayList();

        public void GerarMultas(Emprestimo emprestimos)
        {
            if (emprestimos.DataDevolucao < DateTime.Now )
            {
                DateTime dataHoje = DateTime.Now;

                TimeSpan diferenca = dataHoje - emprestimos.DataDevolucao;

                decimal valor = diferenca.Days * 5;

                if(emprestimos.Concluido)
                    Multas.Add(new Multa(false, valor));
            }
       
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Amigo novasInformacoes = (Amigo)novoRegistro;

            this.Nome = novasInformacoes.Nome;
            this.NomeResponsavel = novasInformacoes.NomeResponsavel;
            this.Telefone = novasInformacoes.Telefone;
            this.Endereco = novasInformacoes.Endereco;
        }

        public override List<String> Validar()
        {
            List<String> erros = [];

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome responsável\" é obrigatório");

            if (string.IsNullOrEmpty(Telefone.Trim()))
                erros.Add("O campo \"telefone\" é obrigatório");

            if (string.IsNullOrEmpty(Endereco.Trim()))
                erros.Add("O campo \"endereço\" é obrigatório");

            return erros;
        }
    }
}
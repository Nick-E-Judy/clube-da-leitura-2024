﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    internal class TelaRevista : TelaBase
    {
        public TelaCaixa telaCaixa = null;

        public RepositorioCaixa repositorioCaixa = null;

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Revistas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "| {0, -10} | {1, -20} | {2, -25} | {3, -18} | {4, -25}",
                "Id", "Titulo", "Número da Edição", "Ano", "Caixa"
            );

            EntidadeBase[] revistasCadastradas = repositorio.SelecionarTodos();

            foreach (Revista revista in revistasCadastradas)
            {
                if (revista == null)
                    continue;

                Console.WriteLine(
                    "| {0, -10} | {1, -20} | {2, -25} | {3, -18} | {4, -25}",
                    revista.Id, revista.Titulo, revista.NumeroEdicao, revista.Ano, revista.Caixa
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o título da revista: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o número da edição da revista: ");
            int numeroEdicao = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o ano da revista: ");
            int ano = Convert.ToInt32(Console.ReadLine());

            //telaCaixa.VisualizarRegistros(false);

            //Console.Write("Digite o ID da caixa: ");
            //int idCaixa = Convert.ToInt32(Console.ReadLine());

            //Caixa caixaSelecionada = (Caixa)repositorioCaixa.SelecionarPorId(idCaixa);

            Revista novaRevista = new Revista(titulo, numeroEdicao, ano);

            return novaRevista;
        }

        public void CadastrarEntidadeTeste()
        {
            Revista revista = new Revista("Bobby Tables", 100, 2024);

            repositorio.Cadastrar(revista);
        }
    }
}

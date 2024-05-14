﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class TelaCaixa : TelaBase
    {
        public TelaRevista telaRevista = null;
        public RepositorioRevista repositorioRevista = null;
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Caixas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -20}",
                "Id", "Cor", "Etiqueta", "Qtd de Revistas"
            );

            List<EntidadeBase> caixasCadastradas = repositorio.SelecionarTodos();

            if (caixasCadastradas.Count == 0)
            {
                ExibirMensagem("Não há caixas cadastradas!", ConsoleColor.Red);
            }
            else
            {
                foreach (Caixa caixa in caixasCadastradas)
                {
                    Console.WriteLine(
                        "{0, -10} | {1, -20} | {2, -20} | {3, -20}",
                        caixa.Id, caixa.Cor, caixa.Etiqueta, caixa.Revistas.Count
                    );
                }
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            List<Revista> revistas = new List<Revista>();
            
            if (telaRevista != null)
            {
                telaRevista.VisualizarRegistros(false);

                while (true)
                {
                    Console.WriteLine("Digite o ID da Revista que vai adicionar na caixa (ou \"0\" para continuar)");
                    int idRevista = Convert.ToInt32(Console.ReadLine());
                    if (idRevista == 0)
                    {
                        break;
                    }

                    Revista revista = (Revista)repositorioRevista.SelecionarPorId(idRevista);
                    revistas.Add(revista);
                }
            }

            Console.Write("Digite a cor: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a etiqueta: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Digite o tempo de empréstimo: ");
            int tempoEmprestimo = Convert.ToInt32(Console.ReadLine());


            return new Caixa(nome, etiqueta, tempoEmprestimo);
        }
    }
}

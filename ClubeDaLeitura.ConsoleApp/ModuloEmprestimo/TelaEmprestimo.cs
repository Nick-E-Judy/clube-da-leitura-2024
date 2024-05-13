﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloMulta;
using ClubeDaLeitura.ConsoleApp.ModuloReserva;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class TelaEmprestimo : TelaBase
    {
        public TelaAmigo telaAmigo = null;
        public RepositorioAmigo repositorioAmigo = null;

        public TelaRevista telaRevista = null;
        public RepositorioRevista repositorioRevista = null;

        public RepositorioEmprestimo repositorioEmprestimo = null;

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Empréstimos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "| {0, -10} | {1, -15} | {2, -10} | {3, -20} | {4, -20} | {5, -10}",
                "Id", "Amigo", "Revista", "Data de empréstimo", "Data de devolução", "Concluido"
            );

            List<EntidadeBase> emprestimosCadastrados = repositorio.SelecionarTodos();

            if (emprestimosCadastrados.Count == 0)
            {
                ExibirMensagem("Não há empréstimos cadastrados!", ConsoleColor.Red);
            }
            else
            {

                foreach (Emprestimo emprestimo in emprestimosCadastrados)
                {
                    if (emprestimo == null)
                        continue;

                    Console.WriteLine(
                        "| {0, -10} | {1, -15} | {2, -10} | {3, -20} | {4, -20} | {5, -10}",
                        emprestimo.Id,
                        emprestimo.Amigo.Nome,
                        emprestimo.Revista.Titulo,
                        emprestimo.Data.ToShortDateString(),
                        emprestimo.DataDevolucao.ToShortDateString(),
                        emprestimo.Concluido
                    );

                }
            }
            Console.ReadLine();
        }

        public void VisualizarEmprestimosAbertos(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Empréstimos em Aberto...");
            }

            Console.WriteLine(
                "| {0, -10} | {1, -15} | {2, -10} | {3, -20} | {4, -20} | {5, -10}",
                "Id", "Amigo", "Revista", "Data de empréstimo", "Data de devolução", "Concluido"
            );

            List<EntidadeBase> emprestimosCadastrados = repositorio.SelecionarTodos();

            if (emprestimosCadastrados.Count == 0)
            {
                ExibirMensagem("Não há empréstimos em aberto!", ConsoleColor.Red);
            }
            else
            {

                foreach (Emprestimo emprestimo in emprestimosCadastrados)
                {
                    if (emprestimo.Concluido == false)
                    {
                        if (emprestimo == null)
                            continue;

                        Console.WriteLine(
                            "| {0, -10} | {1, -15} | {2, -10} | {3, -20} | {4, -20} | {5, -10}",
                            emprestimo.Id,
                            emprestimo.Amigo.Nome,
                            emprestimo.Revista.Titulo,
                            emprestimo.Data.ToShortDateString(),
                            emprestimo.DataDevolucao.ToShortDateString(),
                            emprestimo.Concluido
                        );
                    }
                }
            }
            Console.ReadLine();
        }

        public void VisualizarAmigosComMultas(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando amigos com multas...");
            }
            Console.WriteLine();

            Console.WriteLine(
                "| {0, -20} | {1, -15} | {2, -20} | {3, -30} | {4, -15} |",
                "Id do Empréstimo", "Id do amigo", "Nome do amigo", "Data de devolução prevista", "Data atual"
            );

            List<EntidadeBase> emprestimosCadastrados = repositorio.SelecionarTodos();
            if (emprestimosCadastrados.Count == 0)
            {
                ExibirMensagem("Não há empréstimos com multas em aberto!", ConsoleColor.Red);
            }
            else
            {

                foreach (Emprestimo emprestimo in emprestimosCadastrados)
                {
                    foreach (var multa in emprestimo.Amigo.Multas)
                    {
                        Multa multa1 = (Multa)multa;
                        if (!multa1.EstaPaga)
                        {
                            if (emprestimo == null)
                                continue;

                            Console.WriteLine(
                             "| {0, -20} | {1, -15} | {2, -20} | {3, -30} | {4, -15} |",
                             emprestimo.Id, emprestimo.Amigo.Id, emprestimo.Amigo.Nome, emprestimo.DataDevolucao.ToShortDateString(), DateTime.Now.ToShortDateString()
                         );
                        }
                    }

                }
            }
            Console.ReadLine();
        }
        public void DevolverRevista(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Devolver revistas...");
            }

            VisualizarRegistros(false);

            Console.Write("Digite o ID do empréstimo da revista que deseja devolver: ");
            int idEmprestimo = Convert.ToInt32(Console.ReadLine());

            ExibirMensagem("Revista devolvida com sucesso!", ConsoleColor.Green);

            Emprestimo emprestimoSelecionado = (Emprestimo)repositorioEmprestimo.SelecionarPorId(idEmprestimo);

            if (idEmprestimo != emprestimoSelecionado.Id)
                return;
                    
            emprestimoSelecionado.Concluido = true;

            emprestimoSelecionado.Amigo.GerarMultas(emprestimoSelecionado);
            
            

        }

        public void QuitarMultas()
        {
            VisualizarAmigosComMultas(false);

            Console.Write("Qual o Id do amigo que deseja quitar a multa? ");
            int IdAmigoMulta = Convert.ToInt32(Console.ReadLine());

            Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarPorId(IdAmigoMulta);

            foreach (var multa in amigoSelecionado.Multas)
            {
                Multa multa1 = (Multa)multa;

                if (!multa1.EstaPaga)
                {
                    multa1.EstaPaga = true;
                    ExibirMensagem("Multa quitada com sucesso!", ConsoleColor.Green);
                }
            }

            Console.ReadLine();

        }

        protected override EntidadeBase ObterRegistro()
        {
            telaAmigo.VisualizarRegistros(false);

            Console.Write("Digite o ID do amigo: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarPorId(idAmigo);

            if (repositorioEmprestimo.PossuiEmprestimoEmAberto(amigoSelecionado))
            {
                ExibirMensagem("O amigo já tem um empréstimo em aberto!", ConsoleColor.Red);
                Console.ReadLine();
                return null;
            }

            telaRevista.VisualizarRegistros(false);

            Console.Write("Digite o ID da revista: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Revista revistaSelecionada = (Revista)repositorioRevista.SelecionarPorId(idRevista);

            Emprestimo novoEmprestimo = new Emprestimo(amigoSelecionado, revistaSelecionada);

            return novoEmprestimo;

        }
    }
}
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloReserva;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloMulta;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            TelaAmigo telaAmigo = new TelaAmigo();
            telaAmigo.tipoEntidade = "Amigo";
            telaAmigo.repositorio = repositorioAmigo;
            telaAmigo.CadastrarEntidadeTeste();

            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo();
            telaEmprestimo.tipoEntidade = "Empréstimo";
            telaEmprestimo.repositorio = repositorioEmprestimo;

            telaEmprestimo.telaAmigo = telaAmigo;
            telaEmprestimo.repositorioAmigo = repositorioAmigo;

            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            repositorioCaixa.Cadastrar(new Caixa("Verde", "abc-123", 12));

            TelaCaixa telaCaixa = new TelaCaixa();
            telaCaixa.tipoEntidade = "Caixa";
            telaCaixa.repositorio = repositorioCaixa;

            RepositorioRevista repositorioRevista = new RepositorioRevista();
            TelaRevista telaRevista = new TelaRevista();
            telaRevista.tipoEntidade = "Revista";
            telaRevista.repositorio = repositorioRevista;


            telaCaixa.telaRevista = telaRevista;
            telaCaixa.repositorioRevista = repositorioRevista;
            
            telaRevista.telaCaixa = telaCaixa;
            telaRevista.repositorioCaixa = repositorioCaixa;


            RepositorioReserva repositorioReserva = new RepositorioReserva();
            TelaReserva telaReserva = new TelaReserva();
            telaReserva.tipoEntidade = "Reserva";
            telaReserva.repositorio = repositorioReserva;

            telaReserva.telaAmigo = telaAmigo;
            telaReserva.repositorioAmigo = repositorioAmigo;

            telaReserva.telaRevista = telaRevista;
            telaReserva.repositorioRevista = repositorioRevista;
            
            telaEmprestimo.telaRevista = telaRevista;
            telaEmprestimo.repositorioRevista = repositorioRevista;
            telaEmprestimo.repositorioEmprestimo = repositorioEmprestimo;


            while (true)
            {
                
                char opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                    break;

                TelaBase tela = null;

                if (opcaoPrincipalEscolhida == '1')
                    tela = telaAmigo;

                else if (opcaoPrincipalEscolhida == '2')
                    tela = telaCaixa;

                else if (opcaoPrincipalEscolhida == '3')
                    tela = telaRevista;

                else if (opcaoPrincipalEscolhida == '4')
                    tela = telaReserva;

                else if (opcaoPrincipalEscolhida == '5')
                    tela = telaEmprestimo;

                //else if (opcaoPrincipalEscolhida == '6')
                //    tela = telaRequisicaoEntrada;

                char operacaoEscolhida = tela.ApresentarMenu();

                if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                    continue;

                if (operacaoEscolhida == '1')
                    tela.Registrar();

                else if (operacaoEscolhida == '2')
                    tela.Editar();

                else if (operacaoEscolhida == '3')
                    tela.Excluir();

                else if (operacaoEscolhida == '4')
                    tela.VisualizarRegistros(true);

                else if (tela == telaEmprestimo && operacaoEscolhida == '5')
                    telaEmprestimo.DevolverRevista();

                else if (tela == telaEmprestimo && operacaoEscolhida == '6')
                    telaEmprestimo.VisualizarEmprestimosAbertos(true);

                else if (tela == telaEmprestimo && operacaoEscolhida == '7')
                    telaEmprestimo.VizualizarAmigosComMultas();
            }
            Console.ReadLine();
        }
    }
}
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    internal class TelaReserva : TelaBase
    {
        public TelaAmigo telaAmigo = null;
        public RepositorioAmigo repositorioAmigo = null;

        public TelaRevista telaRevista = null;
        public RepositorioRevista repositorioRevista = null;

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Reservas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "| {0, -10} | {1, -15} | {2, -10} | {3, -20} | {4, -20}",
                "Id", "Data da Reserva", "Status", "Amigo", "Revista"
            );

            ArrayList reservasCadastradas = repositorio.SelecionarTodos();

            foreach (Reserva reserva in reservasCadastradas)
            {
                if (reserva == null)
                    continue;

                Console.WriteLine(
                    "| {0, -10} | {1, -15} | {2, -10} | {3, -20} | {4, -20}",
                    reserva.Id,
                    reserva.dataAbertura.ToShortDateString(),
                    reserva.Status(), 
                    reserva.Amigo.Nome, 
                    reserva.Revista.Titulo
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaAmigo.VisualizarRegistros(false);

            Console.Write("Digite o ID do amigo: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarPorId(idAmigo);

            telaRevista.VisualizarRegistros(false);

            Console.Write("Digite o ID da revista: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Revista revistaSelecionada = (Revista)repositorioRevista.SelecionarPorId(idRevista);

            Reserva novaReserva = new Reserva(amigoSelecionado, revistaSelecionada);

            return novaReserva;
        }
    }
}

using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    internal class TelaAmigo : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Amigos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "| {0, -10} | {1, -20} | {2, -25} | {3, -18} | {4, -25} | {5, -15}",
                "Id", "Nome", "Nome do Responsável", "Telefone", "Endereço", "Multas"
            );

            EntidadeBase[] amigosCadastrados = repositorio.SelecionarTodos();

            foreach (Amigo amigo in amigosCadastrados)
            {
                if (amigo == null)
                    continue;

                Console.WriteLine(
                    "| {0, -10} | {1, -20} | {2, -25} | {3, -18} | {4, -25} | {5, -15}",
                    amigo.Id, amigo.Nome, amigo.NomeResponsavel, amigo.Telefone, amigo.Endereco, amigo.HistoricoMultas
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone do amigo: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereço do amigo: ");
            string endereco = Console.ReadLine();

            Amigo novoAmigo = new Amigo(nome, nomeResponsavel, telefone, endereco);

            return novoAmigo;
        }

        public void CadastrarEntidadeTeste()
        {
            Amigo amigo = new Amigo("Bobby Tables", "Mãe", "49 9999-9521", "R. Tal");

            repositorio.Cadastrar(amigo);
        }
    }
}

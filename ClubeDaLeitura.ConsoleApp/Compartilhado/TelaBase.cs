using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal abstract class TelaBase
    {
        public string tipoEntidade = "";
        public RepositorioBase repositorio = null;

        public virtual char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"        Gestão de {tipoEntidade}s        ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine($"1 - Cadastrar {tipoEntidade}");
            Console.WriteLine($"2 - Editar {tipoEntidade}");
            Console.WriteLine($"3 - Excluir {tipoEntidade}");
            Console.WriteLine($"4 - Visualizar {tipoEntidade}s");

            if (tipoEntidade == "Empréstimo")
            {
                Console.WriteLine($"5 - Devolver revista");
                Console.WriteLine($"6 - Visualizar {tipoEntidade}s em aberto");
                Console.WriteLine($"7 - Visualizar amigos com multas em aberto");
                Console.WriteLine($"8 - Quitar multas");
            }

            if (tipoEntidade == "Reserva")
            {
                Console.WriteLine($"9 - Cadastrar Empréstimos");
            }

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        protected void InserirRegistro(EntidadeBase entidade)
        {
            if (entidade == null)
            {
                return;
            }
            List<String> erros = entidade.Validar();

            if (erros.Count > 0)
            {
                ApresentarErros(erros);
                return;
            }

            repositorio.Cadastrar(entidade);

            ExibirMensagem($"O(A) {tipoEntidade} foi cadastrado(a) com sucesso!", ConsoleColor.Green);
        }

        public virtual void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            EntidadeBase entidade = ObterRegistro();

            InserirRegistro(entidade);
        }

        public void Editar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Editando {tipoEntidade}...");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write($"Digite o ID do(a) {tipoEntidade} que deseja editar: ");
            int idEntidadeEscolhida = Convert.ToInt32(Console.ReadLine());

            if (!repositorio.Existe(idEntidadeEscolhida))
            {
                ExibirMensagem($"O(A) {tipoEntidade} mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine();

            EntidadeBase entidade = ObterRegistro();

            List<String> erros = entidade.Validar();

            if (erros.Count > 0)
            {
                ApresentarErros(erros);
                return;
            }

            bool conseguiuEditar = repositorio.Editar(idEntidadeEscolhida, entidade);

            if (!conseguiuEditar)
            {
                ExibirMensagem($"Houve um erro durante a edição de {tipoEntidade}", ConsoleColor.Red);
                return;
            }

            ExibirMensagem($"O(A) {tipoEntidade} foi editado com sucesso!", ConsoleColor.Green);
        }

        public void Excluir()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Excluindo {tipoEntidade}...");

            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write($"Digite o ID do(a) {tipoEntidade} que deseja excluir: ");
            int idRegistroEscolhido = Convert.ToInt32(Console.ReadLine());

            if (!repositorio.Existe(idRegistroEscolhido))
            {
                ExibirMensagem($"O(A) {tipoEntidade} mencionado não existe!", ConsoleColor.DarkYellow);
                return;
            }

            bool conseguiuExcluir = repositorio.Excluir(idRegistroEscolhido);

            if (!conseguiuExcluir)
            {
                ExibirMensagem($"Houve um erro durante a exclusão do(a) {tipoEntidade}", ConsoleColor.Red);
                return;
            }

            ExibirMensagem($"O(A) {tipoEntidade} foi excluído com sucesso!", ConsoleColor.Green);
        }

        public abstract void VisualizarRegistros(bool exibirTitulo);

        protected void ApresentarErros(List<String> erros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < erros.Count; i++)
                Console.WriteLine(erros[i]);

            Console.ResetColor();
            Console.ReadLine();
        }

        protected void ApresentarCabecalho()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|          CLUBE DA LITERATURA          |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();
        }

        public void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine();

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }

        protected abstract EntidadeBase ObterRegistro();
    }
}

using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class RepositorioEmprestimo : RepositorioBase
    {
        public bool PossuiEmprestimoEmAberto(Amigo amigo)
        {
            foreach (Emprestimo emprestimo in registros)
            {
                if (emprestimo.Amigo == amigo && !emprestimo.Concluido)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

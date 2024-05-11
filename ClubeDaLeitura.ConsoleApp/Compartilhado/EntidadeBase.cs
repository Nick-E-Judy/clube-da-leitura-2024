using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal abstract class EntidadeBase
    {
        public int Id { get; set; }

        public abstract List<String> Validar();

        public abstract void AtualizarRegistro(EntidadeBase novoRegistro);
    }
}
namespace CleanArch.Domain;

public interface IClienteRepository
{
    Task<Cliente?> ObterPorId(int id);
    Task AtualizarSaldo(int valor);
}

namespace CleanArch.Domain;

public interface IClienteRepository
{
    Cliente? ObterPorId(int id);
    void AtualizarSaldo(int valor);
}

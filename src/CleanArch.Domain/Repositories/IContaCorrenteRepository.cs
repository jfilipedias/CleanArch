namespace CleanArch.Domain;

public interface IContaCorrenteRepository
{
    Task<ContaCorrente?> ObterPorNumero(string numero);
    Task AtualizarSaldo(int valor);
}

namespace CleanArch.Domain;

public interface ITransacaoRepository
{
    Task Criar(Transacao transacao);
}

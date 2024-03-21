namespace CleanArch.Domain;

public interface ITransacaoRepository
{
    Task Salvar(Transacao transacao);
}

namespace CleanArch.Domain;

public class NotificadorException : Exception
{
    public IList<Notificacao> Notificacoes;

    public NotificadorException(IList<Notificacao> notificacoes)
    {
        Notificacoes = notificacoes;
    }
}

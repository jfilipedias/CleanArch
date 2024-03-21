namespace CleanArch.Domain;

public class NotificadorException : Exception
{
    public IList<ErroNotificacao> ErrosNotificacao;

    public NotificadorException(IList<ErroNotificacao> errosNotificacao)
    {
        ErrosNotificacao = errosNotificacao;
    }
}

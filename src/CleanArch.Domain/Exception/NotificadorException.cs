namespace CleanArch.Domain;

public class NotificadorException : Exception
{
    public IEnumerable<ErroNotificacao> Erros;

    public NotificadorException(IEnumerable<ErroNotificacao> erros)
    {
        Erros = erros;
    }
}

namespace CleanArch.Domain;

public class NotificacaoException : Exception
{
    public IEnumerable<ErroNotificacao> Erros;

    public NotificacaoException(IEnumerable<ErroNotificacao> erros)
    {
        Erros = erros;
    }
}

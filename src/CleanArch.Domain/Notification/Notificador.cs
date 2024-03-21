namespace CleanArch.Domain;

public class Notificador
{
    private List<Notificacao> _notificacoes;

    public bool PossuiNotificacoes
    {
        get { return _notificacoes.Any(); }
    }

    public Notificador()
    {
        _notificacoes = new List<Notificacao>();
    }

    public void AdicionarNotificacao(string mensagem)
    {
        _notificacoes.Add(new Notificacao(mensagem));
    }

    public List<Notificacao> ObterNotificacoes()
    {
        return _notificacoes;
    }
}

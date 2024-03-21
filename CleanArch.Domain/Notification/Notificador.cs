namespace CleanArch.Domain;

public class Notificador
{
    private List<ErroNotificacao> _errosNotificacao;

    public bool PossuiErros
    {
        get { return _errosNotificacao.Any(); }
    }

    public Notificador()
    {
        _errosNotificacao = new List<ErroNotificacao>();
    }

    public void AdicionarErro(string error)
    {
        _errosNotificacao.Add(new ErroNotificacao(error));
    }

    public List<ErroNotificacao> ObterErros()
    {
        return _errosNotificacao;
    }
}

namespace CleanArch.Domain;

public class Notificacao
{
    private List<ErroNotificacao> _erros;

    public bool PossuiErros
    {
        get { return _erros.Any(); }
    }

    public Notificacao()
    {
        _erros = new List<ErroNotificacao>();
    }

    public void AdicionarErro(string propriedade, string mensagem)
    {
        _erros.Add(new ErroNotificacao(propriedade, mensagem));
    }

    public List<ErroNotificacao> ObterErros()
    {
        return _erros;
    }
}

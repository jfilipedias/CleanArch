namespace CleanArch.Domain;

public class Notificacao
{
    public List<ErroNotificacao> Erros { get; private set; } = new List<ErroNotificacao>();

    public bool PossuiErros
    {
        get { return Erros.Any(); }
    }

    public void AdicionarErro(ErroNotificacao erro)
    {
        Erros.Add(erro);
    }
}

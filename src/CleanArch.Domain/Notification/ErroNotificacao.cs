namespace CleanArch.Domain;

public class ErroNotificacao
{
    public string Propriedade { get; private set; } = string.Empty;
    public string Mensagem { get; private set; } = string.Empty;

    public ErroNotificacao(string propriedade, string mensagem)
    {
        Propriedade = propriedade;
        Mensagem = mensagem;
    }
}

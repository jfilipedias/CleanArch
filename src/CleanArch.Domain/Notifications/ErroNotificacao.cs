namespace CleanArch.Domain;

public class ErroNotificacao
{
    public string Propriedade { get; private set; }
    public string Mensagem { get; private set; }

    public ErroNotificacao(string propriedade, string mensagem)
    {
        Propriedade = propriedade;
        Mensagem = mensagem;
    }
}

namespace CleanArch.Domain;

public class ErroNotificacao
{
    public string Message { get; set; }

    public ErroNotificacao(string message)
    {
        Message = message;
    }
}

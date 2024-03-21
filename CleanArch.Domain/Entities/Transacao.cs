namespace CleanArch.Domain;

public class Transacao
{
    public int CustomerId { get; set; }
    public int Valor { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime RealizadaEm { get; set; }

    public Transacao(int valor, string tipo, string descricao)
    {
        Valor = valor;
        Tipo = tipo;
        Descricao = descricao;
        RealizadaEm = DateTime.Now;

        var resultado = Validar();
        if (resultado.PossuiNotificacoes) throw new NotificadorException(resultado.ObterNotificacoes());
    }

    private Notificador Validar()
    {
        var notificador = new Notificador();
        if (Valor <= 0) notificador.AdicionarNotificacao("O valor da transação deve ser maior que 0.");
        if (string.IsNullOrEmpty(Tipo) || (Tipo != "c" && Tipo != "d")) notificador.AdicionarNotificacao("O tipo da transação deve ser 'c' ou 'd'.");
        if (string.IsNullOrEmpty(Descricao) || Descricao.Length > 10) notificador.AdicionarNotificacao("A descricao deve ter entre 1 e 10 caracteres.");
        return notificador;
    }
}

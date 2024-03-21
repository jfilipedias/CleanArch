namespace CleanArch.Domain;

public class Transacao
{
    public Notificador _notificador { get; }
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
        _notificador = new Notificador();

        Validar();
        if (_notificador.PossuiNotificacoes) throw new NotificadorException(_notificador.ObterNotificacoes());
    }

    private void Validar()
    {
        if (Valor <= 0) _notificador.AdicionarNotificacao("O valor da transação deve ser maior que 0.");
        if (string.IsNullOrEmpty(Tipo) || (Tipo != "c" && Tipo != "d")) _notificador.AdicionarNotificacao("O tipo da transação deve ser 'c' ou 'd'.");
        if (string.IsNullOrEmpty(Descricao) || Descricao.Length > 10) _notificador.AdicionarNotificacao("A descricao deve ter entre 1 e 10 caracteres.");
    }
}

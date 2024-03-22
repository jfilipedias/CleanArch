namespace CleanArch.Domain;

public class Transacao
{
    public int Id { get; set; }
    public string NumeroContaCorrente { get; set; } = string.Empty;
    public int Valor { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime RealizadaEm { get; set; }

    public Transacao(string numeroContaCorrente, int valor, string tipo, string descricao)
    {
        NumeroContaCorrente = numeroContaCorrente;
        Valor = valor;
        Tipo = tipo;
        Descricao = descricao;
        RealizadaEm = DateTime.Now;

        Validar();
    }

    private void Validar()
    {
        var Notificacao = new Notificacao();

        if (Valor <= 0) Notificacao.AdicionarErro("Valor", "O valor da transação deve ser maior que 0.");
        if (string.IsNullOrEmpty(Tipo) || (Tipo != "c" && Tipo != "d")) Notificacao.AdicionarErro("Tipo", "O tipo da transação deve ser 'c' ou 'd'.");
        if (string.IsNullOrEmpty(Descricao) || Descricao.Length > 10) Notificacao.AdicionarErro("Descricao", "A descricao deve ter entre 1 e 10 caracteres.");

        if (Notificacao.PossuiErros) throw new NotificadorException(Notificacao.ObterErros());
    }
}

namespace CleanArch.Domain;

public class Transacao
{
    public Guid Id { get; private set; }
    public string NumeroContaCorrente { get; set; }
    public string Descricao { get; set; }
    public string Tipo { get; set; }
    public int Valor { get; set; }
    public DateTime RealizadoEm { get; set; }

    public Transacao(string numeroContaCorrente, string descricao, string tipo, int valor)
    {
        Id = Guid.NewGuid();
        NumeroContaCorrente = numeroContaCorrente;
        Descricao = descricao;
        Tipo = tipo;
        Valor = valor;
        RealizadoEm = DateTime.Now;

        Validar();
    }

    public void Validar()
    {
        var notificacao = new Notificacao();

        if (string.IsNullOrEmpty(NumeroContaCorrente))
            notificacao.AdicionarErro(new ErroNotificacao("NumeroContaCorrente", "Deve ser informado o numero da conta corrente."));

        if (Tipo != "c" && Tipo != "d")
            notificacao.AdicionarErro(new ErroNotificacao("Tipo", "O tipo da transação deve ser 'c' ou 'd'."));

        if (string.IsNullOrEmpty(Descricao) || Descricao.Length > 10)
            notificacao.AdicionarErro(new ErroNotificacao("Descricao", "A descricao deve possuir entre 1 e 10 caracteres."));

        if (Valor <= 0)
            notificacao.AdicionarErro(new ErroNotificacao("Valor", "O valor da transacao precisa ser maior que 0."));

        if (notificacao.PossuiErros) throw new NotificacaoException(notificacao.Erros);
    }
}


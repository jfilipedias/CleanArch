namespace CleanArch.Domain;

public class Transacao
{
    public int CustomerId { get; set; }
    public int Valor { get; set; }
    public char Tipo { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public DateTime RealizadaEm { get; set; }

    public Transacao(int valor, char tipo, string descricao)
    {
        Valor = valor;
        Tipo = tipo;
        Descricao = descricao;
        RealizadaEm = DateTime.Now;
    }

    public void Validar()
    {
        if (Tipo != 'c' || Tipo != 'd') throw new Exception();

        if (string.IsNullOrEmpty(Descricao) || Descricao.Length > 10) throw new Exception();
    }
}

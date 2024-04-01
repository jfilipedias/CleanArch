namespace CleanArch.Application;

public class CriarTransacaoInput
{
    public string Descricao { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public int Valor { get; set; }
}

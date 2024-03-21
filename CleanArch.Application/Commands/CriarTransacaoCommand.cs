using System.Text.Json.Serialization;

namespace CleanArch.Application;

public class CriarTransacaoCommand
{
    [JsonPropertyName("valor")]
    public int Valor { get; set; }

    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = string.Empty;

    [JsonPropertyName("descricao")]
    public string Descricao { get; set; } = string.Empty;

}

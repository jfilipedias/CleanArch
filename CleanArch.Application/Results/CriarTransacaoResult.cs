using System.Text.Json.Serialization;

namespace CleanArch.Application;

public class CriarTransacaoResult
{

    [JsonPropertyName("saldo")]
    public int Saldo { get; set; }
    [JsonPropertyName("limite")]
    public int Limite { get; set; }
}

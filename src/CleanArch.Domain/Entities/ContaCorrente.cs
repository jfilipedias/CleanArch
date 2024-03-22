namespace CleanArch.Domain;

public class ContaCorrente
{
    public string NumeroContaCorrente { get; set; } = string.Empty;
    public int Saldo { get; set; }
    public int LimiteExtra { get; set; }

    public ContaCorrente(string numeroContaCorrente, int limiteExtra)
    {
        NumeroContaCorrente = numeroContaCorrente;
        LimiteExtra = limiteExtra;
    }

    public void Debitar(int valor)
    {
        if (Saldo + LimiteExtra - valor <= 0) throw new SaldoInsuficienteException();
        Saldo -= valor;
    }

    public void Creditar(int valor)
    {
        Saldo += valor;
    }
}

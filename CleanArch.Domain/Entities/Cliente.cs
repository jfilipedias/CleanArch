namespace CleanArch.Domain;

public class Cliente
{
    public int Id { get; set; }
    public int Saldo { get; set; }
    public int Limite { get; set; }

    public void Debitar(int valor)
    {
        if (Limite + Saldo - valor < 0) throw new Exception("Cliente com saldo insuficiente.");
        Saldo -= valor;
    }

    public void Creditar(int valor)
    {
        Saldo += valor;
    }
}

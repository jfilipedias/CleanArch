namespace CleanArch.Domain;

public class SaldoInsuficienteException : Exception
{
    public SaldoInsuficienteException(string message = "Cliente com saldo insuficiente.") : base(message)
    { }
}
namespace CleanArch.Domain;

public class SaldoInsuficienteException : Exception
{
    public SaldoInsuficienteException() : base("O cliente não possui saldo disponível") { }
}

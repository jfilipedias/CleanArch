using CleanArch.Domain;

namespace CleanArch.UnitTests;

public class ContaCorrenteTeste
{
    [Fact]
    [Trait("Domínio", "ContaCorrente")]
    public void Debito_DeveAtualizarSaldo()
    {
        var cliente = new ContaCorrente()
        {
            Id = 1,
            Limite = 100_00,
            Saldo = 0_00
        };
        cliente.Debitar(50_00);

        Assert.Equal(-50_00, cliente.Saldo);
    }

    [Fact]
    [Trait("Domínio", "ContaCorrente")]
    public void Debitar_DeveLancarExcecaoCasoNaoTenhaLimiteDisponivel()
    {
        var contaCorrente = new ContaCorrente()
        {
            Id = 1,
            Limite = 100_00,
            Saldo = -99_00
        };

        Assert.Throws<SaldoInsuficienteException>(() => contaCorrente.Debitar(2_00));
    }

    [Fact]
    [Trait("Domínio", "ContaCorrente")]
    public void Creditar_DeveAdicionarSaldo()
    {
        var contaCorrente = new ContaCorrente()
        {
            Id = 1,
            Limite = 100_00,
            Saldo = 0_00
        };
        contaCorrente.Creditar(50_00);

        Assert.Equal(50_00, contaCorrente.Saldo);
    }
}

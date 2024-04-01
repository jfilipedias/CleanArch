using CleanArch.Domain;

namespace CleanArch.UnitTest;

public class ContaCorrenteTest
{
    [Fact]
    public void Debitar_DeveAtualizarOSaldo()
    {
        var contaCorrente = new ContaCorrente("1234", 100_00);
        contaCorrente.Debitar(10_00);
        Assert.Equal(-10_00, contaCorrente.Saldo);
    }

    [Fact]
    public void Debitar_DeveLancarExcecaoQuandoEstouraLimite()
    {
        var contaCorrente = new ContaCorrente("1234", 100_00);
        Assert.Throws<SaldoInsuficienteException>(() => contaCorrente.Debitar(101_00));
    }

    [Fact]
    public void Creditar_DeveAtualizarOSaldo()
    {
        var contaCorrente = new ContaCorrente("1234", 100_00);
        contaCorrente.Creditar(250_00);
        Assert.Equal(250_00, contaCorrente.Saldo);
    }
}

using CleanArch.Domain;

namespace CleanArch.UnitTests;

[Collection(nameof(ContaCorrenteTestFixtureCollection))]
public class ContaCorrenteTest
{
    private readonly ContaCorrenteTestFixture _contaCorrenteTestFixture;

    public ContaCorrenteTest(ContaCorrenteTestFixture contaCorrenteTestFixture)
    {
        _contaCorrenteTestFixture = contaCorrenteTestFixture;
    }

    [Fact]
    [Trait("Domínio", "ContaCorrente")]
    public void Debito_DeveAtualizarSaldo()
    {
        var contaCorrente = _contaCorrenteTestFixture.ObterContaCorrente(100_00, 0);
        contaCorrente.Debitar(50_00);

        Assert.Equal(50_00, contaCorrente.Saldo);
    }

    [Fact]
    [Trait("Domínio", "ContaCorrente")]
    public void Debito_PodeNegativarSaldoSeTiverLimite()
    {
        var contaCorrente = _contaCorrenteTestFixture.ObterContaCorrente(0, 100_00);
        contaCorrente.Debitar(50_00);

        Assert.Equal(-50_00, contaCorrente.Saldo);
    }



    [Fact]
    [Trait("Domínio", "ContaCorrente")]
    public void Debito_DeveLancarExcecaoCasoNaoTenhaLimiteDisponivel()
    {
        var contaCorrente = _contaCorrenteTestFixture.ObterContaCorrente(100_00, -99_00);
        Assert.Throws<SaldoInsuficienteException>(() => contaCorrente.Debitar(2_00));
    }

    [Fact]
    [Trait("Domínio", "ContaCorrente")]
    public void Credito_DeveAdicionarSaldo()
    {
        var contaCorrente = _contaCorrenteTestFixture.ObterContaCorrente(0, 0);
        contaCorrente.Creditar(50_00);

        Assert.Equal(50_00, contaCorrente.Saldo);
    }
}

using System.Runtime.CompilerServices;
using CleanArch.Domain;

namespace CleanArch.UnitTests;

[CollectionDefinition(nameof(ContaCorrenteTestFixtureCollection))]
public class ContaCorrenteTestFixtureCollection : ICollectionFixture<ContaCorrenteTestFixture> { }

public class ContaCorrenteTestFixture
{
    public ContaCorrente ObterContaCorrente(int saldo, int limite)
    {
        return new ContaCorrente()
        {
            Id = 1,
            Saldo = saldo,
            Limite = limite,
        };
    }
}

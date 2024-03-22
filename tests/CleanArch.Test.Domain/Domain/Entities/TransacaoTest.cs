using CleanArch.Domain;

namespace CleanArch.UnitTests;

public class TransacaoTest
{
    [Fact]
    [Trait("Domínio", "Transacao")]
    public void Instanciar_DeveValidarValor()
    {
        var transacaoAction = () => new Transacao("0125", 0, "d", "pagamento");
        var ex = Assert.Throws<NotificacaoException>(transacaoAction);

        var errosValidacao = new List<ErroNotificacao>() {
            new ErroNotificacao("Valor", "O valor da transação deve ser maior que 0.")
        };

        Assert.Single(ex.Erros);
        Assert.Equal("Valor", ex.Erros.First().Propriedade);
        Assert.Equal("O valor da transação deve ser maior que 0.", ex.Erros.First().Mensagem);
    }
}

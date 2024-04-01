using CleanArch.Domain;

namespace CleanArch.UnitTest;

public class TransacaoTest
{
    [Fact]
    public void Validar_DeveNotificarTipoInvalido()
    {
        var action = () => new Transacao("pix", "z", 1_00);
        var ex = Assert.Throws<NotificacaoException>(action);

        Assert.Single(ex.Erros);
        Assert.Equal("Tipo", ex.Erros.First().Propriedade);
        Assert.Equal("O tipo da transação deve ser 'c' ou 'd'.", ex.Erros.First().Mensagem);
    }
}

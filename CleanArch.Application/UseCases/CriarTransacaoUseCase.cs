using CleanArch.Domain;

namespace CleanArch.Application;

public class CriarTransacao
{
    private IClienteRepository _clienteRepsitory;
    private ITransacaoRepository _transacaoRepsitory;

    public CriarTransacao(IClienteRepository clienteRepository, ITransacaoRepository transacaoRepository)
    {
        _clienteRepsitory = clienteRepository;
        _transacaoRepsitory = transacaoRepository;
    }

    public CriarTransacaoOutDTO Executar(int valor, char tipo, string descricao, int clienteId)
    {
        var transacao = new Transacao(valor, tipo, descricao);
        transacao.Validar();

        var cliente = _clienteRepsitory.ObterPorId(clienteId);
        if (transacao.Tipo == 'c') cliente.Creditar(transacao.Valor);
        if (transacao.Tipo == 'd') cliente.Debitar(transacao.Valor);

        _clienteRepsitory.AtualizarSaldo(cliente.Saldo);
        _transacaoRepsitory.Salvar(transacao);

        var criarTransacaoOutDTO = new CriarTransacaoOutDTO()
        {
            Saldo = cliente.Saldo,
            Limite = cliente.Limite
        };

        return criarTransacaoOutDTO;
    }
}

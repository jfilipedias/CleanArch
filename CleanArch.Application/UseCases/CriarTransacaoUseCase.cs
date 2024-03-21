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

    public CriarTransacaoResult Executar(int clienteId, CriarTransacaoCommand criarTransacaoCommand)
    {
        var transacao = new Transacao(criarTransacaoCommand.Valor, criarTransacaoCommand.Tipo, criarTransacaoCommand.Descricao);

        var cliente = _clienteRepsitory.ObterPorId(clienteId);
        if (transacao.Tipo == "c") cliente.Creditar(transacao.Valor);
        if (transacao.Tipo == "d") cliente.Debitar(transacao.Valor);

        _clienteRepsitory.AtualizarSaldo(cliente.Saldo);
        _transacaoRepsitory.Salvar(transacao);

        var criarTransacaoResult = new CriarTransacaoResult()
        {
            Saldo = cliente.Saldo,
            Limite = cliente.Limite
        };

        return criarTransacaoResult;
    }
}

using CleanArch.Domain;

namespace CleanArch.Application;

public class CriarTransacao
{
    private IClienteRepository _clienteRepsitory;
    private ITransacaoRepository _transacaoRepsitory;
    private IUnitOfWork _unityOfWork;

    public CriarTransacao(IClienteRepository clienteRepository, ITransacaoRepository transacaoRepository, IUnitOfWork unityOfWork)
    {
        _clienteRepsitory = clienteRepository;
        _transacaoRepsitory = transacaoRepository;
        _unityOfWork = unityOfWork;
    }

    public CriarTransacaoOutput Executar(int clienteId, CriarTransacaoInput input)
    {
        var cliente = _clienteRepsitory.ObterPorId(clienteId);
        if (cliente == null) throw new NaoEncontradoException("Cliente não encontrado");

        var transacao = new Transacao(input.Valor, input.Tipo, input.Descricao);

        if (transacao.Tipo == "c") cliente.Creditar(transacao.Valor);
        if (transacao.Tipo == "d") cliente.Debitar(transacao.Valor);

        try
        {
            _unityOfWork.BeginTransaction();
            _clienteRepsitory.AtualizarSaldo(cliente.Saldo);
            _transacaoRepsitory.Salvar(transacao);
            _unityOfWork.Commit();
        }
        catch
        {
            _unityOfWork.Rollback();
            throw;
        }

        return new CriarTransacaoOutput()
        {
            Saldo = cliente.Saldo,
            Limite = cliente.Limite
        };
    }
}

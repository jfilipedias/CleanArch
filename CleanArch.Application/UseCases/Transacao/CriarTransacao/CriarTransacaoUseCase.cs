using CleanArch.Domain;

namespace CleanArch.Application;

public class CriarTransacao
{
    private IClienteRepository _clienteRepository;
    private ITransacaoRepository _transacaoRepository;
    private IUnitOfWork _unityOfWork;

    public CriarTransacao(IClienteRepository clienteRepository, ITransacaoRepository transacaoRepository, IUnitOfWork unityOfWork)
    {
        _clienteRepository = clienteRepository;
        _transacaoRepository = transacaoRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<CriarTransacaoOutput> Executar(int clienteId, CriarTransacaoInput input)
    {
        var cliente = await _clienteRepository.ObterPorId(clienteId);
        if (cliente == null) throw new NaoEncontradoException("Cliente não encontrado");

        var transacao = new Transacao(input.Valor, input.Tipo, input.Descricao);

        if (transacao.Tipo == "c") cliente.Creditar(transacao.Valor);
        if (transacao.Tipo == "d") cliente.Debitar(transacao.Valor);

        try
        {
            _unityOfWork.BeginTransaction();
            await _clienteRepository.AtualizarSaldo(cliente.Saldo);
            await _transacaoRepository.Salvar(transacao);
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

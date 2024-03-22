using CleanArch.Domain;

namespace CleanArch.Application;

public class CriarTransacao
{
    private IContaCorrenteRepository _contaCorrenteRepository;
    private ITransacaoRepository _transacaoRepository;
    private IUnitOfWork _unityOfWork;

    public CriarTransacao(IContaCorrenteRepository contaCorrenteRepository, ITransacaoRepository transacaoRepository, IUnitOfWork unityOfWork)
    {
        _contaCorrenteRepository = contaCorrenteRepository;
        _transacaoRepository = transacaoRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<CriarTransacaoOutput> Executar(string numeroContaCorrente, CriarTransacaoInput input)
    {
        var contaCorrente = await _contaCorrenteRepository.ObterPorNumero(numeroContaCorrente);
        if (contaCorrente == null) throw new NaoEncontradoException("Cliente não encontrado");

        var transacao = new Transacao(numeroContaCorrente, input.Valor, input.Tipo, input.Descricao);

        if (transacao.Tipo == "c") contaCorrente.Creditar(transacao.Valor);
        if (transacao.Tipo == "d") contaCorrente.Debitar(transacao.Valor);

        try
        {
            await _unityOfWork.BeginTransaction();
            await _contaCorrenteRepository.AtualizarSaldo(contaCorrente.Saldo);
            await _transacaoRepository.Salvar(transacao);
            await _unityOfWork.Commit();
        }
        catch
        {
            await _unityOfWork.Rollback();
            throw;
        }

        return new CriarTransacaoOutput()
        {
            Saldo = contaCorrente.Saldo,
            Limite = contaCorrente.Limite
        };
    }
}

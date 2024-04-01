using CleanArch.Domain;

namespace CleanArch.Application;

public class CriarTransacaoUseCase
{
    private IContaCorrenteRepository _contaCorrenteRepository;
    private ITransacaoRepository _transacaoRepository;
    private IUnitOfWork _unitOfWork;

    public CriarTransacaoUseCase(IContaCorrenteRepository contaCorrenteRepository, ITransacaoRepository transacaoRepository, IUnitOfWork unitOfWork)
    {
        _contaCorrenteRepository = contaCorrenteRepository;
        _transacaoRepository = transacaoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CriarTransacaoOutput> Executar(string numeroContaCorrente, CriarTransacaoInput input)
    {
        var contaCorrente = await _contaCorrenteRepository.ObterPorNumero(numeroContaCorrente);
        if (contaCorrente == null) throw new Exception();

        var transacao = new Transacao(numeroContaCorrente, input.Descricao, input.Tipo, input.Valor);

        if (transacao.Tipo == "c")
            contaCorrente.Creditar(transacao.Valor);
        else
            contaCorrente.Debitar(transacao.Valor);

        try
        {
            await _unitOfWork.Begin();
            await _transacaoRepository.Criar(transacao);
            await _contaCorrenteRepository.Alterar(contaCorrente);
            await _unitOfWork.Commit();
        }
        catch
        {
            await _unitOfWork.Rollback();
            throw;
        }

        return new CriarTransacaoOutput()
        {
            Saldo = contaCorrente.Saldo,
            Limit = contaCorrente.LimiteExtra
        };
    }
}

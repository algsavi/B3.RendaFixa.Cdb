using B3.RendaFixa.Cdb.Aplicacao.Compartilhados;
using B3.RendaFixa.Cdb.Aplicacao.DTOs;

namespace B3.RendaFixa.Cdb.Aplicacao.Interfaces
{
    public interface ICalcularCdb
    {
        Task<Resultado<CdbResposta>> CalcularAsync(CdbRequisicao request, CancellationToken ct);
    }
}

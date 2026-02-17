using B3.RendaFixa.Cdb.Aplicacao.Compartilhados;
using B3.RendaFixa.Cdb.Aplicacao.DTOs;
using B3.RendaFixa.Cdb.Aplicacao.Interfaces;
using B3.RendaFixa.Cdb.Dominio.Entidades;
using B3.RendaFixa.Cdb.Dominio.Excessoes;
using B3.RendaFixa.Cdb.Dominio.ValueObjects;

namespace B3.RendaFixa.Cdb.Aplicacao.Servicos
{
    public class CalcularCdbServico : ICalcularCdb
    {
        public Task<Resultado<CdbResposta>> CalcularAsync(CdbRequisicao request, CancellationToken ct)
        {
            if (request.ValorInicial <= 0)
                return Task.FromResult(
                    Resultado<CdbResposta>.Falha("Valor inicial deve ser positivo.")
                );

            if (request.PrazoEmMeses <= 1)
                return Task.FromResult(
                    Resultado<CdbResposta>.Falha("Prazo deve ser maior que 1 mês.")
                );

            try
            {
                var investimento = new CdbInvestmento(
                    new Dinheiro(request.ValorInicial),
                    request.PrazoEmMeses
                );

                var response = new CdbResposta
                {
                    ValorBruto = investimento.ValorBruto.Valor,
                    ValorLiquido = investimento.ValorLiquido.Valor
                };

                return Task.FromResult(Resultado<CdbResposta>.Sucesso(response));
            }
            catch (DominioException ex)
            {
                return Task.FromResult(Resultado<CdbResposta>.Falha(ex.Message));
            }
            catch (Exception ex)
            {
                return Task.FromResult(Resultado<CdbResposta>.Falha(ex.Message));
            }
        }
    }
}

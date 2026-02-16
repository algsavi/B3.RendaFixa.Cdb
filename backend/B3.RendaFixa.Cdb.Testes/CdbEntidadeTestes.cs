using B3.RendaFixa.Cdb.Dominio.Entidades;
using B3.RendaFixa.Cdb.Dominio.Excessoes;
using B3.RendaFixa.Cdb.Dominio.ValueObjects;

namespace B3.RendaFixa.Cdb.Testes
{
    public class CdbEntidadeTestes
    {
        [Fact]
        public void Deve_calcular_valor_bruto_e_liquido_corretamente()
        {
            var investimento = new CdbInvestmento(new Dinheiro(1000m), 12);

            Assert.True(investimento.ValorBruto?.Value > 1000m);
            Assert.True(investimento.ValorLiquido?.Value < investimento.ValorBruto.Value);
        }

        [Theory]
        [InlineData(6, 0.225)]
        [InlineData(12, 0.20)]
        [InlineData(24, 0.175)]
        [InlineData(30, 0.15)]
        public void Deve_aplicar_taxa_correta(int meses, decimal taxaEsperada)
        {
            var investimento = new CdbInvestmento(new Dinheiro(1000m), meses);

            var lucro = investimento.ValorBruto.Subtract(investimento.ValorInicial);
            var taxaAplicada = investimento.ValorImposto.Value / lucro.Value;

            var taxaNormalizada = Math.Round(taxaAplicada, 3);

            Assert.Equal(taxaEsperada, taxaNormalizada);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void Deve_lancar_excecao_quando_prazo_for_menor_ou_igual_a_1(int prazo)
        {
            Assert.Throws<DominioException>(() =>
                new CdbInvestmento(new Dinheiro(1000m), prazo)
            );
        }
    }
}
using B3.RendaFixa.Cdb.Dominio.Excessoes;
using B3.RendaFixa.Cdb.Dominio.ValueObjects;

namespace B3.RendaFixa.Cdb.Testes
{
    public class DinheiroValueObjectTestes
    {
        [Fact]
        public void Deve_criar_dinheiro_com_valor_arredondado_para_2_casas()
        {
            var dinheiro = new Dinheiro(10.555m);

            Assert.Equal(10.56m, dinheiro.Valor);
        }

        [Fact]
        public void Deve_lancar_excecao_quando_valor_for_negativo()
        {
            Assert.Throws<DominioException>(() =>
                new Dinheiro(-10m));
        }

        [Fact]
        public void Deve_somar_valores_corretamente()
        {
            var valor1 = new Dinheiro(100m);
            var valor2 = new Dinheiro(50m);

            var resultado = valor1.Adicionar(valor2);

            Assert.Equal(150m, resultado.Valor);
        }

        [Fact]
        public void Deve_subtrair_valores_corretamente()
        {
            var valor1 = new Dinheiro(200m);
            var valor2 = new Dinheiro(50m);

            var resultado = valor1.Subtrair(valor2);

            Assert.Equal(150m, resultado.Valor);
        }

        [Fact]
        public void Deve_multiplicar_corretamente()
        {
            var valor = new Dinheiro(100m);

            var resultado = valor.Multiplicar(2m);

            Assert.Equal(200m, resultado.Valor);
        }

        [Fact]
        public void Deve_lancar_excecao_quando_fator_multiply_for_negativo()
        {
            var valor = new Dinheiro(100m);

            Assert.Throws<DominioException>(() =>
                valor.Multiplicar(-2m));
        }

        [Fact]
        public void Deve_formatar_para_string_com_duas_casas_decimais()
        {
            var valor = new Dinheiro(100m);

            var texto = valor.ToString();

            Assert.Equal("100,00", texto);
        }
    }
}

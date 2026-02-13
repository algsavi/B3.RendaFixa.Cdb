using B3.RendaFixa.Cdb.Dominio.Excessoes;
using B3.RendaFixa.Cdb.Dominio.ValueObjects;

namespace B3.RendaFixa.Cdb.Dominio.Entidades
{
    public class CdbInvestmento
    {
        private const decimal CDI = 0.009m; 
        private const decimal TB = 1.08m;

        public Dinheiro ValorInicial { get; }
        public int PrazoEmMeses { get; }

        public Dinheiro ValorBruto { get; private set; } = default!;
        public Dinheiro ValorLiquido { get; private set; } = default!;
        public Dinheiro ValorImposto { get; private set; } = default!;

        public CdbInvestmento(Dinheiro valorIniciar, int prazoEmMeses)
        {
            if (prazoEmMeses <= 1)
                throw new DominioException("O prazo deve ser maior que 1 mês.");

            ValorInicial = valorIniciar;
            PrazoEmMeses = prazoEmMeses;

            ValorBruto = valorIniciar;
            ValorLiquido = valorIniciar;
            ValorImposto = new Dinheiro(0);

            Calcular();
        }

        private void Calcular()
        {
            var valorAtual = ValorInicial;

            var taxaMensal = 1 + (CDI * TB);

            for (int i = 0; i < PrazoEmMeses; i++)
            {
                valorAtual = valorAtual.Multiply(taxaMensal);
            }

            ValorBruto = valorAtual;

            var lucro = ValorBruto.Subtract(ValorInicial);
            var valorImposto = RetornarImposto();

            ValorImposto = lucro.Multiply(valorImposto);
            ValorLiquido = new Dinheiro(ValorBruto.Value - ValorImposto.Value);
        }

        private decimal RetornarImposto()
        {
            if (PrazoEmMeses <= 6)
                return 0.225m;

            if (PrazoEmMeses <= 12)
                return 0.20m;

            if (PrazoEmMeses <= 24)
                return 0.175m;

            return 0.15m;
        }
    }
}

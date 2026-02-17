using B3.RendaFixa.Cdb.Dominio.Excessoes;

namespace B3.RendaFixa.Cdb.Dominio.ValueObjects;

public sealed class Dinheiro
{
    public decimal Valor { get; }

    public Dinheiro(decimal valor)
    {
        if (valor < 0)
            throw new DominioException("Valor monetário não pode ser negativo.");

        Valor = Math.Round(valor, 2, MidpointRounding.AwayFromZero);
    }

    public Dinheiro Adicionar(Dinheiro valor) => new Dinheiro(Valor + valor.Valor);

    public Dinheiro Multiplicar(decimal fator)
    {
        if (fator < 0)
            throw new DominioException("Fator não pode ser negativo.");

        return new Dinheiro(Valor * fator);
    }

    public Dinheiro Subtrair(Dinheiro valor) => new Dinheiro(Valor - valor.Valor);

    public override string ToString() => Valor.ToString("F2");
}

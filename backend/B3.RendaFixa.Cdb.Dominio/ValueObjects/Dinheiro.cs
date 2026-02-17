using B3.RendaFixa.Cdb.Dominio.Excessoes;

namespace B3.RendaFixa.Cdb.Dominio.ValueObjects;

public sealed class Dinheiro
{
    public decimal Value { get; }

    public Dinheiro(decimal value)
    {
        if (value < 0)
            throw new DominioException("Valor monetário não pode ser negativo.");

        Value = Math.Round(value, 2, MidpointRounding.AwayFromZero);
    }

    public Dinheiro Adicionar(Dinheiro other) => new Dinheiro(Value + other.Value);

    public Dinheiro Multiplicar(decimal factor)
    {
        if (factor < 0)
            throw new DominioException("Fator não pode ser negativo.");

        return new Dinheiro(Value * factor);
    }

    public Dinheiro Subtrair(Dinheiro other) => new Dinheiro(Value - other.Value);

    public override string ToString() => Value.ToString("F2");
}

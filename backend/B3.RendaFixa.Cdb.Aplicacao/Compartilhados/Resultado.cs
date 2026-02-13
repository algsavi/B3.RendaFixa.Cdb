namespace B3.RendaFixa.Cdb.Aplicacao.Compartilhados
{
    public class Resultado<T>
    {
        public bool EhSucesso { get; }
        public bool EhFalha => !EhSucesso;
        public string? Erro { get; }
        public T? Valor { get; }

        private Resultado(bool sucesso, T? valor, string ?erro)
        {
            EhSucesso = sucesso;
            Valor = valor;
            Erro = erro;
        }

        public static Resultado<T> Sucesso(T valor)
            => new Resultado<T>(true, valor, null);

        public static Resultado<T> Falha(string erro)
            => new Resultado<T>(false, default, erro);
    }
}

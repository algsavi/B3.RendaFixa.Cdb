using B3.RendaFixa.Cdb.Aplicacao.Interfaces;
using B3.RendaFixa.Cdb.Aplicacao.Servicos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace B3.RendaFixa.Cdb.IoC
{
    public static class InjeacaoDependencia
    {
        public static IServiceCollection ConfigurarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICalcularCdb, CalcularCdbServico>();

            return services;
        }
    }
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace B3.RendaFixa.Cdb.WebApi.Autenticacao
{
    public class ApiKeyBearerHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public const string SchemeName = "ApiKeyBearer";

        private readonly IConfiguration _config;

        public ApiKeyBearerHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            IConfiguration config
        ) : base(options, logger, encoder)
        {
            _config = config;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var apiKeyConfigurada = _config["ApiKey"];

            if (string.IsNullOrWhiteSpace(apiKeyConfigurada))
                return Task.FromResult(AuthenticateResult.Fail("ApiKey não configurada."));

            if (!Request.Headers.TryGetValue("Authorization", out var authHeaderValues))
                return Task.FromResult(AuthenticateResult.Fail("Authorization header não informado."));

            var authHeader = authHeaderValues.ToString();

            if (!authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                return Task.FromResult(AuthenticateResult.Fail("Bearer token não informado."));

            var token = authHeader["Bearer ".Length..].Trim();

            if (!string.Equals(token, apiKeyConfigurada, StringComparison.Ordinal))
                return Task.FromResult(AuthenticateResult.Fail("Token inválido."));

            // Cria um usuário autenticado (claims mínimas)
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, "ApiKeyUser"),
        };

            var identity = new ClaimsIdentity(claims, SchemeName);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, SchemeName);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}

# B3.RendaFixa.Cdb

============================================================
DESCRIÇÃO
============================================================

Solução desenvolvida para cálculo de investimento em
CDB (Certificado de Depósito Bancário).

Tecnologias utilizadas:
- .NET 8
- Arquitetura em Camadas (Domain, Application, API)
- Result Pattern
- xUnit
- XPlat Code Coverage
- Angular (Frontend)

============================================================
ESTRUTURA DA SOLUÇÃO
============================================================

B3.RendaFixa.Cdb
|
|-- B3.RendaFixa.Cdb.Domain
|     -> Entidades
|     -> Value Objects
|     -> Regras de negócio
|
|-- B3.RendaFixa.Cdb.Application
|     -> Casos de uso
|     -> Result Pattern
|
|-- B3.RendaFixa.Cdb.API
|     -> Controllers
|     -> Endpoints REST
|
|-- B3.RendaFixa.Cdb.Tests
|     -> Testes unitários (xUnit)
|
|-- frontend
      -> Aplicação Angular


============================================================
PRÉ-REQUISITOS
============================================================

BACKEND:
- .NET SDK 8.0 ou superior
- Visual Studio 2022 ou VS Code

Verificar versão instalada:

dotnet --version


FRONTEND:
- Node.js 18+
- Angular CLI

Instalar Angular CLI (caso necessário):

npm install -g @angular/cli


============================================================
EXECUÇÃO DA SOLUÇÃO
============================================================

========================
EXECUTAR BACKEND
========================

1) Acessar pasta da API:

cd backend\B3.RendaFixa.Cdb.WebApi

2) Executar:

dotnet run --launch-profile https

3) A API estará provavelmente disponível em:

https://localhost:7167
ou
http://localhost:5207

Swagger (se habilitado):
https://localhost:7167/swagger


========================
EXECUTAR FRONTEND
========================

1) Acessar pasta frontend:

cd frontend

2) Instalar dependências:

npm install

3) Executar aplicação:

ng serve

4) Acessar no navegador:

http://localhost:4200


============================================================
EXECUÇÃO DOS TESTES
============================================================

1) Ir até a raiz da solução backend:

cd B3.RendaFixa.Cdb

2) Executar:

dotnet test


============================================================
COBERTURA DE CÓDIGO
============================================================

A solução utiliza XPlat Code Coverage.

Executar:

dotnet test --collect:"XPlat Code Coverage"

Após execução será gerado arquivo:

TestResults/<GUID>/coverage.cobertura.xml

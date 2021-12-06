# Api RestFull Simples .Net Core e Banco de Dados Postgresql
Aplicação simples com métodos http para a administração de um cadastro de pessoas usando o recurso _Migrations_ para criação da tabela e _Scaffolding_ para geração do arquivo "PessoaController" com os métodos https

## Ferramentas Utilizadas
- IDE Vs Code
- S.O. Debian
- Banco de dados Postgresql 12
- Documentação usando _swagger_ https://localhost:5001/swagger

## Packages Instalados
- dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Tools
- dotnet add package Microsoft.EntityFrameworkCore.SqlServer
# Comando para a instalação do _dotnet-aspnet-codegenerator_
- dotnet tool install -g dotnet-aspnet-codegenerator
- dotnet tool update -g dotnet-aspnet-codegenerator

## Comandos
# Comando para a instalação do _dotnet-ef_
- dotnet tool install --global dotnet-ef
# Criação das tabelas (_Migrations_)
- dotnet ef migrations add <Nome do arquivo>
- dotnet ef database update
# Criação do controller (_Scaffolding_)
- dotnet-aspnet-codegenerator controller -name PessoaController -m Pessoa -dc AppDbContext -nv -f -api --relativeFolderPath Controllers --useDefaultLayout

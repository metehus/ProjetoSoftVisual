# ProjetoSoftVisual

## Como configurar o projeto:

Instale o .NET SDK e execute esses comandos **dentro da pasta SoftwareVisual01**:

1. `dotnet install` para instalar todas as dependências
2. `dotnet run` para iniciar o serviço

## Se tiver algum problema com essa instalação acima, tente usar esses comandos:
```bash
dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 6.0
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 6.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0
dotnet new tool-manifest
dotnet tool install --global dotnet-ef -- version 6.0
```

e então para iniciar, use `dotnet run`

## Se for atualizar algo no banco (nas classes), execute esses comandos: 

1. `dotnet ef migrations add <digite um nome para a mudança aqui>`
2. `dotnet ef database update`
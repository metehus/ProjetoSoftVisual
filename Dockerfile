FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Copy everything
COPY ./SoftwareVisual01 ./

RUN dotnet build
EXPOSE 5000

ENTRYPOINT ["dotnet", "run", "--urls=http://localhost:5000/"]
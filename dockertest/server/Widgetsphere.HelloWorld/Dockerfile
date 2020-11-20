FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY [".", "Widgetsphere.HelloWorld/"]
RUN dotnet restore "Foda.SecureIt.PostgresInstall/Foda.SecureIt.PostgresInstall.csproj"
COPY . .
WORKDIR "/src/Foda.SecureIt.PostgresInstall"
RUN dotnet build "Foda.SecureIt.PostgresInstall.csproj" -c Release -o /app/build

FROM build AS publish
LABEL stage=publish
RUN dotnet publish "Foda.SecureIt.PostgresInstall.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Foda.SecureIt.PostgresInstall.dll"]
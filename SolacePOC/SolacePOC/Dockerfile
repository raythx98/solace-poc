FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SolacePOC/SolacePOC.csproj", "SolacePOC/"]
RUN dotnet restore "SolacePOC/SolacePOC.csproj"
COPY . .
WORKDIR "/src/SolacePOC"
RUN dotnet build "SolacePOC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SolacePOC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SolacePOC.dll"]

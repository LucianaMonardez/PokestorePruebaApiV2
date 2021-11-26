#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PokestorePruebaV2Api/PokestorePruebaV2Api.csproj", "PokestorePruebaV2Api/"]
RUN dotnet restore "PokestorePruebaV2Api/PokestorePruebaV2Api.csproj"
COPY . .
WORKDIR "/src/PokestorePruebaV2Api"
RUN dotnet build "PokestorePruebaV2Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PokestorePruebaV2Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PokestorePruebaV2Api.dll"]
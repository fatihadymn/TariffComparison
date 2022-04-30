#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TariffComparison/TariffComparison.csproj", "TariffComparison/"]
RUN dotnet restore "TariffComparison/TariffComparison.csproj"
COPY . .
WORKDIR "/src/TariffComparison"
RUN dotnet build "TariffComparison.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TariffComparison.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TariffComparison.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Portfolio.Website.Application/Portfolio.Website.Application.csproj", "Portfolio.Website.Application/"]
COPY ["Portfolio.Website.Git/Portfolio.Website.Git.csproj", "Portfolio.Website.Git/"]
COPY ["Portfolio.Website.Common/Portfolio.Website.Common.csproj", "Portfolio.Website.Common/"]
RUN dotnet restore "Portfolio.Website.Application/Portfolio.Website.Application.csproj"
COPY . .
WORKDIR "/src/Portfolio.Website.Application"
RUN dotnet build "Portfolio.Website.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Portfolio.Website.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Portfolio.Website.Application.dll"]
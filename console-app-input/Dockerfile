#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["console-app-input/console-app-input.csproj", "console-app-input/"]
RUN dotnet restore "console-app-input/console-app-input.csproj"
COPY . .
WORKDIR "/src/console-app-input"
RUN dotnet build "console-app-input.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "console-app-input.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "console-app-input.dll"]
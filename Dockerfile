FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
WORKDIR /app

EXPOSE 443
EXPOSE 80

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# 2nd stage
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "samplewebapp.dll" ]
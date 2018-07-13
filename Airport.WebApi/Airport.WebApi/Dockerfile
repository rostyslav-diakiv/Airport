FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 10296
EXPOSE 44372

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY Airport.WebApi/Airport.WebApi.csproj Airport.WebApi/
RUN dotnet restore Airport.WebApi/Airport.WebApi.csproj
COPY . .
WORKDIR /src/Airport.WebApi
RUN dotnet build Airport.WebApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Airport.WebApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Airport.WebApi.dll"]

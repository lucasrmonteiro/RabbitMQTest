FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Publisher.Service/Publisher.Service.csproj", "Publisher.Service/"]
RUN dotnet restore "Publisher.Service/Publisher.Service.csproj"
COPY . .
WORKDIR "/src/Publisher.Service"
RUN dotnet build "Publisher.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Publisher.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Publisher.Service.dll"]
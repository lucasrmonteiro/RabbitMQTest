FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Subscriber.Service/Subscriber.Service.csproj", "Subscriber.Service/"]
RUN dotnet restore "Subscriber.Service/Subscriber.Service.csproj"
COPY . .
WORKDIR "/src/Subscriber.Service"
RUN dotnet build "Subscriber.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Subscriber.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Subscriber.Service.dll"]
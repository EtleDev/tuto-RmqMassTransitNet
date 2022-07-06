#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EtleDev.Tutos.MassTransit.Receiver/EtleDev.Tutos.MassTransit.Receiver.csproj", "EtleDev.Tutos.MassTransit.Receiver/"]
COPY ["EtleDev.Tutos.MassTransit.Core/EtleDev.Tutos.MassTransit.Core.csproj", "EtleDev.Tutos.MassTransit.Core/"]
RUN dotnet restore "EtleDev.Tutos.MassTransit.Receiver/EtleDev.Tutos.MassTransit.Receiver.csproj"
COPY . .
WORKDIR "/src/EtleDev.Tutos.MassTransit.Receiver"
RUN dotnet build "EtleDev.Tutos.MassTransit.Receiver.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EtleDev.Tutos.MassTransit.Receiver.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EtleDev.Tutos.MassTransit.Receiver.dll"]
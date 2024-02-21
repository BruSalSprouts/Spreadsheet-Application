FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ConsoleTestApp1/ConsoleTestApp1.csproj", "ConsoleTestApp1/"]
RUN dotnet restore "ConsoleTestApp1/ConsoleTestApp1.csproj"
COPY . .
WORKDIR "/src/ConsoleTestApp1"
RUN dotnet build "ConsoleTestApp1.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ConsoleTestApp1.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleTestApp1.dll"]

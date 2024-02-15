FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TextReaderAndSaver/TextReaderAndSaver.csproj", "TextReaderAndSaver/"]
RUN dotnet restore "TextReaderAndSaver/TextReaderAndSaver.csproj"
COPY . .
WORKDIR "/src/TextReaderAndSaver"
RUN dotnet build "TextReaderAndSaver.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TextReaderAndSaver.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TextReaderAndSaver.dll"]

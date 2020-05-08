FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
RUN apt update && \
    apt install unzip && \
    curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l /vsdbg
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["webapi-template-2.csproj", "./"]
RUN dotnet restore "./webapi-template-2.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "webapi-template-2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "webapi-template-2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webapi-template-2.dll"]

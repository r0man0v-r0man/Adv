
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.2-buster-slim AS base
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /app
EXPOSE 80
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /src
# Copy csproj and restore as distinct layers
COPY Adv.sln .
COPY Adv.API/Adv.API.csproj ./Adv.API/
COPY Adv.DAL/Adv.DAL.csproj ./Adv.DAL/
COPY Adv.BLL/Adv.BLL.csproj ./Adv.BLL/
COPY XMLConverter/XMLConverter.csproj ./XMLConverter/

RUN dotnet restore

COPY . .

WORKDIR /src/Adv.API/
RUN dotnet build -c Release -o /app/build
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adv.API.dll"]
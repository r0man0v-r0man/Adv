#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /app
EXPOSE 19138
EXPOSE 44335

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /src
COPY ["Adv.API/Adv.API.csproj", "Adv.API/"]
COPY ["Adv.DAL/Adv.DAL.csproj", "Adv.DAL/"]
COPY ["Adv.BLL/Adv.BLL.csproj", "Adv.BLL/"]
RUN dotnet restore "Adv.API/Adv.API.csproj"

COPY . .
WORKDIR "/src/Adv.API"
RUN dotnet build "Adv.API.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Adv.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adv.API.dll"]
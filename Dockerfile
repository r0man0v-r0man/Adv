
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
# Setup NodeJs
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_12.x | bash - && \
    apt-get install -y build-essential nodejs
# Copy everything else and build
WORKDIR /source
EXPOSE 19138
EXPOSE 44335
# Copy csproj and restore as distinct layers
COPY Adv.sln .
COPY Adv.API/Adv.API.csproj ./Adv.API/
COPY Adv.DAL/Adv.DAL.csproj ./Adv.DAL/
COPY Adv.BLL/Adv.BLL.csproj ./Adv.BLL/
COPY XMLConverter/XMLConverter.csproj ./XMLConverter/
RUN dotnet restore

COPY Adv.API/. ./Adv.API/
COPY Adv.DAL/. ./Adv.DAL/
COPY Adv.BLL/. ./Adv.BLL/
COPY XMLConverter/. ./XMLConverter/
WORKDIR /source/Adv.API/
RUN dotnet publish -c release -o /app 
# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
# Setup NodeJs
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_12.x | bash - && \
    apt-get install -y build-essential nodejs
# Copy everything else and build
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Adv.API.dll"]
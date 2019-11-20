#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1903 AS build
WORKDIR /src
COPY ["GieldaL2.API/GieldaL2.API.csproj", "GieldaL2.API/"]
COPY ["GieldaL2.INFRASTRUCTURE/GieldaL2.INFRASTRUCTURE.csproj", "GieldaL2.INFRASTRUCTURE/"]
COPY ["GieldaL2.DB/GieldaL2.DB.csproj", "GieldaL2.DB/"]
RUN dotnet restore "GieldaL2.API/GieldaL2.API.csproj"
COPY . .
WORKDIR "/src/GieldaL2.API"
RUN dotnet build "GieldaL2.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GieldaL2.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GieldaL2.API.dll"]
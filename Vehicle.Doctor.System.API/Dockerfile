#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Vehicle.Doctor.System.API/Vehicle.Doctor.System.API.csproj", "Vehicle.Doctor.System.API/"]
RUN dotnet restore "Vehicle.Doctor.System.API/Vehicle.Doctor.System.API.csproj"
COPY . .
WORKDIR "/src/Vehicle.Doctor.System.API"
RUN dotnet build "Vehicle.Doctor.System.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vehicle.Doctor.System.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vehicle.Doctor.System.API.dll"]

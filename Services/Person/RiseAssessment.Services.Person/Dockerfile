#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Person/RiseAssessment.Services.Person/RiseAssessment.Services.Person.csproj", "Services/Person/RiseAssessment.Services.Person/"]
RUN dotnet restore "Services/Person/RiseAssessment.Services.Person/RiseAssessment.Services.Person.csproj"
COPY . .
WORKDIR "/src/Services/Person/RiseAssessment.Services.Person"
RUN dotnet build "RiseAssessment.Services.Person.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RiseAssessment.Services.Person.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RiseAssessment.Services.Person.dll"]
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SpecificRoute/SpecificRoute.csproj", "SpecificRoute/"]
RUN dotnet restore "SpecificRoute/SpecificRoute.csproj"
COPY . .
WORKDIR "/src/SpecificRoute"
RUN dotnet build "SpecificRoute.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpecificRoute.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpecificRoute.dll"]

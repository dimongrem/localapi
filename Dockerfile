FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["localapi/localapi.csproj", "localapi/"]
RUN dotnet restore "localapi/localapi.csproj"
COPY . .
WORKDIR "/src/localapi"
RUN dotnet build "localapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "localapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "localapi.dll"]

# FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
# WORKDIR /app

# # Copy csproj and restore as distinct layers
# COPY *.csproj ./
# RUN dotnet restore

# # Copy everything else and build
# COPY . ./
# RUN dotnet publish -c Release -o out

# # Build runtime image
# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
# WORKDIR /app
# COPY --from=build-env /app/out .
# ENV ASPNETCORE_URLS http://*:5000
# ENV ASPNETCORE_ENVIRONMENT Docker
# ENTRYPOINT ["dotnet", "localapi.dll"]
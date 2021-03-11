#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["MangoWebApi.WEBAPI/MangoWebApi.WEBAPI.csproj", "MangoWebApi.WEBAPI/"]
COPY ["MangoWebApi.Redis/MangoWebApi.Redis.csproj", "MangoWebApi.Redis/"]
COPY ["MangoWebApi.DAL/MangoWebApi.DAL.csproj", "MangoWebApi.DAL/"]
COPY ["MangoWebApi.Repositories/MangoWebApi.Repositories.csproj", "MangoWebApi.Repositories/"]
COPY ["MangoWebApi.BLL/MangoWebApi.BLL.csproj", "MangoWebApi.BLL/"]
RUN dotnet restore "MangoWebApi.WEBAPI/MangoWebApi.WEBAPI.csproj"
COPY . .
WORKDIR "/src/MangoWebApi.WEBAPI"
RUN dotnet build "MangoWebApi.WEBAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MangoWebApi.WEBAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MangoWebApi.WEBAPI.dll"]
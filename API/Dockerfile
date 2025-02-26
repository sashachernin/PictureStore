FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["PictureStore.API/PictureStore.API.csproj", "PictureStore.API/"]
COPY ["PictureStore.Common/PictureStore.Common.csproj", "PictureStore.Common/"]
COPY ["PictureStore.Data/PictureStore.Data.csproj", "PictureStore.Data/"]
COPY ["PictureStore.Logic/PictureStore.Service.csproj", "PictureStore.Logic/"]

RUN dotnet restore "PictureStore.API/PictureStore.API.csproj"

COPY . .

RUN dotnet build "PictureStore.API/PictureStore.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PictureStore.API/PictureStore.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:80

COPY --from=publish /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "PictureStore.API.dll"]
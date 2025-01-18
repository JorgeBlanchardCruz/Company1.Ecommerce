FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /src
COPY . .
WORKDIR /src/Company1.Ecommerce.Service.WebApi
RUN dotnet publish -c Debug -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /src/Company1.Ecommerce.Service.WebApi/out ./

ENTRYPOINT ["dotnet", "Company1.Ecommerce.Service.WebApi.dll"]

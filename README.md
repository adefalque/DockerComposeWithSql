A playground project that runs with docker-compose 2 containers:  
- a .Net Core WebApi project using Entity Framework Core
- Sql Server 2019

## Run Sql with Docker:

_docker pull mcr.microsoft.com/mssql/server:2019-latest_  
_docker run -d --name sql_server -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Pa55w0rd!' -p 1433:1433 mcr.microsoft.com/mssql/server:2019-latest_

## Install dotnet-ef global tool

_dotnet tool install --global dotnet-ef_

## Run with Connection String as environment variable (on MacOS)

_export ConnectionStrings\_\_WeatherForecastDb='Server=.;Initial Catalog=WeatherForecast;User ID=WeatherForecastUser;Password=Pa55w0rd!'_  
_dotnet run_

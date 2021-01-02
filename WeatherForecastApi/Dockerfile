FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app

# The EXPOSE instruction does not actually publish the port. 
# It functions as a type of documentation between the person who builds the image and the person 
# who runs the container, about which ports are intended to be published. 
# To actually publish the port when running the container, use the -p flag on docker run to publish 
# and map one or more ports
EXPOSE 80

COPY --from=build-env /app/out .
COPY ./wait-for-it.sh /wait-for-it.sh
RUN chmod +x /wait-for-it.sh
ENTRYPOINT ["dotnet", "WeatherForecastApi.dll"]